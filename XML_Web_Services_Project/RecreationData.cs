namespace NeighborhoodFriend_RecreationData
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class RecreationData
    {
        [JsonProperty("facility_type")]
        public FacilityType FacilityType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("zip_code")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ZipCode { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("human_address")]
        public string HumanAddress { get; set; }
    }

    public enum FacilityType { AquaticFacility, GolfCourse, RecreationCenter };

    public partial class RecreationData
    {
        public static List<RecreationData> FromJson(string json) => JsonConvert.DeserializeObject<List<RecreationData>>(json, NeighborhoodFriend_RecreationData.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<RecreationData> self) => JsonConvert.SerializeObject(self, NeighborhoodFriend_RecreationData.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                FacilityTypeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class FacilityTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FacilityType) || t == typeof(FacilityType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Aquatic Facility":
                    return FacilityType.AquaticFacility;
                case "Golf Course":
                    return FacilityType.GolfCourse;
                case "Recreation Center":
                    return FacilityType.RecreationCenter;
            }
            throw new Exception("Cannot unmarshal type FacilityType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (FacilityType)untypedValue;
            switch (value)
            {
                case FacilityType.AquaticFacility:
                    serializer.Serialize(writer, "Aquatic Facility");
                    return;
                case FacilityType.GolfCourse:
                    serializer.Serialize(writer, "Golf Course");
                    return;
                case FacilityType.RecreationCenter:
                    serializer.Serialize(writer, "Recreation Center");
                    return;
            }
            throw new Exception("Cannot marshal type FacilityType");
        }

        public static readonly FacilityTypeConverter Singleton = new FacilityTypeConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}

