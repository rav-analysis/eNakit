using System.Diagnostics;

namespace Microsoft.eShopWeb.ApplicationCore.Constants
{
    public class AuthorizationConstants
    {

        public const string AUTH_KEY = "AuthKeyOfDoomThatMustBeAMinimumNumberOfBytes";

        // TODO: Don't use this in production
        public const string DEFAULT_PASSWORD = "Testdemo$30";

        // TODO: Change this to an environment variable
        public const string JWT_SECRET_KEY = "SecretKeyOfDoomThatMustBeAMinimumNumberOfBytes";
        
    }
}


