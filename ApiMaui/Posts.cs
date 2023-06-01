using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ApiMaui
{
    public partial class Posts
    {
        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }

    public partial class Posts
    {
        public static List<Posts> FromJson(string json) => JsonConvert.DeserializeObject<List<Posts>>(json, ApiMaui.ConverterPosts.Settings);
    }

    public static class SerializePosts
    {
        public static string ToJson(this List<Posts> self) => JsonConvert.SerializeObject(self, ApiMaui.ConverterPosts.Settings);
    }

    internal static class ConverterPosts
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

