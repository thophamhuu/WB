using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Nop.Api.Models;
using Nop.Services.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Nop.Api.Providers
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {
        #region[GrantResourceOwnerCredentials]
        public override Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            
            var client = ClientContext.FindClient(context.ClientId);
            if (client != null)
            {
                var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
                oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, client.ClientName));
                oAuthIdentity.AddClaim(new Claim(ClaimTypes.Role, client.Roles));

                var props = CreateProperties(client.ClientId);

                var ticket = new AuthenticationTicket(oAuthIdentity, props);
                context.Validated(ticket);
            }
                
            return base.GrantClientCredentials(context);
        }
        #endregion
        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
           return base.GrantRefreshToken(context);
        }
        #region[ValidateClientAuthentication]

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
            context.TryGetFormCredentials(out clientId, out clientSecret);
            if (clientId != null && clientSecret != null)
            {
                if (ClientContext.ValidateClient(clientId, clientSecret))
                {
                    context.Validated(clientId);
                }
                else
                {
                    context.SetError("invalid_grant", "The client id or client secret is incorrect");
                }
            }
            else
            {
                //if (clientId == null)
                //{
                //    context.SetError("invalid_client", "The client_id is not missing");
                //}
                //if (clientSecret == null)
                //{
                //    context.SetError("invalid_client", "The client_secret is not missing");
                //}
                if (!context.Validated())
                {
                    context.Rejected();
                }
            }

          return  base.ValidateClientAuthentication(context);
        }
        #endregion

        #region[TokenEndpoint]

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        #endregion

        #region[CreateProperties]

        public static AuthenticationProperties CreateProperties(string clientId)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "clientId", clientId }
            };
            return new AuthenticationProperties(data);
        }

        #endregion
    }

}