using Nop.Core;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Api.Models.Requests
{
    public class SearchProductsRequest
    {
        public List<int> filterableSpecificationAttributeOptionIds { get; set; }
        public bool loadFilterableSpecificationAttributeOptionIds { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public IList<int> categoryIds { get; set; }
        public int manufacturerId { get; set; }
        public int storeId { get; set; }
        public int vendorId { get; set; }
        public int warehouseId { get; set; }
        public ProductType? productType { get; set; }
        public bool visibleIndividuallyOnly { get; set; }
        public bool markedAsNewOnly { get; set; }
        public bool? featuredProducts { get; set; }
        public decimal? priceMin { get; set; }
        public decimal? priceMax { get; set; }
        public int productTagId { get; set; }
        public string keywords { get; set; }
        public bool searchDescriptions { get; set; }
        public bool searchManufacturerPartNumber { get; set; }
        public bool searchSku { get; set; }
        public bool searchProductTags { get; set; }
        public int languageId { get; set; }
        public IList<int> filteredSpecs { get; set; }
        public ProductSortingEnum orderBy { get; set; }
        public bool showHidden { get; set; }
        public bool? overridePublished { get; set; }
    }
}