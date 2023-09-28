using System.Reflection;
using MusicPlaylist.BusinessLogic.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MusicPlaylist.BusinessLogic
{
    public class SongDataLoader
    {
        public List<Song>? LoadSongs(string path)
        {
            try
            {
                string songsJson = File.ReadAllText(path);

                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                };

                return JsonConvert.DeserializeObject<List<Song>>(songsJson, settings);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
                return null;
            }
        }
    }
}