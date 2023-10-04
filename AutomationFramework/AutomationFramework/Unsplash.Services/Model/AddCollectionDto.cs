using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCore.Unsplash.Services.Model
{
    public class AddCollectionDto
    {
         public class Links
        {
            [JsonProperty("self")]
            public string? Self { get; set; }

            [JsonProperty("html")]
            public string? Html { get; set; }

            [JsonProperty("photos")]
            public string? Photos { get; set; }
        }

        public class Collection
        {
            [JsonProperty("id")]
            public string? Id { get; set; }

            [JsonProperty("title")]
            public string? Title { get; set; }

            [JsonProperty("description")]
            public string? Description { get; set; }

            [JsonProperty("published_at")]
            public DateTime PublishedAt { get; set; }

            [JsonProperty("last_collected_at")]
            public DateTime LastCollectedAt { get; set; }

            [JsonProperty("updated_at")]
            public DateTime UpdatedAt { get; set; }

            [JsonProperty("featured")]
            public bool Featured { get; set; }

            [JsonProperty("total_photos")]
            public int TotalPhotos { get; set; }

            [JsonProperty("private")]
            public bool Private { get; set; }

            [JsonProperty("share_key")]
            public string? ShareKey { get; set; }

            [JsonProperty("cover_photo")]
            public object? CoverPhoto { get; set; }

            [JsonProperty("user")]
            public object? User { get; set; }

            [JsonProperty("links")]
            public Links? Links { get; set; }
        }


    }
}
