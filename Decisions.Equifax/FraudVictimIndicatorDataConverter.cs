using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Decisions.Equifax.ConsumerCreditReport.Response;
using DecisionsFramework.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace Decisions.Equifax
{
    internal class FraudVictimIndicatorDataConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override FraudVictimIndicator ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                FraudVictimIndicator deserializeResult =
                    serializer.Deserialize<FraudVictimIndicator[]>(reader).FirstOrDefault();
                return deserializeResult;
            }

            string JsonResonse = serializer.Deserialize(reader).ToString();
            
            return JsonConvert.DeserializeObject<FraudVictimIndicator>(JsonResonse);
        }

        public override bool CanConvert(Type objectType)
        {
            return (typeof(FraudVictimIndicator) == objectType);
        }
    }
}