namespace ProfileApp.API.Dtos
{
    public class PhotoDetailsDto
    {
        public int Id { get; set; }
        public string url { get; set; }
        public bool isMain  { get; set; }
        public string description { get; set; }
    }
}