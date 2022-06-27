﻿using System;
using System.Linq;
using Decisions.Equifax.PreQualificationOfOne.Response;
using Newtonsoft.Json;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace Decisions.Equifax
{
    internal class CodeAndDescriptionDataConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override CodeAndDescription ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                CodeAndDescription deserializeResult =
                    (serializer.Deserialize<CodeAndDescription[]>(reader) ?? throw new InvalidOperationException()).FirstOrDefault();
                return deserializeResult;
            }

            string JsonResponse = serializer.Deserialize(reader).ToString();
            
            return JsonConvert.DeserializeObject<CodeAndDescription>(JsonResponse);
        }

        public override bool CanConvert(Type objectType)
        {
            return (typeof(CodeAndDescription) == objectType);
        }
    }
}