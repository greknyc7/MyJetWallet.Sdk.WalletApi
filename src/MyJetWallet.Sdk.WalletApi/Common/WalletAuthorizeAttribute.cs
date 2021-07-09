using Microsoft.AspNetCore.Authorization;

namespace MyJetWallet.Sdk.WalletApi.Common
{
    public class WalletAuthorizeAttribute : AuthorizeAttribute
    {
        public WalletAuthorizeAttribute()
        {
            Policy = AuthorizationPolicies.VerifiedEmailPolicy;
        }
    }
}