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
        public string RecordnumLicense { get; set; }

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

        [JsonProperty("postal_code", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long PostalCode { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("license_status")]
        public LicenseStatus LicenseStatus { get; set; }

        [JsonProperty("recordnum_insp")]
        public string RecordnumInsp { get; set; }

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
        public Neighborhood Neighborhood { get; set; }

        [JsonProperty("phone_number", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }
    }

    public enum ActionStatus { Abated, AbatedOnSite, ClosNoNoViolationsFound, NotAbated };

    public enum City { Cincinnati };

    public enum InspSubtype { Complaint, StandardInspection };

    public enum InspType { Complaint, Routine };

    public enum LicenseStatus { Delinq, License, Paid };

    public enum Neighborhood { Avondale, Clifton, CollegeHill, Corryville, Cuf, Downtown, EastEnd, EastPriceHill, Evanston, Hartwell, HydePark, Madisonville, Millvale, MtAdams, MtAuburn, MtWashington, NorthAvondalePaddockHills, Northside, Oakley, OverTheRhine, PleasantRidge, Queensgate, Riverside, Roselawn, SpringGroveVillage, WestEnd, WestPriceHill, Westwood };

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
                NeighborhoodConverter.Singleton,
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

    internal class NeighborhoodConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Neighborhood) || t == typeof(Neighborhood?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "AVONDALE":
                    return Neighborhood.Avondale;
                case "CLIFTON":
                    return Neighborhood.Clifton;
                case "COLLEGE HILL":
                    return Neighborhood.CollegeHill;
                case "CORRYVILLE":
                    return Neighborhood.Corryville;
                case "CUF":
                    return Neighborhood.Cuf;
                case "DOWNTOWN":
                    return Neighborhood.Downtown;
                case "EAST END":
                    return Neighborhood.EastEnd;
                case "EAST PRICE HILL":
                    return Neighborhood.EastPriceHill;
                case "EVANSTON":
                    return Neighborhood.Evanston;
                case "HARTWELL":
                    return Neighborhood.Hartwell;
                case "HYDE PARK":
                    return Neighborhood.HydePark;
                case "MADISONVILLE":
                    return Neighborhood.Madisonville;
                case "MILLVALE":
                    return Neighborhood.Millvale;
                case "MT. ADAMS":
                    return Neighborhood.MtAdams;
                case "MT. AUBURN":
                    return Neighborhood.MtAuburn;
                case "MT. WASHINGTON":
                    return Neighborhood.MtWashington;
                case "NORTH AVONDALE - PADDOCK HILLS":
                    return Neighborhood.NorthAvondalePaddockHills;
                case "NORTHSIDE":
                    return Neighborhood.Northside;
                case "OAKLEY":
                    return Neighborhood.Oakley;
                case "OVER-THE-RHINE":
                    return Neighborhood.OverTheRhine;
                case "PLEASANT RIDGE":
                    return Neighborhood.PleasantRidge;
                case "QUEENSGATE":
                    return Neighborhood.Queensgate;
                case "RIVERSIDE":
                    return Neighborhood.Riverside;
                case "ROSELAWN":
                    return Neighborhood.Roselawn;
                case "SPRING GROVE VILLAGE":
                    return Neighborhood.SpringGroveVillage;
                case "WEST END":
                    return Neighborhood.WestEnd;
                case "WEST PRICE HILL":
                    return Neighborhood.WestPriceHill;
                case "WESTWOOD":
                    return Neighborhood.Westwood;
            }
            throw new Exception("Cannot unmarshal type Neighborhood");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Neighborhood)untypedValue;
            switch (value)
            {
                case Neighborhood.Avondale:
                    serializer.Serialize(writer, "AVONDALE");
                    return;
                case Neighborhood.Clifton:
                    serializer.Serialize(writer, "CLIFTON");
                    return;
                case Neighborhood.CollegeHill:
                    serializer.Serialize(writer, "COLLEGE HILL");
                    return;
                case Neighborhood.Corryville:
                    serializer.Serialize(writer, "CORRYVILLE");
                    return;
                case Neighborhood.Cuf:
                    serializer.Serialize(writer, "CUF");
                    return;
                case Neighborhood.Downtown:
                    serializer.Serialize(writer, "DOWNTOWN");
                    return;
                case Neighborhood.EastEnd:
                    serializer.Serialize(writer, "EAST END");
                    return;
                case Neighborhood.EastPriceHill:
                    serializer.Serialize(writer, "EAST PRICE HILL");
                    return;
                case Neighborhood.Evanston:
                    serializer.Serialize(writer, "EVANSTON");
                    return;
                case Neighborhood.Hartwell:
                    serializer.Serialize(writer, "HARTWELL");
                    return;
                case Neighborhood.HydePark:
                    serializer.Serialize(writer, "HYDE PARK");
                    return;
                case Neighborhood.Madisonville:
                    serializer.Serialize(writer, "MADISONVILLE");
                    return;
                case Neighborhood.Millvale:
                    serializer.Serialize(writer, "MILLVALE");
                    return;
                case Neighborhood.MtAdams:
                    serializer.Serialize(writer, "MT. ADAMS");
                    return;
                case Neighborhood.MtAuburn:
                    serializer.Serialize(writer, "MT. AUBURN");
                    return;
                case Neighborhood.MtWashington:
                    serializer.Serialize(writer, "MT. WASHINGTON");
                    return;
                case Neighborhood.NorthAvondalePaddockHills:
                    serializer.Serialize(writer, "NORTH AVONDALE - PADDOCK HILLS");
                    return;
                case Neighborhood.Northside:
                    serializer.Serialize(writer, "NORTHSIDE");
                    return;
                case Neighborhood.Oakley:
                    serializer.Serialize(writer, "OAKLEY");
                    return;
                case Neighborhood.OverTheRhine:
                    serializer.Serialize(writer, "OVER-THE-RHINE");
                    return;
                case Neighborhood.PleasantRidge:
                    serializer.Serialize(writer, "PLEASANT RIDGE");
                    return;
                case Neighborhood.Queensgate:
                    serializer.Serialize(writer, "QUEENSGATE");
                    return;
                case Neighborhood.Riverside:
                    serializer.Serialize(writer, "RIVERSIDE");
                    return;
                case Neighborhood.Roselawn:
                    serializer.Serialize(writer, "ROSELAWN");
                    return;
                case Neighborhood.SpringGroveVillage:
                    serializer.Serialize(writer, "SPRING GROVE VILLAGE");
                    return;
                case Neighborhood.WestEnd:
                    serializer.Serialize(writer, "WEST END");
                    return;
                case Neighborhood.WestPriceHill:
                    serializer.Serialize(writer, "WEST PRICE HILL");
                    return;
                case Neighborhood.Westwood:
                    serializer.Serialize(writer, "WESTWOOD");
                    return;
            }
            throw new Exception("Cannot marshal type Neighborhood");
        }

        public static readonly NeighborhoodConverter Singleton = new NeighborhoodConverter();
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
