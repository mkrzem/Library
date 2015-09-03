using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using ClassicLibrary.DAL.Model;
using ClassicLibrary.DAL.Concrete;
using System.Security.Claims;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Linq;

namespace ClassicLibrary.Providers
{
    public class BasicOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();            
            var user = await userManager.FindAsync(context.UserName, context.Password);
            var roles = await userManager.GetRolesAsync(user.Id);

            if (user == null)
            {
                context.SetError("invalid_grant", "Invalid user name or password");
            }

            
            var identity = await userManager.CreateIdentityAsync(user, context.Options.AuthenticationType);
            var authProps = new AuthenticationProperties(new Dictionary<string, string>()
            {
                { "roles", string.Join(",", roles) }
            });
            var ticket = new AuthenticationTicket(identity, authProps);

            context.Validated(ticket);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> pair in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(pair.Key, pair.Value);
            }
            return Task.FromResult<object>(null);
        }
    }
}