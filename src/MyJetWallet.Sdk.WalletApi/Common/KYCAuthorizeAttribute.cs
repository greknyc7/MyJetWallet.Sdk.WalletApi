using Microsoft.AspNetCore.Authorization;

namespace MyJetWallet.Sdk.WalletApi.Common
{
    public class KYCAuthorizeAttribute : AuthorizeAttribute
    {
        public KYCAuthorizeAttribute()
        {
            Policy = AuthorizationPolicies.PassedKYCPolicy;
        }
    }
}