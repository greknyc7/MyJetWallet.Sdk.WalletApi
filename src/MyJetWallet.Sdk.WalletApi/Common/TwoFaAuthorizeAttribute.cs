using Microsoft.AspNetCore.Authorization;

namespace MyJetWallet.Sdk.WalletApi.Common
{
    public class TwoFaAuthorizeAttribute : AuthorizeAttribute
    {
        public TwoFaAuthorizeAttribute()
        {
            Policy = AuthorizationPolicies.Passed2FaPolicy;
        }
    }
}