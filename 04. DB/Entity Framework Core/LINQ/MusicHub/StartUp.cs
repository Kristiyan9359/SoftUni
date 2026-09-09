namespace MusicHub
{
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);


            //string result = ExportAlbumsInfo(context, 9);

            string result = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate,
                    ProducerName = a.Producer!.Name,
                    Songs = a.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            Price = s.Price,
                            WriterName = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.WriterName)
                        .ToList(),
                    AlbumPrice = a.Price
                })
                .ToList()
                .OrderByDescending(a => a.AlbumPrice)
                .ToList();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");
                int songNumber = 1;
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{songNumber}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.Price:F2}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                    songNumber++;
                }
                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:F2}");

            }
            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var songs = context
                .Songs
                .Select(s => new
                {
                    s.Name,
                    PerformersNames = s.SongPerformers
                        .Select(sp => new
                        {
                            sp.Performer.FirstName,
                            sp.Performer.LastName,
                        })
                        .OrderBy(sp => sp.FirstName)
                        .ThenBy(sp => sp.LastName)
                        .ToArray(),
                    WriterName = s.Writer.Name,
                    AlbumProducerName =
                        s.Album != null ? (s.Album.Producer != null ? s.Album.Producer.Name : null) : null,
                    s.Duration,
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)
                .ToArray();

            int songNumber = 1;
            foreach (var song in songs)
            {
                sb
                    .AppendLine($"-Song #{songNumber++}")
                    .AppendLine($"---SongName: {song.Name}")
                    .AppendLine($"---Writer: {song.WriterName}");
                foreach (var performer in song.PerformersNames)
                {
                    sb
                        .AppendLine($"---Performer: {performer.FirstName} {performer.LastName}");
                }

                sb
                    .AppendLine($"---AlbumProducer: {song.AlbumProducerName}")
                    .AppendLine($"---Duration: {song.Duration.ToString("c")}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
