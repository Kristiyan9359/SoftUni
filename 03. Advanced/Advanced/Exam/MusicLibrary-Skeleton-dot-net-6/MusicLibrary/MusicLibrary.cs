namespace MusicLibrary
{
    public class MusicLibrary
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Track> Tracks { get; set; }

        public MusicLibrary(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Tracks = new List<Track>();
        }

        public void AddTrack(Track track)
        {
            bool alreadyExists = Tracks.Any(t => t.Title == track.Title && t.Artist == track.Artist);

            if (!alreadyExists && Tracks.Count < Capacity)
            {
                Tracks.Add(track);
            }
        }

        public bool RemoveTrack(string title, string artist)
        {
            var trackToRemove = Tracks.FirstOrDefault(t => t.Title == title && t.Artist == artist);
            if (trackToRemove != null)
            {
                Tracks.Remove(trackToRemove);
                return true;
            }
            return false;
        }

        public Track GetLongestTrack()
        {
            return Tracks.OrderByDescending(t => t.Duration).First();
        }

        public string GetTrackDetails(string title, string artist)
        {
            var trackDetails = Tracks.FirstOrDefault(t => t.Title == title && t.Artist == artist);
            return trackDetails?.ToString() ?? "Track not found!";
        }

        public int GetTracksCount()
        {
            return Tracks.Count;
        }

        public List<Track> GetTracksByGenre(string genre)
        {
            return Tracks
                .Where(t => t.Genre == genre)
                .OrderBy(t => t.Duration)
                .ToList();
        }

        public string LibraryReport()
        {
            var orderedTracks = Tracks.OrderByDescending(t => t.Duration);

            return $"Music Library: {Name}\n" +
                   $"Tracks capacity: {Capacity}\n" +
                   $"Number of tracks added: {Tracks.Count}\n" +
                   "Tracks:\n" +
                   string.Join("\n", orderedTracks.Select(t => $"-{t}"));
        }
    }

}
