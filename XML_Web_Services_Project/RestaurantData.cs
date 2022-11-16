namespace NeighborhoodFriend_RestaurantData
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class RestaurantData
    {
        [JsonProperty("recordnum_license")]
        public string RecordNumLicense { get; set; }

        [JsonProperty("license_no")]
        public string LicenseNo { get; set; }

        [JsonProperty("business_name")]
        public string BusinessName { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("state")]
        public State State { get; set; }

        [JsonProperty("postal_code")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long PostalCode { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("phone_number", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }

        [JsonProperty("license_status")]
        public LicenseStatus LicenseStatus { get; set; }

        [JsonProperty("recordnum_insp")]
        public string RecordNumInsp { get; set; }

        [JsonProperty("insp_type")]
        public InspType InspType { get; set; }

        [JsonProperty("insp_subtype")]
        public InspSubtype InspSubtype { get; set; }

        [JsonProperty("action_date")]
        public DateTimeOffset ActionDate { get; set; }

        [JsonProperty("action_sequence", NullValueHandling = NullValueHandling.Ignore)]
        public string ActionSequence { get; set; }

        [JsonProperty("action_status")]
        public ActionStatus ActionStatus { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        [JsonProperty("violation_description", NullValueHandling = NullValueHandling.Ignore)]
        public string ViolationDescription { get; set; }

        [JsonProperty("violation_comments", NullValueHandling = NullValueHandling.Ignore)]
        public string ViolationComments { get; set; }

        [JsonProperty("violation_key", NullValueHandling = NullValueHandling.Ignore)]
        public string ViolationKey { get; set; }

        [JsonProperty("last_table_update")]
        public DateTimeOffset LastTableUpdate { get; set; }

        [JsonProperty("neighborhood")]
        public string Neighborhood { get; set; }
    }

    public enum ActionStatus { Abated, AbatedOnSite, ClosNoNoViolationsFound, NotAbated };

    public enum City { Cincinnati };

    public enum InspSubtype { Complaint, StandardInspection };

    public enum InspType { Complaint, Routine };

    public enum LicenseStatus { Applied, Delinq, License, Paid };

    public enum State { Oh };

    public partial class RestaurantData
    {
        public static List<RestaurantData> FromJson(string json) => JsonConvert.DeserializeObject<List<RestaurantData>>(json, NeighborhoodFriend_RestaurantData.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<RestaurantData> self) => JsonConvert.SerializeObject(self, NeighborhoodFriend_RestaurantData.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ActionStatusConverter.Singleton,
                CityConverter.Singleton,
                InspSubtypeConverter.Singleton,
                InspTypeConverter.Singleton,
                LicenseStatusConverter.Singleton,
                StateConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ActionStatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ActionStatus) || t == typeof(ActionStatus?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Abated":
                    return ActionStatus.Abated;
                case "Abated On-Site":
                    return ActionStatus.AbatedOnSite;
                case "CLOS-NO  - No Violations Found":
                    return ActionStatus.ClosNoNoViolationsFound;
                case "Not Abated":
                    return ActionStatus.NotAbated;
            }
            throw new Exception("Cannot unmarshal type ActionStatus");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ActionStatus)untypedValue;
            switch (value)
            {
                case ActionStatus.Abated:
                    serializer.Serialize(writer, "Abated");
                    return;
                case ActionStatus.AbatedOnSite:
                    serializer.Serialize(writer, "Abated On-Site");
                    return;
                case ActionStatus.ClosNoNoViolationsFound:
                    serializer.Serialize(writer, "CLOS-NO  - No Violations Found");
                    return;
                case ActionStatus.NotAbated:
                    serializer.Serialize(writer, "Not Abated");
                    return;
            }
            throw new Exception("Cannot marshal type ActionStatus");
        }

        public static readonly ActionStatusConverter Singleton = new ActionStatusConverter();
    }

    internal class CityConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(City) || t == typeof(City?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "CINCINNATI")
            {
                return City.Cincinnati;
            }
            throw new Exception("Cannot unmarshal type City");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (City)untypedValue;
            if (value == City.Cincinnati)
            {
                serializer.Serialize(writer, "CINCINNATI");
                return;
            }
            throw new Exception("Cannot marshal type City");
        }

        public static readonly CityConverter Singleton = new CityConverter();
    }

    internal class InspSubtypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(InspSubtype) || t == typeof(InspSubtype?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "COMPLAINT":
                    return InspSubtype.Complaint;
                case "STANDARD INSPECTION":
                    return InspSubtype.StandardInspection;
            }
            throw new Exception("Cannot unmarshal type InspSubtype");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (InspSubtype)untypedValue;
            switch (value)
            {
                case InspSubtype.Complaint:
                    serializer.Serialize(writer, "COMPLAINT");
                    return;
                case InspSubtype.StandardInspection:
                    serializer.Serialize(writer, "STANDARD INSPECTION");
                    return;
            }
            throw new Exception("Cannot marshal type InspSubtype");
        }

        public static readonly InspSubtypeConverter Singleton = new InspSubtypeConverter();
    }

    internal class InspTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(InspType) || t == typeof(InspType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "COMPLAINT":
                    return InspType.Complaint;
                case "ROUTINE":
                    return InspType.Routine;
            }
            throw new Exception("Cannot unmarshal type InspType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (InspType)untypedValue;
            switch (value)
            {
                case InspType.Complaint:
                    serializer.Serialize(writer, "COMPLAINT");
                    return;
                case InspType.Routine:
                    serializer.Serialize(writer, "ROUTINE");
                    return;
            }
            throw new Exception("Cannot marshal type InspType");
        }

        public static readonly InspTypeConverter Singleton = new InspTypeConverter();
    }

    internal class LicenseStatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(LicenseStatus) || t == typeof(LicenseStatus?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "APPLIED":
                    return LicenseStatus.Applied;
                case "DELINQ":
                    return LicenseStatus.Delinq;
                case "LICENSE":
                    return LicenseStatus.License;
                case "PAID":
                    return LicenseStatus.Paid;
            }
            throw new Exception("Cannot unmarshal type LicenseStatus");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (LicenseStatus)untypedValue;
            switch (value)
            {
                case LicenseStatus.Applied:
                    serializer.Serialize(writer, "APPLIED");
                    return;
                case LicenseStatus.Delinq:
                    serializer.Serialize(writer, "DELINQ");
                    return;
                case LicenseStatus.License:
                    serializer.Serialize(writer, "LICENSE");
                    return;
                case LicenseStatus.Paid:
                    serializer.Serialize(writer, "PAID");
                    return;
            }
            throw new Exception("Cannot marshal type LicenseStatus");
        }

        public static readonly LicenseStatusConverter Singleton = new LicenseStatusConverter();
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

    internal class StateConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(State) || t == typeof(State?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "OH")
            {
                return State.Oh;
            }
            throw new Exception("Cannot unmarshal type State");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (State)untypedValue;
            if (value == State.Oh)
            {
                serializer.Serialize(writer, "OH");
                return;
            }
            throw new Exception("Cannot marshal type State");
        }

        public static readonly StateConverter Singleton = new StateConverter();
    }
}

