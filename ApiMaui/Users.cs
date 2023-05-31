using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ApiMaui
{
    public partial class Users
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        public char FirstLetter
        {
            get
            {
                return Name[0];
            }
            set
            {
                Name = value + Name.Substring(1);
            }
        }
    }

    public class UserNameComparer : IComparer<Users>
    {
        public int Compare(Users x, Users y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

    public partial class Address
    {
        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("suite")]
        public string Suite { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }

        [JsonProperty("geo")]
        public Geo Geo { get; set; }
    }

    public partial class Geo
    {
        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("lng")]
        public string Lng { get; set; }
    }

    public partial class Company
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("catchPhrase")]
        public string CatchPhrase { get; set; }

        [JsonProperty("bs")]
        public string Bs { get; set; }
    }

    public partial class Users
    {
        public static List<Users> FromJson(string json) => JsonConvert.DeserializeObject<List<Users>>(json, ApiMaui.Converterr.Settings);
    }

    public static class Serializee
    {
        public static string ToJson(this List<Users> self) => JsonConvert.SerializeObject(self, ApiMaui.Converterr.Settings);
    }

    internal static class Converterr
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}

