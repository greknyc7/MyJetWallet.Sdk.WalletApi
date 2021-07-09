using Microsoft.AspNetCore.Authorization;

namespace MyJetWallet.Sdk.WalletApi.Common
{
    public static class AuthorizationPolicies
    {
        public const string VerifiedEmailPolicy = "VerifiedEmail";

        public static void SetupWalletApiPolicy(this AuthorizationOptions options)
        {
            options.AddPolicy(AuthorizationPolicies.VerifiedEmailPolicy, policy => policy.RequireClaim("Email-Verified", "True"));
        }
    }
}