using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyJetWallet.Sdk.WalletApi
{
    public class MyDoubleConverter : JsonConverter<double>
    {
        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var json = reader.GetString();
            if (json == null)
                throw new Exception("Cannot parse null as double");

            if (!double.TryParse(json, out var d))
                throw new Exception($"Cannot parce double, value: '{json}'");

            return d;
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(((decimal) value).ToString(CultureInfo.InvariantCulture));
        }
    }
}