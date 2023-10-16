namespace AppService.Models
{
    public class CollectionResponseModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Published_at { get; set; }
        public DateTime Updated_at { get; set; }
        public bool Featured { get; set; }
        public int Total_photos { get; set; }
    }
}
