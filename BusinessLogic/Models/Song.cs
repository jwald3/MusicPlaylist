namespace MusicPlaylist.BusinessLogic.Models
{
    public class Song
    {
        public string? SongName { get; set; }
        public string? ArtistName { get; set; }
        public string? AlbumName { get; set; }
        public TimeSpan Length { get; set; }

        public Song() {}

        public Song(string songName, string artistName, string albumName, TimeSpan length)
        {
            SongName = songName;
            ArtistName = artistName;
            AlbumName = albumName;
            Length = length;
        }

        private string SongLengthToStringFormat(TimeSpan length)
        {
            return $"{length.Minutes}:{length.Seconds:D2}";
        }

        public override string ToString()
        {
            return $"Song: {SongName}, Artist: {ArtistName}, Album: {AlbumName}, Length: {SongLengthToStringFormat(Length)}";
        }
    }
}