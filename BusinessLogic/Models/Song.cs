namespace MusicPlaylist.BusinessLogic.Models
{
    public class Song
    {
        public string SongName { get; }
        public string ArtistName { get; }
        public string AlbumName { get; }
        public TimeSpan Length { get; }

        public Song() : this("Unknown", "Unknown", "Unknown", TimeSpan.Zero) { } 

        public Song(string songName, string artistName, string albumName, TimeSpan length)
        {
            SongName = songName ?? throw new ArgumentNullException(nameof(songName));
            ArtistName = artistName ?? throw new ArgumentNullException(nameof(artistName));
            AlbumName = albumName ?? throw new ArgumentNullException(nameof(albumName));
            Length = length;
        }

        private string SongLengthToStringFormat(TimeSpan length) => $"{length.Minutes}:{length.Seconds:D2}";

        public override string ToString() =>
            $"Song: {SongName ?? "Unknown"}, Artist: {ArtistName ?? "Unknown"}, Album: {AlbumName ?? "Unknown" }, Length: {SongLengthToStringFormat(Length)}";
        
    }
}