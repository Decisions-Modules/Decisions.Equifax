using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Decisions.Equifax.ConsumerCreditReport.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace Decisions.Equifax
{
    public class FraudVictimIndicatorDataConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                List<object> resultItems = new List<object>();
                JArray o = JArray.Load(reader);
                foreach (var x in o)
                {
                    resultItems.Add(serializer.Deserialize(x.CreateReader()));
                }

                return resultItems.ToArray();
            }
            return serializer.Deserialize(reader);
        }

        public override bool CanConvert(Type objectType)
        {
            return (typeof(FraudVictimIndicator) == objectType);
        }
    }
}