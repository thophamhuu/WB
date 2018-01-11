using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Api.Models.Requests
{
    public class InsertAclRecordModel
    {
        public string entityName { get; set; }
        public dynamic entity { get; set; }
        public int customerRoleId { get; set; }
    }
}