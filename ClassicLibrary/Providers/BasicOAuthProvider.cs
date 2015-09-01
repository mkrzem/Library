using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using ClassicLibrary.DAL.Model;
using ClassicLibrary.DAL.Concrete;
using System.Security.Claims;

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

            if (user == null)
            {
                context.SetError("invalid_grant", "Invalid user name or password");
            }

            var identity = await userManager.CreateIdentityAsync(user, context.Options.AuthenticationType);            

            context.Validated(identity);
        }
    }
}