using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Api.Models.Requests
{
    public class SaveSlugModel
    {
        public string entityName { get; set; }
        public dynamic entity { get; set; }
        public string slug { get; set; }
        public int languageId { get; set; }
    }
}