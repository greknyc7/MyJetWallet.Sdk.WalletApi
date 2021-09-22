using Microsoft.AspNetCore.Authorization;

namespace MyJetWallet.Sdk.WalletApi.Common
{
    public static class AuthorizationPolicies
    {
        public const string VerifiedEmailPolicy = "VerifiedEmail";
        public const string Passed2FaPolicy = "Passed2Fa";
        public static void SetupWalletApiPolicy(this AuthorizationOptions options)
        {
            options.AddPolicy(AuthorizationPolicies.VerifiedEmailPolicy, policy => policy.RequireClaim("Email-Verified", "True"));
            options.AddPolicy(AuthorizationPolicies.Passed2FaPolicy, policy => policy.RequireClaim("2FA-Passed", "True"));
        }
    }
}