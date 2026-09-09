namespace MusicLibrary
{
    public class Track
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }

        public Track(string title, string artist, int duration, string genre)
        {
            Title = title;
            Artist = artist;
            Duration = duration;
            Genre = genre;
        }
        public override string ToString()
        {
            return $"Track: '{Title}' by {Artist} - {Duration}s [{Genre}]";
        }
    }
}
