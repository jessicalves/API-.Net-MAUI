using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ApiMaui
{
	public partial class Photos
	{
        [JsonProperty("albumId")]
        public long AlbumId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("thumbnailUrl")]
        public Uri ThumbnailUrl { get; set; }
    }

    public partial class Photos
    {
        public static List<Photos> FromJson(string json) => JsonConvert.DeserializeObject<List<Photos>>(json, ApiMaui.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<Photos> self) => JsonConvert.SerializeObject(self, ApiMaui.Converter.Settings);
    }

    internal static class Converter
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

