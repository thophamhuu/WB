using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Common
{
    public partial class FulltextApiService : IFulltextService
    {
        #region Methods

        /// <summary>
        /// Gets value indicating whether Full-Text is supported
        /// </summary>
        /// <returns>Result</returns>
        public virtual bool IsFullTextSupported()
        {
            return APIHelper.Instance.GetAsync<bool>("Common", "IsFullTextSupported", null);
        }

        /// <summary>
        /// Enable Full-Text support
        /// </summary>
        public virtual void EnableFullText()
        {
            APIHelper.Instance.PostAsync("Common", "EnableFullText", null);
        }

        /// <summary>
        /// Disable Full-Text support
        /// </summary>
        public virtual void DisableFullText()
        {
            APIHelper.Instance.PostAsync("Common", "DisableFullText", null);
        }

        #endregion
    }
}
