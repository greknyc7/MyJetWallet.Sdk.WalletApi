﻿using System.Text.Json.Serialization;

namespace MyJetWallet.Sdk.WalletApi.Contracts
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ApiResponseCodes
    {
        OK = 0,
        InternalServerError = 1,        // Something went wrong. Please try again later.
        WalletDoNotExist = 2,           // Wallet is not found
        LowBalance = 3,                 // ...
        CannotProcessWithdrawal = 4,    // ?? Withdrawal request failed
        AddressIsNotValid = 5,          // Invalid address
        AssetDoNotFound = 6,            // Asset is not found
        AssetIsDisabled = 7,            // Asset is not supported / Trading is not available for this asset now. Please try again later.
        AmountIsSmall = 8,              // Your amount is too small
        InvalidInstrument = 9,          // Asset is not supported
        KycNotPassed = 10,              // Your account is not verified. Complete KYC verification now
        AssetDoNotSupported = 11,       // Asset is not supported / Trading is not available for this asset now. Please try again later.
        NotEnoughLiquidityForMarketOrder = 12,   // 
        InvalidOrderValue = 13,                  // 12
        CannotProcessQuoteRequest = 14,          // 
        CannotExecuteQuoteRequest = 15,          // 
        NoqEnoughLiquidityForConvert = 16,       // 
        LeadToNegativeSpread = 17,               // 
        WithdrawalDoNotFound = 18,               // 
        AddressDoNotSupported = 19,              // 
        CannotResendWithdrawalVerification = 20, //
        PhoneIsNotConfirmed = 21,                //
        NotSupported = 22,                       //
        OperationNotFound = 23,                  //
        OperationNotAllowed = 24,                //
        BlockchainIsNotConfigured = 25,          //
        BlockchainIsNotSupported = 26,           //
            
        //Auth
        InvalidUserNameOrPassword = 101,      // Invalid login or password
        UserExists = 102,                     // ??а нужно ли? мы же сделаи обходной флоу
        UserNotExist = 103,                   // ?? User not found
        OldPasswordNotMatch = 104,            // You entered the wrong current password
        Expired = 105,                        // Session has expired. Please log in again
        CountryIsRestricted = 106,            // Registration from your country is not allowed
        SocialNetworkNotSupported = 107,      // Social network is not available for log in
        SocialNetworkNotAvailable = 108,      // Social network is not available for log in
        ValidationError = 109,                // 
        BrandNotFound = 110,                  // Something went wrong. Please try again
        InvalidToken = 111,                   // ?? Invalid token. Please log in again
        RecaptchaFailed = 112,                // The CAPTCHA verification failed. Please try again
        
        //Circle, Cards
        InvalidKeyId = 201,                     // Invalid key id ????
        InvalidEncryptedData = 202,             // ????
        InvalidBillingName = 203,               // Invalid Name
        InvalidBillingCity = 204,               // Invalid city
        InvalidBillingCountry = 205,            // Invalid country
        InvalidBillingLine1 = 206,              // Invalid ???
        InvalidBillingDistrict = 207,           // Invalid district
        InvalidBillingPostalCode = 208,         // Invalid postal code
        InvalidExpMonth = 209,                  // Invalid expiration month
        InvalidExpYear = 210,                   // Invalid expiration year
        CardAddressMismatch = 211,              // ??
        CardZipMismatch = 212,                  // ??
        CardCvvInvalid = 213,                   // Invalid CVV code
        CardExpired = 214,                      // Card is expired
        CardFailed = 215,                       // 
        CardNotFound = 216,                     // 
        PaymentFailed = 217,                    // 
        CardFirstAndLastNameCannotBeEmpty = 218,  // 
        InvalidGuid = 219 //  
    }
}
