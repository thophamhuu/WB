using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Catalog
{
    public partial class ProductTemplateApiService : IProductTemplateService
    {
        #region Methods

        /// <summary>
        /// Delete product template
        /// </summary>
        /// <param name="productTemplate">Product template</param>
        public virtual void DeleteProductTemplate(ProductTemplate productTemplate)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteProductTemplate", productTemplate);
        }

        /// <summary>
        /// Gets all product templates
        /// </summary>
        /// <returns>Product templates</returns>
        public virtual IList<ProductTemplate> GetAllProductTemplates()
        {
            return APIHelper.Instance.GetListAsync<ProductTemplate>("Catalogs", "GetAllProductTemplates", null);
        }

        /// <summary>
        /// Gets a product template
        /// </summary>
        /// <param name="productTemplateId">Product template identifier</param>
        /// <returns>Product template</returns>
        public virtual ProductTemplate GetProductTemplateById(int productTemplateId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productTemplateId", productTemplateId);
            return APIHelper.Instance.GetAsync<ProductTemplate>("Catalogs", "GetProductTemplateById", parameters);
        }

        /// <summary>
        /// Inserts product template
        /// </summary>
        /// <param name="productTemplate">Product template</param>
        public virtual void InsertProductTemplate(ProductTemplate productTemplate)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertProductTemplate", productTemplate);
        }

        /// <summary>
        /// Updates the product template
        /// </summary>
        /// <param name="productTemplate">Product template</param>
        public virtual void UpdateProductTemplate(ProductTemplate productTemplate)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateProductTemplate", productTemplate);
        }

        #endregion
    }
}
