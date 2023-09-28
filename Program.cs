using MusicPlaylist.BusinessLogic;
using MusicPlaylist.BusinessLogic.Collections;
using MusicPlaylist.BusinessLogic.Handlers;
using MusicPlaylist.BusinessLogic.Models;


namespace MusicPlaylist
{
    class Program
    {
        static void Main(string[] args)
        {
            SongDataLoader songDataLoader = new SongDataLoader();
            List<Song>? songs = songDataLoader.LoadSongs("./Data/Songs.json");

            Playlist playlist = new Playlist();

            if (songs?.Count > 0)
            {
                playlist.AddRange(songs);
            }

            List<string> menuItems = new List<string>
            {
                "See all songs",
                "Start playlist",
                "Get current song",
                "Next song",
                "Previous song",
                "Exit"
            };

            int currentMenuIndex = 0;

            var menuHandler = new MenuHandler(playlist);

            while (true)
            {
                Console.Clear();
                menuHandler.DisplayMenu(menuItems, currentMenuIndex);

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        currentMenuIndex = (currentMenuIndex + menuItems.Count - 1) % menuItems.Count;
                        break;
                    case ConsoleKey.DownArrow:
                        currentMenuIndex = (currentMenuIndex + menuItems.Count + 1) % menuItems.Count;
                        break;
                    case ConsoleKey.Enter:
                        menuHandler.HandleSelection(menuItems[currentMenuIndex], playlist);
                        break;
                }
            }
        }
    }
}