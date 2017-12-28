using SimpleWebAPI.API.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using SimpleWebAPI.API.Identity;

namespace SimpleWebAPI.API
{
    public partial class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        public void ConfigureOAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(IdentityContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            var oAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/oauth/token"),
                Provider = new SimpleAuthorizationServerProvider(),
                AuthorizeEndpointPath = new PathString("/api/Usuario/Login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(90),
                // AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(5),
                RefreshTokenProvider = new SimpleRefreshTokenProvider(),
                AllowInsecureHttp = true
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(oAuthServerOptions);

            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);

        }
    }
}