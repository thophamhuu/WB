using Nop.Core;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Catalog
{
    public partial class CategoryApiService : ICategoryService
    {
        #region Methods

        /// <summary>
        /// Delete category
        /// </summary>
        /// <param name="category">Category</param>
        public virtual void DeleteCategory(Category category)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteCategory", category);
        }

        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <param name="categoryName">Category name</param>
        /// <param name="storeId">Store identifier; 0 if you want to get all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Categories</returns>
        public virtual IPagedList<Category> GetAllCategories(string categoryName = "", int storeId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("categoryName", categoryName);
            parameters.Add("storeId", storeId);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetPagedListAsync<Category>("Catalogs", "GetAllCategories", parameters);
        }

        /// <summary>
        /// Gets all categories filtered by parent category identifier
        /// </summary>
        /// <param name="parentCategoryId">Parent category identifier</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <param name="includeAllLevels">A value indicating whether we should load all child levels</param>
        /// <returns>Categories</returns>
        public virtual IList<Category> GetAllCategoriesByParentCategoryId(int parentCategoryId,
            bool showHidden = false, bool includeAllLevels = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("parentCategoryId", parentCategoryId);
            parameters.Add("showHidden", showHidden);
            parameters.Add("includeAllLevels", includeAllLevels);
            return APIHelper.Instance.GetListAsync<Category>("Catalogs", "GetAllCategoriesByParentCategoryId", parameters);
        }

        /// <summary>
        /// Gets all categories displayed on the home page
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Categories</returns>
        public virtual IList<Category> GetAllCategoriesDisplayedOnHomePage(bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetListAsync<Category>("Catalogs", "GetAllCategoriesDisplayedOnHomePage", parameters);
        }

        /// <summary>
        /// Gets a category
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <returns>Category</returns>
        public virtual Category GetCategoryById(int categoryId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("categoryId", categoryId);
            return APIHelper.Instance.GetAsync<Category>("Catalogs", "GetCategoryById", parameters);
        }

        /// <summary>
        /// Inserts category
        /// </summary>
        /// <param name="category">Category</param>
        public virtual void InsertCategory(Category category)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertCategory", category);
        }

        /// <summary>
        /// Updates the category
        /// </summary>
        /// <param name="category">Category</param>
        public virtual void UpdateCategory(Category category)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateCategory", category);
        }


        /// <summary>
        /// Deletes a product category mapping
        /// </summary>
        /// <param name="productCategory">Product category</param>
        public virtual void DeleteProductCategory(ProductCategory productCategory)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteProductCategory", productCategory);
        }

        /// <summary>
        /// Gets product category mapping collection
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Product a category mapping collection</returns>
        public virtual IPagedList<ProductCategory> GetProductCategoriesByCategoryId(int categoryId,
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("categoryId", categoryId);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetPagedListAsync<ProductCategory>("Catalogs", "GetProductCategoriesByCategoryId", parameters);
        }

        /// <summary>
        /// Gets a product category mapping collection
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <param name="showHidden"> A value indicating whether to show hidden records</param>
        /// <returns> Product category mapping collection</returns>
        public virtual IList<ProductCategory> GetProductCategoriesByProductId(int productId, bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productId", productId);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetListAsync<ProductCategory>("Catalogs", "GetProductCategoriesByProductId", parameters);
        }
        /// <summary>
        /// Gets a product category mapping collection
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <param name="storeId">Store identifier (used in multi-store environment). "showHidden" parameter should also be "true"</param>
        /// <param name="showHidden"> A value indicating whether to show hidden records</param>
        /// <returns> Product category mapping collection</returns>
        public virtual IList<ProductCategory> GetProductCategoriesByProductId(int productId, int storeId, bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productId", productId);
            parameters.Add("storeId", storeId);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetListAsync<ProductCategory>("Catalogs", "GetProductCategoriesByProductId", parameters);
        }

        /// <summary>
        /// Gets a product category mapping 
        /// </summary>
        /// <param name="productCategoryId">Product category mapping identifier</param>
        /// <returns>Product category mapping</returns>
        public virtual ProductCategory GetProductCategoryById(int productCategoryId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productCategoryId", productCategoryId);
            return APIHelper.Instance.GetAsync<ProductCategory>("Catalogs", "GetProductCategoryById", parameters);
        }

        /// <summary>
        /// Inserts a product category mapping
        /// </summary>
        /// <param name="productCategory">>Product category mapping</param>
        public virtual void InsertProductCategory(ProductCategory productCategory)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertProductCategory", productCategory);
        }

        /// <summary>
        /// Updates the product category mapping 
        /// </summary>
        /// <param name="productCategory">>Product category mapping</param>
        public virtual void UpdateProductCategory(ProductCategory productCategory)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateProductCategory", productCategory);
        }


        /// <summary>
        /// Returns a list of names of not existing categories
        /// </summary>
        /// <param name="categoryNames">The nemes of the categories to check</param>
        /// <returns>List of names not existing categories</returns>
        public virtual string[] GetNotExistingCategories(string[] categoryNames)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("categoryNames", categoryNames);
            return APIHelper.Instance.GetAsync<string[]>("Catalogs", "GetNotExistingCategories", parameters);
        }


        /// <summary>
        /// Get category IDs for products
        /// </summary>
        /// <param name="productIds">Products IDs</param>
        /// <returns>Category IDs for products</returns>
        public virtual IDictionary<int, int[]> GetProductCategoryIds(int[] productIds)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productIds", productIds);
            return APIHelper.Instance.GetAsync<IDictionary<int, int[]>>("Catalogs", "GetProductCategoryIds", parameters);
        }
        #endregion
    }
}
