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
        NotSupported = 22,
        OperationNotFound = 23,
        OperationNotAllowed = 24,
        BlockchainIsNotConfigured = 25,
        BlockchainIsNotSupported = 26,
            
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
        RecaptchaFailed = 112,
        
        //Circle, Cards
        InvalidKeyId = 201,
        InvalidEncryptedData = 202,
        InvalidBillingName = 203,
        InvalidBillingCity = 204,
        InvalidBillingCountry = 205,
        InvalidBillingLine1 = 206,
        InvalidBillingDistrict = 207,
        InvalidBillingPostalCode = 208,
        InvalidExpMonth = 209,
        InvalidExpYear = 210,
        CardAddressMismatch = 211,
        CardZipMismatch = 212,
        CardCvvInvalid = 213,
        CardExpired = 214,
        CardFailed = 215,
        CardNotFound = 216,
        PaymentFailed = 217,
        CardFirstAndLastNameCannotBeEmpty = 218,
        InvalidGuid = 219
    }
}