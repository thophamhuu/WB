using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Api.Models
{
    public class ClientContext
    {
        private static ClientContext _instance;
        private static List<ClientApi> _clientApis;
        public static ClientContext Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ClientContext();
                return _instance;
            }
        }
        private ClientContext()
        {
            _clientApis = new List<ClientApi>(){
                new ClientApi() {Id=1, ClientId= "27ae67c3-cb4d-4d43-b4ed-aee3f13a2f70",ClientSecret= "d9a83b578cdb380bf42fa4431f3284ef",ClientName="Test" ,Roles="Super System"},
                    new ClientApi() {Id=1, ClientId= "58aeb213-3887-40dd-928c-40a36b2d5ea3",ClientSecret= "c8dfe65e0ed657b49844f775dcd17341",ClientName="World Buy Web" ,Roles="Super System"},
                    new ClientApi() {Id=2, ClientId= "573df4cd-6fe2-4b9e-84a4-20058f5ae77d",ClientSecret= "b7846f8ab81254644e5d89f472aad50d",ClientName="World Buy App 1" ,Roles="Product" },
                    new ClientApi() {Id=3, ClientId= "42c34761-69e5-4f97-971b-a2036be3e827",ClientSecret= "8ef6ea91aeb32bda067c5283237c3f0e",ClientName="World Buy App 2" ,Roles="Customer" }
                };
        }
        public List<ClientApi> ClientApis { get { return _clientApis; } }
        public static bool ValidateClient(string clientId, string clientSecret)
        {
            var client = Instance.ClientApis.FirstOrDefault(x => x.ClientId == clientId && x.ClientSecret == clientSecret);
            return client != null;
        }
        public static ClientApi FindClient(string clientId)
        {
            return Instance.ClientApis.FirstOrDefault(x => x.ClientId == clientId);
        }
    }

    public class ClientApi
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ClientName { get; set; }
        public string Roles { get; set; }
    }
}