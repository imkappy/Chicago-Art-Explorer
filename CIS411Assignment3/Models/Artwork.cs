namespace CIS411Assignment3.Models
{
    public class Artwork
    {
        public int id { get; set; }
        public string title { get; set; }
        public string artist_title { get; set; }
        public string image_id { get; set; }
        public string date_display { get; set; }
        public Thumbnail thumbnail { get; set; }
        public string medium_display { get; set; }
    }

    /// Represents the API response structure containing a list of artworks.
    public class ArtworksResponse
    {
        public List<Artwork> Data { get; set; }
    }

    /// Represents metadata for a low-quality preview image.
    public class Thumbnail
    {
        public string lqip { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string alt_text { get; set; }
    }
}
