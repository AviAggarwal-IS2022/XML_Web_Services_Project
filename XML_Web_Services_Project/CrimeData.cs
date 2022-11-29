namespace NeighborhoodFriend_CrimeData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CrimeData
    {
        [JsonProperty("instanceid")]
        public string Instanceid { get; set; }

        [JsonProperty("incident_no")]
        public string IncidentNo { get; set; }

        [JsonProperty("date_reported", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DateReported { get; set; }

        [JsonProperty("date_from")]
        public DateTimeOffset DateFrom { get; set; }

        [JsonProperty("date_to", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DateTo { get; set; }

        private Clsd? clsd;

        public Clsd? GetClsd()
        {
            return clsd;
        }

        public void SetClsd(Clsd? value)
        {
            clsd = value;
        }

        [JsonProperty("ucr", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Ucr { get; set; }

        [JsonProperty("dst")]
        public DstUnion Dst { get; set; }

        [JsonProperty("beat", NullValueHandling = NullValueHandling.Ignore)]
        public string Beat { get; set; }

        [JsonProperty("offense", NullValueHandling = NullValueHandling.Ignore)]
        public string Offense { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        private TheftCode? theftCode;

        public TheftCode? GetTheftCode()
        {
            return theftCode;
        }

        public void SetTheftCode(TheftCode? value)
        {
            theftCode = value;
        }

        [JsonProperty("side", NullValueHandling = NullValueHandling.Ignore)]
        public Side? Side { get; set; }

        private HateBias hateBias;

        public HateBias GetHateBias()
        {
            return hateBias;
        }

        public void SetHateBias(HateBias value)
        {
            hateBias = value;
        }

        [JsonProperty("dayofweek", NullValueHandling = NullValueHandling.Ignore)]
        public Dayofweek? Dayofweek { get; set; }

        [JsonProperty("rpt_area", NullValueHandling = NullValueHandling.Ignore)]
        public string RptArea { get; set; }

        [JsonProperty("cpd_neighborhood", NullValueHandling = NullValueHandling.Ignore)]
        public string CpdNeighborhood { get; set; }

        private Weapons weapons;

        public Weapons GetWeapons()
        {
            return weapons;
        }

        public void SetWeapons(Weapons value)
        {
            weapons = value;
        }

        [JsonProperty("date_of_clearance", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DateOfClearance { get; set; }

        [JsonProperty("hour_from")]
        public string HourFrom { get; set; }

        [JsonProperty("hour_to", NullValueHandling = NullValueHandling.Ignore)]
        public string HourTo { get; set; }

        [JsonProperty("address_x", NullValueHandling = NullValueHandling.Ignore)]
        public string AddressX { get; set; }

        [JsonProperty("longitude_x", NullValueHandling = NullValueHandling.Ignore)]
        public string LongitudeX { get; set; }

        [JsonProperty("latitude_x", NullValueHandling = NullValueHandling.Ignore)]
        public string LatitudeX { get; set; }

        private Age victimAge;

        public Age GetVictimAge()
        {
            return victimAge;
        }

        public void SetVictimAge(Age value)
        {
            victimAge = value;
        }

        [JsonProperty("victim_race", NullValueHandling = NullValueHandling.Ignore)]
        public Race? VictimRace { get; set; }

        [JsonProperty("victim_ethnicity", NullValueHandling = NullValueHandling.Ignore)]
        public Ethnicity? VictimEthnicity { get; set; }

        private Gender? victimGender;

        public Gender? GetVictimGender()
        {
            return victimGender;
        }

        public void SetVictimGender(Gender? value)
        {
            victimGender = value;
        }

        private Age suspectAge;

        public Age GetSuspectAge()
        {
            return suspectAge;
        }

        public void SetSuspectAge(Age value)
        {
            suspectAge = value;
        }

        [JsonProperty("suspect_race", NullValueHandling = NullValueHandling.Ignore)]
        public Race? SuspectRace { get; set; }

        [JsonProperty("suspect_ethnicity", NullValueHandling = NullValueHandling.Ignore)]
        public Ethnicity? SuspectEthnicity { get; set; }

        private Gender? suspectGender;

        public Gender? GetSuspectGender()
        {
            return suspectGender;
        }

        public void SetSuspectGender(Gender? value)
        {
            suspectGender = value;
        }

        [JsonProperty("totalnumbervictims", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Totalnumbervictims { get; set; }

        [JsonProperty("totalsuspects", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Totalsuspects { get; set; }

        [JsonProperty("ucr_group", NullValueHandling = NullValueHandling.Ignore)]
        public UcrGroup? UcrGroup { get; set; }

        [JsonProperty("zip")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Zip { get; set; }

        [JsonProperty("community_council_neighborhood")]
        public string CommunityCouncilNeighborhood { get; set; }

        [JsonProperty("sna_neighborhood")]
        public string SnaNeighborhood { get; set; }

        [JsonProperty("floor", NullValueHandling = NullValueHandling.Ignore)]
        public Floor? Floor { get; set; }

        private Opening? opening;

        public Opening? GetOpening()
        {
            return opening;
        }

        public void SetOpening(Opening? value)
        {
            opening = value;
        }
    }

    public enum Clsd { BProsecutionDeclined, DVictimRefusedToCooperate, FClearedByArrestAdult, GClearedByArrestJuvenile, HWarrantIssued, IInvestigationPending, JClosed, KUnfounded, ZEarlyClosed };

    public enum Dayofweek { Friday, Monday, Saturday, Sunday, Thursday, Tuesday, Wednesday };

    public enum DstEnum { CentralBusiness };

    public enum Floor { The1Basement, The2FirstFloor, The3SecondFloor, The4Other, The5Unknown };

    public enum HateBias { NNoBiasNotApplicable, The50OtherBiasIncidentEGAntiAidsVictim, The88DomesticViolence, The89GangRelated };

    public enum Opening { The1Door, The2Window, The3Garage, The5Other };

    public enum Side { Empty, The1Front, The2Side, The3Rear, The4Roof, The5Other, The6Unknown };

    public enum Age { Adult18, JuvenileUnder18, Over70, The1825, The2630, The3140, The4150, The5160, The6170, Under18, Unknown };

    public enum Ethnicity { HispanicOrigin, NotOfHispanicOrig, Unknown };

    public enum Gender { Female, Male, Unknown };

    public enum Race { AmericanIndianAlas, AsianPacificIsland, Black, Unknown, White };

    public enum TheftCode { The23APocketPicking, The23BPurseSnatching, The23CShoplifting, The23DTheftFromBuilding, The23FTheftFromMotorVehicle, The23GTheftOfMotorVehiclePartsOrAccessories, The23HAllOtherLarceny, The24ITheftOfLicensePlate, The24OMotorVehicleTheft };

    public enum UcrGroup { AggravatedAssaults, BurglaryBreakingEntering, Homicide, Part2Minor, Rape, Robbery, Theft, UnauthorizedUse };

    public enum Weapons { The11FirearmTypeNotStated, The12Handgun, The15BSemiAutomaticAssaultFirearm, The20KnifeCuttingInstrumentIcepickAxEtc, The30BluntObjectClubHammerEtc, The40PersonalWeaponsHandsFeetTeethEtc, The80OtherWeapon, The85AsphyxiationByDrowningStrangulationSuffocation, The99None, UUnknown };

    public partial struct DstUnion
    {
        public DstEnum? Enum;
        public long? Integer;

        public static implicit operator DstUnion(DstEnum Enum) => new DstUnion { Enum = Enum };
        public static implicit operator DstUnion(long Integer) => new DstUnion { Integer = Integer };
    }

    public partial class CrimeData
    {
        public static List<CrimeData> FromJson(string json) => JsonConvert.DeserializeObject<List<CrimeData>>(json, NeighborhoodFriend_CrimeData.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<CrimeData> self) => JsonConvert.SerializeObject(self, NeighborhoodFriend_CrimeData.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ClsdConverter.Singleton,
                DayofweekConverter.Singleton,
                DstUnionConverter.Singleton,
                DstEnumConverter.Singleton,
                FloorConverter.Singleton,
                HateBiasConverter.Singleton,
                OpeningConverter.Singleton,
                SideConverter.Singleton,
                AgeConverter.Singleton,
                EthnicityConverter.Singleton,
                GenderConverter.Singleton,
                RaceConverter.Singleton,
                TheftCodeConverter.Singleton,
                UcrGroupConverter.Singleton,
                WeaponsConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ClsdConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Clsd) || t == typeof(Clsd?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "B--PROSECUTION DECLINED":
                    return Clsd.BProsecutionDeclined;
                case "D--VICTIM REFUSED TO COOPERATE":
                    return Clsd.DVictimRefusedToCooperate;
                case "F--CLEARED BY ARREST - ADULT":
                    return Clsd.FClearedByArrestAdult;
                case "G--CLEARED BY ARREST - JUVENILE":
                    return Clsd.GClearedByArrestJuvenile;
                case "H--WARRANT ISSUED":
                    return Clsd.HWarrantIssued;
                case "I--INVESTIGATION PENDING":
                    return Clsd.IInvestigationPending;
                case "J--CLOSED":
                    return Clsd.JClosed;
                case "K--UNFOUNDED":
                    return Clsd.KUnfounded;
                case "Z--EARLY CLOSED":
                    return Clsd.ZEarlyClosed;
            }
            throw new Exception("Cannot unmarshal type Clsd");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Clsd)untypedValue;
            switch (value)
            {
                case Clsd.BProsecutionDeclined:
                    serializer.Serialize(writer, "B--PROSECUTION DECLINED");
                    return;
                case Clsd.DVictimRefusedToCooperate:
                    serializer.Serialize(writer, "D--VICTIM REFUSED TO COOPERATE");
                    return;
                case Clsd.FClearedByArrestAdult:
                    serializer.Serialize(writer, "F--CLEARED BY ARREST - ADULT");
                    return;
                case Clsd.GClearedByArrestJuvenile:
                    serializer.Serialize(writer, "G--CLEARED BY ARREST - JUVENILE");
                    return;
                case Clsd.HWarrantIssued:
                    serializer.Serialize(writer, "H--WARRANT ISSUED");
                    return;
                case Clsd.IInvestigationPending:
                    serializer.Serialize(writer, "I--INVESTIGATION PENDING");
                    return;
                case Clsd.JClosed:
                    serializer.Serialize(writer, "J--CLOSED");
                    return;
                case Clsd.KUnfounded:
                    serializer.Serialize(writer, "K--UNFOUNDED");
                    return;
                case Clsd.ZEarlyClosed:
                    serializer.Serialize(writer, "Z--EARLY CLOSED");
                    return;
            }
            throw new Exception("Cannot marshal type Clsd");
        }

        public static readonly ClsdConverter Singleton = new ClsdConverter();
    }

    internal class DayofweekConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Dayofweek) || t == typeof(Dayofweek?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "FRIDAY":
                    return Dayofweek.Friday;
                case "MONDAY":
                    return Dayofweek.Monday;
                case "SATURDAY":
                    return Dayofweek.Saturday;
                case "SUNDAY":
                    return Dayofweek.Sunday;
                case "THURSDAY":
                    return Dayofweek.Thursday;
                case "TUESDAY":
                    return Dayofweek.Tuesday;
                case "WEDNESDAY":
                    return Dayofweek.Wednesday;
            }
            throw new Exception("Cannot unmarshal type Dayofweek");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Dayofweek)untypedValue;
            switch (value)
            {
                case Dayofweek.Friday:
                    serializer.Serialize(writer, "FRIDAY");
                    return;
                case Dayofweek.Monday:
                    serializer.Serialize(writer, "MONDAY");
                    return;
                case Dayofweek.Saturday:
                    serializer.Serialize(writer, "SATURDAY");
                    return;
                case Dayofweek.Sunday:
                    serializer.Serialize(writer, "SUNDAY");
                    return;
                case Dayofweek.Thursday:
                    serializer.Serialize(writer, "THURSDAY");
                    return;
                case Dayofweek.Tuesday:
                    serializer.Serialize(writer, "TUESDAY");
                    return;
                case Dayofweek.Wednesday:
                    serializer.Serialize(writer, "WEDNESDAY");
                    return;
            }
            throw new Exception("Cannot marshal type Dayofweek");
        }

        public static readonly DayofweekConverter Singleton = new DayofweekConverter();
    }

    internal class DstUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DstUnion) || t == typeof(DstUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    if (stringValue == "CENTRAL BUSINESS")
                    {
                        return new DstUnion { Enum = DstEnum.CentralBusiness };
                    }
                    long l;
                    if (Int64.TryParse(stringValue, out l))
                    {
                        return new DstUnion { Integer = l };
                    }
                    break;
            }
            throw new Exception("Cannot unmarshal type DstUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (DstUnion)untypedValue;
            if (value.Enum != null)
            {
                if (value.Enum == DstEnum.CentralBusiness)
                {
                    serializer.Serialize(writer, "CENTRAL BUSINESS");
                    return;
                }
            }
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value.ToString());
                return;
            }
            throw new Exception("Cannot marshal type DstUnion");
        }

        public static readonly DstUnionConverter Singleton = new DstUnionConverter();
    }

    internal class DstEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DstEnum) || t == typeof(DstEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "CENTRAL BUSINESS")
            {
                return DstEnum.CentralBusiness;
            }
            throw new Exception("Cannot unmarshal type DstEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (DstEnum)untypedValue;
            if (value == DstEnum.CentralBusiness)
            {
                serializer.Serialize(writer, "CENTRAL BUSINESS");
                return;
            }
            throw new Exception("Cannot marshal type DstEnum");
        }

        public static readonly DstEnumConverter Singleton = new DstEnumConverter();
    }

    internal class FloorConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Floor) || t == typeof(Floor?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "1 - BASEMENT":
                    return Floor.The1Basement;
                case "2 - FIRST FLOOR":
                    return Floor.The2FirstFloor;
                case "3 - SECOND FLOOR":
                    return Floor.The3SecondFloor;
                case "4 - OTHER":
                    return Floor.The4Other;
                case "5 - UNKNOWN":
                    return Floor.The5Unknown;
            }
            throw new Exception("Cannot unmarshal type Floor");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Floor)untypedValue;
            switch (value)
            {
                case Floor.The1Basement:
                    serializer.Serialize(writer, "1 - BASEMENT");
                    return;
                case Floor.The2FirstFloor:
                    serializer.Serialize(writer, "2 - FIRST FLOOR");
                    return;
                case Floor.The3SecondFloor:
                    serializer.Serialize(writer, "3 - SECOND FLOOR");
                    return;
                case Floor.The4Other:
                    serializer.Serialize(writer, "4 - OTHER");
                    return;
                case Floor.The5Unknown:
                    serializer.Serialize(writer, "5 - UNKNOWN");
                    return;
            }
            throw new Exception("Cannot marshal type Floor");
        }

        public static readonly FloorConverter Singleton = new FloorConverter();
    }

    internal class HateBiasConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(HateBias) || t == typeof(HateBias?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "50--OTHER BIAS INCIDENT (E.G. ANTI-AIDS VICTIM)":
                    return HateBias.The50OtherBiasIncidentEGAntiAidsVictim;
                case "88--DOMESTIC VIOLENCE":
                    return HateBias.The88DomesticViolence;
                case "89--GANG RELATED":
                    return HateBias.The89GangRelated;
                case "N--NO BIAS/NOT APPLICABLE":
                    return HateBias.NNoBiasNotApplicable;
            }
            throw new Exception("Cannot unmarshal type HateBias");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (HateBias)untypedValue;
            switch (value)
            {
                case HateBias.The50OtherBiasIncidentEGAntiAidsVictim:
                    serializer.Serialize(writer, "50--OTHER BIAS INCIDENT (E.G. ANTI-AIDS VICTIM)");
                    return;
                case HateBias.The88DomesticViolence:
                    serializer.Serialize(writer, "88--DOMESTIC VIOLENCE");
                    return;
                case HateBias.The89GangRelated:
                    serializer.Serialize(writer, "89--GANG RELATED");
                    return;
                case HateBias.NNoBiasNotApplicable:
                    serializer.Serialize(writer, "N--NO BIAS/NOT APPLICABLE");
                    return;
            }
            throw new Exception("Cannot marshal type HateBias");
        }

        public static readonly HateBiasConverter Singleton = new HateBiasConverter();
    }

    internal class OpeningConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Opening) || t == typeof(Opening?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "1 - DOOR":
                    return Opening.The1Door;
                case "2 - WINDOW":
                    return Opening.The2Window;
                case "3 - GARAGE":
                    return Opening.The3Garage;
                case "5 - OTHER":
                    return Opening.The5Other;
            }
            throw new Exception("Cannot unmarshal type Opening");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Opening)untypedValue;
            switch (value)
            {
                case Opening.The1Door:
                    serializer.Serialize(writer, "1 - DOOR");
                    return;
                case Opening.The2Window:
                    serializer.Serialize(writer, "2 - WINDOW");
                    return;
                case Opening.The3Garage:
                    serializer.Serialize(writer, "3 - GARAGE");
                    return;
                case Opening.The5Other:
                    serializer.Serialize(writer, "5 - OTHER");
                    return;
            }
            throw new Exception("Cannot marshal type Opening");
        }

        public static readonly OpeningConverter Singleton = new OpeningConverter();
    }

    internal class SideConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Side) || t == typeof(Side?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "1 - FRONT":
                    return Side.The1Front;
                case "2 - SIDE":
                    return Side.The2Side;
                case "3 - REAR":
                    return Side.The3Rear;
                case "4 - ROOF":
                    return Side.The4Roof;
                case "5 - OTHER":
                    return Side.The5Other;
                case "6 - UNKNOWN":
                    return Side.The6Unknown;
                case "???":
                    return Side.Empty;
            }
            throw new Exception("Cannot unmarshal type Side");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Side)untypedValue;
            switch (value)
            {
                case Side.The1Front:
                    serializer.Serialize(writer, "1 - FRONT");
                    return;
                case Side.The2Side:
                    serializer.Serialize(writer, "2 - SIDE");
                    return;
                case Side.The3Rear:
                    serializer.Serialize(writer, "3 - REAR");
                    return;
                case Side.The4Roof:
                    serializer.Serialize(writer, "4 - ROOF");
                    return;
                case Side.The5Other:
                    serializer.Serialize(writer, "5 - OTHER");
                    return;
                case Side.The6Unknown:
                    serializer.Serialize(writer, "6 - UNKNOWN");
                    return;
                case Side.Empty:
                    serializer.Serialize(writer, "???");
                    return;
            }
            throw new Exception("Cannot marshal type Side");
        }

        public static readonly SideConverter Singleton = new SideConverter();
    }

    internal class AgeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Age) || t == typeof(Age?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "18-25":
                    return Age.The1825;
                case "26-30":
                    return Age.The2630;
                case "31-40":
                    return Age.The3140;
                case "41-50":
                    return Age.The4150;
                case "51-60":
                    return Age.The5160;
                case "61-70":
                    return Age.The6170;
                case "ADULT (18+)":
                    return Age.Adult18;
                case "JUVENILE (UNDER 18)":
                    return Age.JuvenileUnder18;
                case "OVER 70":
                    return Age.Over70;
                case "UNDER 18":
                    return Age.Under18;
                case "UNKNOWN":
                    return Age.Unknown;
            }
            throw new Exception("Cannot unmarshal type Age");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Age)untypedValue;
            switch (value)
            {
                case Age.The1825:
                    serializer.Serialize(writer, "18-25");
                    return;
                case Age.The2630:
                    serializer.Serialize(writer, "26-30");
                    return;
                case Age.The3140:
                    serializer.Serialize(writer, "31-40");
                    return;
                case Age.The4150:
                    serializer.Serialize(writer, "41-50");
                    return;
                case Age.The5160:
                    serializer.Serialize(writer, "51-60");
                    return;
                case Age.The6170:
                    serializer.Serialize(writer, "61-70");
                    return;
                case Age.Adult18:
                    serializer.Serialize(writer, "ADULT (18+)");
                    return;
                case Age.JuvenileUnder18:
                    serializer.Serialize(writer, "JUVENILE (UNDER 18)");
                    return;
                case Age.Over70:
                    serializer.Serialize(writer, "OVER 70");
                    return;
                case Age.Under18:
                    serializer.Serialize(writer, "UNDER 18");
                    return;
                case Age.Unknown:
                    serializer.Serialize(writer, "UNKNOWN");
                    return;
            }
            throw new Exception("Cannot marshal type Age");
        }

        public static readonly AgeConverter Singleton = new AgeConverter();
    }

    internal class EthnicityConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Ethnicity) || t == typeof(Ethnicity?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "HISPANIC ORIGIN":
                    return Ethnicity.HispanicOrigin;
                case "NOT OF HISPANIC ORIG":
                    return Ethnicity.NotOfHispanicOrig;
                case "UNKNOWN":
                    return Ethnicity.Unknown;
            }
            throw new Exception("Cannot unmarshal type Ethnicity");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Ethnicity)untypedValue;
            switch (value)
            {
                case Ethnicity.HispanicOrigin:
                    serializer.Serialize(writer, "HISPANIC ORIGIN");
                    return;
                case Ethnicity.NotOfHispanicOrig:
                    serializer.Serialize(writer, "NOT OF HISPANIC ORIG");
                    return;
                case Ethnicity.Unknown:
                    serializer.Serialize(writer, "UNKNOWN");
                    return;
            }
            throw new Exception("Cannot marshal type Ethnicity");
        }

        public static readonly EthnicityConverter Singleton = new EthnicityConverter();
    }

    internal class GenderConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Gender) || t == typeof(Gender?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "FEMALE":
                    return Gender.Female;
                case "MALE":
                    return Gender.Male;
                case "UNKNOWN":
                    return Gender.Unknown;
            }
            throw new Exception("Cannot unmarshal type Gender");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Gender)untypedValue;
            switch (value)
            {
                case Gender.Female:
                    serializer.Serialize(writer, "FEMALE");
                    return;
                case Gender.Male:
                    serializer.Serialize(writer, "MALE");
                    return;
                case Gender.Unknown:
                    serializer.Serialize(writer, "UNKNOWN");
                    return;
            }
            throw new Exception("Cannot marshal type Gender");
        }

        public static readonly GenderConverter Singleton = new GenderConverter();
    }

    internal class RaceConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Race) || t == typeof(Race?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "AMERICAN INDIAN/ALAS":
                    return Race.AmericanIndianAlas;
                case "ASIAN/PACIFIC ISLAND":
                    return Race.AsianPacificIsland;
                case "BLACK":
                    return Race.Black;
                case "UNKNOWN":
                    return Race.Unknown;
                case "WHITE":
                    return Race.White;
            }
            throw new Exception("Cannot unmarshal type Race");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Race)untypedValue;
            switch (value)
            {
                case Race.AmericanIndianAlas:
                    serializer.Serialize(writer, "AMERICAN INDIAN/ALAS");
                    return;
                case Race.AsianPacificIsland:
                    serializer.Serialize(writer, "ASIAN/PACIFIC ISLAND");
                    return;
                case Race.Black:
                    serializer.Serialize(writer, "BLACK");
                    return;
                case Race.Unknown:
                    serializer.Serialize(writer, "UNKNOWN");
                    return;
                case Race.White:
                    serializer.Serialize(writer, "WHITE");
                    return;
            }
            throw new Exception("Cannot marshal type Race");
        }

        public static readonly RaceConverter Singleton = new RaceConverter();
    }

    internal class TheftCodeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TheftCode) || t == typeof(TheftCode?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "23A-POCKET-PICKING":
                    return TheftCode.The23APocketPicking;
                case "23B-PURSE-SNATCHING":
                    return TheftCode.The23BPurseSnatching;
                case "23C-SHOPLIFTING":
                    return TheftCode.The23CShoplifting;
                case "23D-THEFT FROM BUILDING":
                    return TheftCode.The23DTheftFromBuilding;
                case "23F-THEFT FROM MOTOR VEHICLE":
                    return TheftCode.The23FTheftFromMotorVehicle;
                case "23G-THEFT OF MOTOR VEHICLE PARTS OR ACCESSORIES":
                    return TheftCode.The23GTheftOfMotorVehiclePartsOrAccessories;
                case "23H-ALL OTHER LARCENY":
                    return TheftCode.The23HAllOtherLarceny;
                case "24I-THEFT OF LICENSE PLATE":
                    return TheftCode.The24ITheftOfLicensePlate;
                case "24O-MOTOR VEHICLE THEFT":
                    return TheftCode.The24OMotorVehicleTheft;
            }
            throw new Exception("Cannot unmarshal type TheftCode");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TheftCode)untypedValue;
            switch (value)
            {
                case TheftCode.The23APocketPicking:
                    serializer.Serialize(writer, "23A-POCKET-PICKING");
                    return;
                case TheftCode.The23BPurseSnatching:
                    serializer.Serialize(writer, "23B-PURSE-SNATCHING");
                    return;
                case TheftCode.The23CShoplifting:
                    serializer.Serialize(writer, "23C-SHOPLIFTING");
                    return;
                case TheftCode.The23DTheftFromBuilding:
                    serializer.Serialize(writer, "23D-THEFT FROM BUILDING");
                    return;
                case TheftCode.The23FTheftFromMotorVehicle:
                    serializer.Serialize(writer, "23F-THEFT FROM MOTOR VEHICLE");
                    return;
                case TheftCode.The23GTheftOfMotorVehiclePartsOrAccessories:
                    serializer.Serialize(writer, "23G-THEFT OF MOTOR VEHICLE PARTS OR ACCESSORIES");
                    return;
                case TheftCode.The23HAllOtherLarceny:
                    serializer.Serialize(writer, "23H-ALL OTHER LARCENY");
                    return;
                case TheftCode.The24ITheftOfLicensePlate:
                    serializer.Serialize(writer, "24I-THEFT OF LICENSE PLATE");
                    return;
                case TheftCode.The24OMotorVehicleTheft:
                    serializer.Serialize(writer, "24O-MOTOR VEHICLE THEFT");
                    return;
            }
            throw new Exception("Cannot marshal type TheftCode");
        }

        public static readonly TheftCodeConverter Singleton = new TheftCodeConverter();
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

    internal class UcrGroupConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(UcrGroup) || t == typeof(UcrGroup?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "AGGRAVATED ASSAULTS":
                    return UcrGroup.AggravatedAssaults;
                case "BURGLARY/BREAKING ENTERING":
                    return UcrGroup.BurglaryBreakingEntering;
                case "HOMICIDE":
                    return UcrGroup.Homicide;
                case "PART 2 MINOR":
                    return UcrGroup.Part2Minor;
                case "RAPE":
                    return UcrGroup.Rape;
                case "ROBBERY":
                    return UcrGroup.Robbery;
                case "THEFT":
                    return UcrGroup.Theft;
                case "UNAUTHORIZED USE":
                    return UcrGroup.UnauthorizedUse;
            }
            throw new Exception("Cannot unmarshal type UcrGroup");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (UcrGroup)untypedValue;
            switch (value)
            {
                case UcrGroup.AggravatedAssaults:
                    serializer.Serialize(writer, "AGGRAVATED ASSAULTS");
                    return;
                case UcrGroup.BurglaryBreakingEntering:
                    serializer.Serialize(writer, "BURGLARY/BREAKING ENTERING");
                    return;
                case UcrGroup.Homicide:
                    serializer.Serialize(writer, "HOMICIDE");
                    return;
                case UcrGroup.Part2Minor:
                    serializer.Serialize(writer, "PART 2 MINOR");
                    return;
                case UcrGroup.Rape:
                    serializer.Serialize(writer, "RAPE");
                    return;
                case UcrGroup.Robbery:
                    serializer.Serialize(writer, "ROBBERY");
                    return;
                case UcrGroup.Theft:
                    serializer.Serialize(writer, "THEFT");
                    return;
                case UcrGroup.UnauthorizedUse:
                    serializer.Serialize(writer, "UNAUTHORIZED USE");
                    return;
            }
            throw new Exception("Cannot marshal type UcrGroup");
        }

        public static readonly UcrGroupConverter Singleton = new UcrGroupConverter();
    }

    internal class WeaponsConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Weapons) || t == typeof(Weapons?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "11 - FIREARM (TYPE NOT STATED)":
                    return Weapons.The11FirearmTypeNotStated;
                case "12 - HANDGUN":
                    return Weapons.The12Handgun;
                case "15B - SEMI-AUTOMATIC ASSAULT FIREARM":
                    return Weapons.The15BSemiAutomaticAssaultFirearm;
                case "20 - KNIFE/CUTTING INSTRUMENT (ICEPICK, AX, ETC.)":
                    return Weapons.The20KnifeCuttingInstrumentIcepickAxEtc;
                case "30 - BLUNT OBJECT (CLUB, HAMMER, ETC.)":
                    return Weapons.The30BluntObjectClubHammerEtc;
                case "40 - PERSONAL WEAPONS (HANDS, FEET, TEETH, ETC.)":
                    return Weapons.The40PersonalWeaponsHandsFeetTeethEtc;
                case "80 - OTHER WEAPON":
                    return Weapons.The80OtherWeapon;
                case "85 - ASPHYXIATION (BY DROWNING, STRANGULATION, SUFFOCATION)":
                    return Weapons.The85AsphyxiationByDrowningStrangulationSuffocation;
                case "99 - NONE":
                    return Weapons.The99None;
                case "U - UNKNOWN":
                    return Weapons.UUnknown;
            }
            throw new Exception("Cannot unmarshal type Weapons");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Weapons)untypedValue;
            switch (value)
            {
                case Weapons.The11FirearmTypeNotStated:
                    serializer.Serialize(writer, "11 - FIREARM (TYPE NOT STATED)");
                    return;
                case Weapons.The12Handgun:
                    serializer.Serialize(writer, "12 - HANDGUN");
                    return;
                case Weapons.The15BSemiAutomaticAssaultFirearm:
                    serializer.Serialize(writer, "15B - SEMI-AUTOMATIC ASSAULT FIREARM");
                    return;
                case Weapons.The20KnifeCuttingInstrumentIcepickAxEtc:
                    serializer.Serialize(writer, "20 - KNIFE/CUTTING INSTRUMENT (ICEPICK, AX, ETC.)");
                    return;
                case Weapons.The30BluntObjectClubHammerEtc:
                    serializer.Serialize(writer, "30 - BLUNT OBJECT (CLUB, HAMMER, ETC.)");
                    return;
                case Weapons.The40PersonalWeaponsHandsFeetTeethEtc:
                    serializer.Serialize(writer, "40 - PERSONAL WEAPONS (HANDS, FEET, TEETH, ETC.)");
                    return;
                case Weapons.The80OtherWeapon:
                    serializer.Serialize(writer, "80 - OTHER WEAPON");
                    return;
                case Weapons.The85AsphyxiationByDrowningStrangulationSuffocation:
                    serializer.Serialize(writer, "85 - ASPHYXIATION (BY DROWNING, STRANGULATION, SUFFOCATION)");
                    return;
                case Weapons.The99None:
                    serializer.Serialize(writer, "99 - NONE");
                    return;
                case Weapons.UUnknown:
                    serializer.Serialize(writer, "U - UNKNOWN");
                    return;
            }
            throw new Exception("Cannot marshal type Weapons");
        }

        public static readonly WeaponsConverter Singleton = new WeaponsConverter();
    }
}
