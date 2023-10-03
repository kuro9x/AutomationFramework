using Newtonsoft.Json;

public class BookObject
{
    public class Book
    {
        [JsonProperty("isbn")]
        public string? Isbn { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("subTitle")]
        public string? SubTitle { get; set; }

        [JsonProperty("author")]
        public string? Author { get; set; }

        [JsonProperty("publish_date")]
        public DateTime PublishDate { get; set; }

        [JsonProperty("publisher")]
        public string? Publisher { get; set; }

        [JsonProperty("pages")]
        public int Pages { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("website")]
        public string? Website { get; set; }
    }

    public class Books
    {
        [JsonProperty("books")]
        public List<Book>? ListBook { get; set; }
    }

}