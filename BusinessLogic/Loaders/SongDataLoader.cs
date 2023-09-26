using MusicPlaylist.BusinessLogic.Models;
using Newtonsoft.Json;

namespace MusicPlaylist.BusinessLogic
{
    public class SongDataLoader
    {
        public List<Song>? LoadSongs(string path)
        {
            string songsJson = File.ReadAllText(path);
            return !string.IsNullOrEmpty(songsJson) ? JsonConvert.DeserializeObject<List<Song>>(songsJson) : null;
        }
    }
}