using Nop.Core;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Api.Models.Responses
{
    public class SearchProductsResponse
    {
        public IList<int> filterableSpecificationAttributeOptionIds { get; set; }
        public IAPIPagedList<Product> data { get; set; }
    }
}