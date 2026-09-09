namespace MusicLibrary
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Create a new music library
            var library = new MusicLibrary("My Library", 5);

            //Add some tracks
            // Initialize some tracks
            var track1 = new Track("Bohemian Rhapsody", "Queen", 354, "Rock");
            var track2 = new Track("Billie Jean", "Michael Jackson", 294, "Pop");
            var track3 = new Track("Imagine", "John Lennon", 183, "Pop");
            var track4 = new Track("Smells Like Teen Spirit", "Nirvana", 301, "Grunge");
            var track5 = new Track("Lose Yourself", "Eminem", 326, "Hip-Hop");
            var track6 = new Track("Bohemian Rhapsody", "Queen", 354, "Rock"); // Duplicate
            var track7 = new Track("Enter Sandman", "Metallica", 331, "Metal");

            //Add first 5 unique tracks
            library.AddTrack(track1);
            library.AddTrack(track2);
            library.AddTrack(track3);
            library.AddTrack(track4);
            library.AddTrack(track5);

            Console.WriteLine($"Track count after adding 5 unique tracks: {library.GetTracksCount()}");
            //Output: Track count after adding 5 unique tracks: 5

            //Try to add a duplicate track
            library.AddTrack(track6);

            Console.WriteLine($"Track count after trying to add a duplicate track: {library.GetTracksCount()}");
            //Output: Track count after trying to add a duplicate track: 5

            //Add a new unique track
            library.AddTrack(track7); //Should be skipped

            Console.WriteLine($"Track count after trying to add a track beyond capacity: {library.GetTracksCount()}");
            //Output: Track count after trying to add a track beyond capacity: 5

            //Remove existing track
            library.RemoveTrack("Smells Like Teen Spirit", "Nirvana");
            //Returns True (Track is removed)

            //Remove non-existing track
            library.RemoveTrack("Enter Sandman", "Metallica");
            //Returns False

            //Get the longest track
            var longestTrack = library.GetLongestTrack();
            Console.WriteLine($"Longest track: {longestTrack.Title} by {longestTrack.Artist} - {longestTrack.Duration}s [{longestTrack.Genre}]");
            //Output: Longest track: Bohemian Rhapsody by Queen - 354s [Rock]

            //Get track details
            var trackDetails = library.GetTrackDetails("Imagine", "John Lennon");
            Console.WriteLine(trackDetails);
            //Output: Track: 'Imagine' by John Lennon - 183s [Pop]

            //Get tracks count
            Console.WriteLine($"Total tracks: {library.GetTracksCount()}");
            //Output: Total tracks: 4

            //Get tracks by genre
            var popTracks = library.GetTracksByGenre("Pop");
            foreach (var track in popTracks)
            {
                Console.WriteLine($"Track: {track.Title} by {track.Artist} - {track.Duration}s [{track.Genre}]");
            }
            //Output:
            //Track: Imagine by John Lennon -183s[Pop]
            //Track: Billie Jean by Michael Jackson - 294s[Pop]

            //Print library report
            Console.WriteLine(library.LibraryReport());
            //Output:
            //Music Library: My Library
            //Tracks capacity: 5
            //Number of tracks added: 4
            //Tracks:
            //-Track: 'Bohemian Rhapsody' by Queen -354s[Rock]
            //- Track: 'Lose Yourself' by Eminem -326s[Hip - Hop]
            //- Track: 'Billie Jean' by Michael Jackson - 294s[Pop]
            //- Track: 'Imagine' by John Lennon - 183s[Pop]
        }
    }
}
