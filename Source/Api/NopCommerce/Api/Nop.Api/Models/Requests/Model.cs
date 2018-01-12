using Nop.Core.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Api.Models.Requests
{
    public class ConvertFromPrimaryStoreCurrencyModel
    {
        public decimal amount { get; set; } public Currency targetCurrencyCode { get; set; }
    }
}