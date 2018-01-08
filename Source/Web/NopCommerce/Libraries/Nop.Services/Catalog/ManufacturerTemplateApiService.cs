using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Catalog
{
    public partial class ManufacturerTemplateApiService : IManufacturerTemplateService
    {
        #region Methods

        /// <summary>
        /// Delete manufacturer template
        /// </summary>
        /// <param name="manufacturerTemplate">Manufacturer template</param>
        public virtual void DeleteManufacturerTemplate(ManufacturerTemplate manufacturerTemplate)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteManufacturerTemplate", manufacturerTemplate);
        }

        /// <summary>
        /// Gets all manufacturer templates
        /// </summary>
        /// <returns>Manufacturer templates</returns>
        public virtual IList<ManufacturerTemplate> GetAllManufacturerTemplates()
        {
            return APIHelper.Instance.GetListAsync<ManufacturerTemplate>("Catalogs", "GetAllManufacturerTemplates", null);
        }

        /// <summary>
        /// Gets a manufacturer template
        /// </summary>
        /// <param name="manufacturerTemplateId">Manufacturer template identifier</param>
        /// <returns>Manufacturer template</returns>
        public virtual ManufacturerTemplate GetManufacturerTemplateById(int manufacturerTemplateId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("manufacturerTemplateId", manufacturerTemplateId);
            return APIHelper.Instance.GetAsync<ManufacturerTemplate>("Catalogs", "GetManufacturerTemplateById", parameters);
        }

        /// <summary>
        /// Inserts manufacturer template
        /// </summary>
        /// <param name="manufacturerTemplate">Manufacturer template</param>
        public virtual void InsertManufacturerTemplate(ManufacturerTemplate manufacturerTemplate)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertManufacturerTemplate", manufacturerTemplate);
        }

        /// <summary>
        /// Updates the manufacturer template
        /// </summary>
        /// <param name="manufacturerTemplate">Manufacturer template</param>
        public virtual void UpdateManufacturerTemplate(ManufacturerTemplate manufacturerTemplate)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateManufacturerTemplate", manufacturerTemplate);
        }

        #endregion
    }
}
