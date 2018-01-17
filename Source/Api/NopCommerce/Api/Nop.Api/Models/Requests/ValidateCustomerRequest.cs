using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Api.Models.Requests
{
    public class ValidateCustomerRequest
    {
        public string usernameOrEmail { get; set; }
        public string password { get; set; }
    }
}