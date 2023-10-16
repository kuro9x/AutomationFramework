namespace AppService.Models
{
    public class PhotoResponseModel
    {
        public string Id { get; set; }
        public string Slug { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime? Promoted_at { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public bool Liked_by_user { get; set; }
    }
}
