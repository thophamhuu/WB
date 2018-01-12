using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Catalog
{
    public partial class CategoryTemplateApiService : ICategoryTemplateService
    {
        #region Methods

        /// <summary>
        /// Delete category template
        /// </summary>
        /// <param name="categoryTemplate">Category template</param>
        public virtual void DeleteCategoryTemplate(CategoryTemplate categoryTemplate)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteCategoryTemplate", categoryTemplate);
        }

        /// <summary>
        /// Gets all category templates
        /// </summary>
        /// <returns>Category templates</returns>
        public virtual IList<CategoryTemplate> GetAllCategoryTemplates()
        {
            return APIHelper.Instance.GetListAsync<CategoryTemplate>("Catalogs", "GetAllCategoryTemplates", null);
        }

        /// <summary>
        /// Gets a category template
        /// </summary>
        /// <param name="categoryTemplateId">Category template identifier</param>
        /// <returns>Category template</returns>
        public virtual CategoryTemplate GetCategoryTemplateById(int categoryTemplateId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("categoryTemplateId", categoryTemplateId);
            return APIHelper.Instance.GetAsync<CategoryTemplate>("Catalogs", "GetCategoryTemplateById", parameters);
        }

        /// <summary>
        /// Inserts category template
        /// </summary>
        /// <param name="categoryTemplate">Category template</param>
        public virtual void InsertCategoryTemplate(CategoryTemplate categoryTemplate)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertCategoryTemplate", categoryTemplate);
        }

        /// <summary>
        /// Updates the category template
        /// </summary>
        /// <param name="categoryTemplate">Category template</param>
        public virtual void UpdateCategoryTemplate(CategoryTemplate categoryTemplate)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateCategoryTemplate", categoryTemplate);
        }

        #endregion
    }
}
