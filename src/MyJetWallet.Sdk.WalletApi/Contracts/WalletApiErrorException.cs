using System;

namespace MyJetWallet.Sdk.WalletApi.Contracts
{
    public class WalletApiErrorException : Exception
    {
        public ApiResponseCodes Code { get; set; }

        public WalletApiErrorException(string message, ApiResponseCodes code) : base(message)
        {
            Code = code;
        }
        public WalletApiErrorException(ApiResponseCodes code)
        {
            Code = code;
        }
    }
}