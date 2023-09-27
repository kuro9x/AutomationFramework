using Newtonsoft.Json;

public class UserObject
{
    public class UserInfo
    {
        [JsonProperty("userId")]
        public string? UserId { get; set; }

        [JsonProperty("username")]
        public string? Username { get; set; }

        [JsonProperty("books")]
        public List<BookObject.Books>? Books { get; set; }
    }

}