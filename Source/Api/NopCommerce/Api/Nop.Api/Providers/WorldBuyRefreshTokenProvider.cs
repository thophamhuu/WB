

using Microsoft.Owin;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Api.Providers
{
    public class SimpleRefreshTokenProvider : IAuthenticationTokenProvider
    {
        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            Create(context);
        }

        public void Create(AuthenticationTokenCreateContext context)
        {
            object owinCollection;
            context.OwinContext.Environment.TryGetValue("Microsoft.Owin.Form#collection", out owinCollection);

            var grantType = ((FormCollection)owinCollection)?.GetValues("grant_type").FirstOrDefault();

            if (grantType == null || grantType.Equals("refresh_token")) return;

            //Dilerseniz access_token'dan farklı olarak refresh_token'ın expire time'ını da belirleyebilir, uzatabilirsiniz 
            //context.Ticket.Properties.ExpiresUtc = DateTime.UtcNow.AddMinutes(1);
            context.Ticket.Properties.ExpiresUtc = new DateTimeOffset(DateTime.Now.AddYears(1));
            context.SetToken(context.SerializeTicket());
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            Receive(context);
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket(context.Token);
            if (context.Ticket == null)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                context.Response.ReasonPhrase = "invalid token";
                return;
            }
            else if(context.Ticket.Properties.ExpiresUtc<=DateTime.UtcNow)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                context.Response.ReasonPhrase = "token is expired";
                return;
            }
            else
            {
                context.SetTicket(context.Ticket);
            }
        }
    }
}