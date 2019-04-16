namespace ProfileApp.API.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string url { get; set; }
        public bool isMain  { get; set; }
        public string description { get; set; }
        public User user { get; set; }
        public int userId { get; set; }
    }
}