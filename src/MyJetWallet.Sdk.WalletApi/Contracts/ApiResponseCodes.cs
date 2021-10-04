using System.Text.Json.Serialization;

namespace MyJetWallet.Sdk.WalletApi.Contracts
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ApiResponseCodes
    {
        OK = 0,
        InternalServerError = 1,
        WalletDoNotExist = 2,
        LowBalance = 3,
        CannotProcessWithdrawal = 4,
        AddressIsNotValid = 5,
        AssetDoNotFound = 6,
        AssetIsDisabled = 7,
        AmountIsSmall = 8,
        InvalidInstrument = 9,
        KycNotPassed = 10,
        AssetDoNotSupported = 11,
        NotEnoughLiquidityForMarketOrder = 12,
        InvalidOrderValue = 13,
        CannotProcessQuoteRequest = 14,
        CannotExecuteQuoteRequest = 15,
        NoqEnoughLiquidityForConvert = 16,
        LeadToNegativeSpread = 17,
        WithdrawalDoNotFound = 18,
        AddressDoNotSupported = 19,
        CannotResendWithdrawalVerification = 20,
        PhoneIsNotConfirmed = 21,
        
        
        //Auth
        InvalidUserNameOrPassword = 101,
        UserExists = 102,
        UserNotExist = 103,
        OldPasswordNotMatch = 104,
        Expired = 105,
        CountryIsRestricted = 106,
        SocialNetworkNotSupported = 107,
        SocialNetworkNotAvailable = 108,
        ValidationError = 109,
        BrandNotFound = 110,
        InvalidToken = 111,
        RecaptchaFailed = 112
    }
}