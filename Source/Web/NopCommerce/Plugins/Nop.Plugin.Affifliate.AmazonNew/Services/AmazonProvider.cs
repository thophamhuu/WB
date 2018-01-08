using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Plugin.Affiliate.Amazon.Domain;
using Nop.Core.Data;
using Nop.Plugin.Affiliate.Amazon.Models;
using Nop.Core.Domain.Catalog;
using Nop.Plugin.Affiliate.CategoryMap.Domain;
using Nop.Core.Caching;
using System.Web;
using System.Text.RegularExpressions;

namespace Nop.Plugin.Affiliate.Amazon.Services
{
    public partial class AmazonProvider : IAmazonProvider
    {
        #region Fields
        private const string CATEGORYAMAZON = "Nop.affiliate.categoryamazon}";
        private const string PRODUCTAMAZON = "Nop.affiliate.productamazon.categoryid-{0}";
        private const string PRODUCTMAPPING = "Nop.affiliate.productmapping.categoryid-{0}";

        private readonly IRepository<CategoryAmazon> _categoryAmazonRepository;
        private readonly IRepository<ProductMapping> _productMappingRepository;
        private readonly IRepository<ProductCategory> _productCategoryRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly ICacheManager _cacheManager;
        #endregion
        #region ctr
        public AmazonProvider(IRepository<CategoryAmazon> categoryAmazonRepository,
            IRepository<ProductMapping> productMappingRepository,
             IRepository<ProductCategory> productCategoryRepository,
              IRepository<Product> productRepository,
             ICacheManager cacheManager)
        {
            this._categoryAmazonRepository = categoryAmazonRepository;
            this._productCategoryRepository = productCategoryRepository;
            this._productMappingRepository = productMappingRepository;
            this._productRepository = productRepository;
            this._cacheManager = cacheManager;
        }
        #endregion
        public IEnumerable<CategoryAmazonModel> GetAllCategories(CategorySearch model)
        {
            string _cacheKey = CATEGORYAMAZON;
            var result = _cacheManager.Get<IEnumerable<CategoryAmazonModel>>(_cacheKey, () =>
            {
                var query = (from cA in _categoryAmazonRepository.TableNoTracking
                             select new CategoryAmazonModel
                             {
                                 BrowseNodeID = cA.BrowseNodeID,
                                 Name = cA.Name,
                                 Id = cA.Id,
                                 IsCategoryRoot = cA.IsCategoryRoot,
                                 ParentBrowseNodeID = cA.ParentBrowseNodeID,
                                 SearchIndex = cA.SearchIndex,
                                 Level = cA.Level
                             });
                if (query != null)
                {
                    return TreeView(query.ToList()).ToList();
                }
                return null;
            });
            if (model != null)
            {
                if (!String.IsNullOrEmpty(model.BrowseNodeId))
                {
                    result = result.Where(x => x.BrowseNodeID == model.BrowseNodeId).ToList();
                }
                if (!String.IsNullOrEmpty(model.CategoryName))
                {
                    string categoryName = HttpUtility.HtmlDecode(model.CategoryName);
                    switch (model.CompareType)
                    {
                        case (int)CompareType.Starts_With:
                            result = result.Where(x => x.Name.ToLower().Trim().StartsWith(categoryName.Trim().ToLower())).ToList();
                            break;
                        case (int)CompareType.Contains:
                            result = result.Where(x => x.Name.ToLower().Trim().Contains(categoryName.Trim().ToLower())).ToList();
                            break;
                        default:
                            result = result.Where(x => x.Name.Trim().ToLower() == categoryName.Trim().ToLower()).ToList();
                            break;
                    }
                }

            }
            return result;
        }
        public void ClearCacheCategory()
        {
            this.ClearCache(CATEGORYAMAZON);
        }
        public void ClearCacheProduct()
        {
            this.ClearCache(PRODUCTAMAZON);
        }
        public void ClearCacheProductMapping()
        {
            this.ClearCache(PRODUCTMAPPING);
        }
        private void ClearCache(string pattern)
        {
            _cacheManager.RemoveByPattern(pattern);
        }

        private IEnumerable<CategoryAmazonModel> TreeView(IList<CategoryAmazonModel> source, string parentId = "", string parentName = "")
        {
            if (source == null)
                throw new ArgumentNullException("source");
            var result = new List<CategoryAmazonModel>();
            if (parentName != null && parentName != "")
                parentName = parentName + " >> ";
            foreach (var cat in source.Where(c => c.ParentBrowseNodeID == parentId || parentId == ""))
            {
                cat.Name = parentName + cat.Name;
                if (!result.Contains(cat))
                {
                    result.Add(cat);
                    result.AddRange(TreeView(source, cat.BrowseNodeID, cat.Name));
                }
            }

            return result;
        }

        public IEnumerable<ProductAmazonModel> GetAllProduct(ProductParameter model)
        {
            string _cacheKey = string.Format(PRODUCTAMAZON, model.CategoryID);

            var result = _cacheManager.Get<IEnumerable<ProductAmazonModel>>(_cacheKey, () =>
            {
                var pIds = new List<int>();

                int count = 0;
                if (model.CategoryID == 0)
                {
                    pIds = _productMappingRepository.TableNoTracking.Where(x => x.SourceId == 2).OrderByDescending(x => x.ProductId).Select(x => x.ProductId).ToList();
                }
                else
                {
                    var pcIds = _productCategoryRepository.TableNoTracking.Where(x => x.CategoryId == model.CategoryID).Select(x => x.ProductId).ToList();
                    pIds = _productMappingRepository.TableNoTracking.Where(x => x.SourceId == 2 && pcIds.Contains(x.ProductId)).OrderByDescending(x => x.ProductId).Select(x => x.ProductId).ToList();
                }
                if (pIds != null)
                {
                    count = pIds.Count();
                    var query = from p in _productRepository.TableNoTracking
                                orderby p.CreatedOnUtc, p.Id
                                where pIds.Contains(p.Id)
                                select p;

                    return query.Select(p => new ProductAmazonModel
                    {
                        ASIN = p.Sku,
                        Name = p.Name,
                        Price = p.Price.ToString(),
                        ProductId = p.Id,
                    }).ToList();
                }
                return null;
            });
            if (result != null)
            {
                if (!String.IsNullOrEmpty(model.Keywords))
                {
                    result = result.Where(p => p.Name.Contains(model.Keywords)).ToList();
                }
            }

            return result;
        }

        public IList<int> GetAllProductMapping(ProductParameter model)
        {
            string _cacheKey = string.Format(PRODUCTMAPPING, model.CategoryID);

            var result = _cacheManager.Get<IList<int>>(_cacheKey, () =>
            {
                var pIds = new List<int>();

                int count = 0;
                var queryId = _productCategoryRepository.TableNoTracking;
                if (model.IsPublished.HasValue)
                {
                    queryId = queryId.Where(x => x.Product.Published == model.IsPublished);
                }
                if (model.CategoryID > 0)
                {
                    queryId = queryId.Where(x => x.CategoryId == model.CategoryID);
                }

                var pcIds = queryId.Select(x => x.ProductId).ToList();
                pIds = _productMappingRepository.TableNoTracking.Where(x => x.SourceId == 2 && pcIds.Contains(x.ProductId)).OrderByDescending(x => x.ProductId).Select(x => x.ProductId).ToList();
                if (pIds != null)
                {
                    count = pIds.Count();
                    var query = from p in _productRepository.TableNoTracking
                                orderby p.CreatedOnUtc, p.Id
                                where pIds.Contains(p.Id)
                                select p;

                    return query.Select(p => p.Id).ToList();
                }
                return null;
            });

            return result;
        }
    }
}
