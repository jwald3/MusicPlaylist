namespace MusicPlaylist.BusinessLogic.Models
{
    public class Song
    {
        public string? SongName { get; set; }
        public string? ArtistName { get; set; }
        public string? AlbumName { get; set; }
        public int Length { get; set; }

        public Song() {}

        public Song(string songName, string artistName, string albumName, int length)
        {
            SongName = songName;
            ArtistName = artistName;
            AlbumName = albumName;
            Length = length;
        }

        private string SongLengthToStringFormat(int length)
        {
            int minutes = length / 60;
            int seconds = length % 60;

            return $"{minutes}:{seconds}";
        }

        public override string ToString()
        {
            return $"Song: {SongName}, Artist: {ArtistName}, Album: {AlbumName}, Length: {SongLengthToStringFormat(Length)}";
        }
    }
}