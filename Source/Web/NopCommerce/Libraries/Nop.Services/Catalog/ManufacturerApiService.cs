using Nop.Core;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Catalog
{
    public partial class ManufacturerApiService : IManufacturerService
    {
        #region Methods

        /// <summary>
        /// Deletes a manufacturer
        /// </summary>
        /// <param name="manufacturer">Manufacturer</param>
        public virtual void DeleteManufacturer(Manufacturer manufacturer)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteManufacturer", manufacturer);
        }

        /// <summary>
        /// Gets all manufacturers
        /// </summary>
        /// <param name="manufacturerName">Manufacturer name</param>
        /// <param name="storeId">Store identifier; 0 if you want to get all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Manufacturers</returns>
        public virtual IPagedList<Manufacturer> GetAllManufacturers(string manufacturerName = "",
            int storeId = 0,
            int pageIndex = 0,
            int pageSize = int.MaxValue,
            bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("manufacturerName", manufacturerName);
            parameters.Add("storeId", storeId);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetPagedListAsync<Manufacturer>("Catalogs", "GetAllManufacturers", parameters);
        }

        /// <summary>
        /// Gets a manufacturer
        /// </summary>
        /// <param name="manufacturerId">Manufacturer identifier</param>
        /// <returns>Manufacturer</returns>
        public virtual Manufacturer GetManufacturerById(int manufacturerId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("manufacturerId", manufacturerId);
            return APIHelper.Instance.GetAsync<Manufacturer>("Catalogs", "GetManufacturerById", parameters);
        }

        /// <summary>
        /// Inserts a manufacturer
        /// </summary>
        /// <param name="manufacturer">Manufacturer</param>
        public virtual void InsertManufacturer(Manufacturer manufacturer)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertManufacturer", manufacturer);
        }

        /// <summary>
        /// Updates the manufacturer
        /// </summary>
        /// <param name="manufacturer">Manufacturer</param>
        public virtual void UpdateManufacturer(Manufacturer manufacturer)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateManufacturer", manufacturer);
        }


        /// <summary>
        /// Deletes a product manufacturer mapping
        /// </summary>
        /// <param name="productManufacturer">Product manufacturer mapping</param>
        public virtual void DeleteProductManufacturer(ProductManufacturer productManufacturer)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteProductManufacturer", productManufacturer);
        }

        /// <summary>
        /// Gets product manufacturer collection
        /// </summary>
        /// <param name="manufacturerId">Manufacturer identifier</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Product manufacturer collection</returns>
        public virtual IPagedList<ProductManufacturer> GetProductManufacturersByManufacturerId(int manufacturerId,
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("manufacturerId", manufacturerId);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetPagedListAsync<ProductManufacturer>("Catalogs", "GetProductManufacturersByManufacturerId", parameters);
        }

        /// <summary>
        /// Gets a product manufacturer mapping collection
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Product manufacturer mapping collection</returns>
        public virtual IList<ProductManufacturer> GetProductManufacturersByProductId(int productId, bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productId", productId);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetListAsync<ProductManufacturer>("Catalogs", "GetProductManufacturersByProductId", parameters);
        }

        /// <summary>
        /// Gets a product manufacturer mapping 
        /// </summary>
        /// <param name="productManufacturerId">Product manufacturer mapping identifier</param>
        /// <returns>Product manufacturer mapping</returns>
        public virtual ProductManufacturer GetProductManufacturerById(int productManufacturerId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productManufacturerId", productManufacturerId);
            return APIHelper.Instance.GetAsync<ProductManufacturer>("Catalogs", "GetProductManufacturerById", parameters);
        }

        /// <summary>
        /// Inserts a product manufacturer mapping
        /// </summary>
        /// <param name="productManufacturer">Product manufacturer mapping</param>
        public virtual void InsertProductManufacturer(ProductManufacturer productManufacturer)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertProductManufacturer", productManufacturer);
        }

        /// <summary>
        /// Updates the product manufacturer mapping
        /// </summary>
        /// <param name="productManufacturer">Product manufacturer mapping</param>
        public virtual void UpdateProductManufacturer(ProductManufacturer productManufacturer)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateProductManufacturer", productManufacturer);
        }


        /// <summary>
        /// Get manufacturer IDs for products
        /// </summary>
        /// <param name="productIds">Products IDs</param>
        /// <returns>Manufacturer IDs for products</returns>
        public virtual IDictionary<int, int[]> GetProductManufacturerIds(int[] productIds)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productIds", string.Join(",", productIds));
            return APIHelper.Instance.GetAsync<IDictionary<int, int[]>>("Catalogs", "GetProductManufacturerIds", parameters);
        }


        /// <summary>
        /// Returns a list of names of not existing manufacturers
        /// </summary>
        /// <param name="manufacturerNames">The names of the manufacturers to check</param>
        /// <returns>List of names not existing manufacturers</returns>
        public virtual string[] GetNotExistingManufacturers(string[] manufacturerNames)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("manufacturerNames", string.Join(",", manufacturerNames));
            return APIHelper.Instance.GetAsync<string[]>("Catalogs", "GetNotExistingManufacturers", parameters);
        }

        #endregion
    }
}
