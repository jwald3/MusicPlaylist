using MusicPlaylist.BusinessLogic;
using MusicPlaylist.BusinessLogic.Collections;
using MusicPlaylist.BusinessLogic.Models;


namespace MusicPlaylist
{
    class Program
    {
        static void DisplayMenu(List<string> items, int selectedItemIndex)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (i == selectedItemIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                }

                Console.WriteLine(items[i]);

                if (i == selectedItemIndex)
                {
                    Console.ResetColor();
                }
            }
        }

        static void HandleSelection(string selectedItem, Playlist playlist)
        {
            switch (selectedItem)
            {
                case "See all songs":
                    Console.Clear();
                    Console.WriteLine("All songs:");
                    Console.WriteLine();
                    playlist.PrintSongs();
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "Start playlist":
                    Console.Clear();
                    Console.WriteLine("Starting playlist...");
                    Console.WriteLine();
                    playlist.StartPlaylist();
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "Get current song":
                    Console.Clear();
                    Console.WriteLine("Current song:");
                    Console.WriteLine();
                    Song? song = playlist.GetNowPlaying();
                    Console.WriteLine(song is null ? "No song is playing" : song.ToString());
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "Next song":
                    Console.Clear();
                    Console.WriteLine("Next song:");
                    Console.WriteLine();
                    playlist.SkipSong();
                    Song? nextSong = playlist.GetNowPlaying();
                    Console.WriteLine(nextSong is null ? "No song is playing" : nextSong.ToString());
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "Previous song":
                    Console.Clear();
                    Console.WriteLine("Previous song:");
                    Console.WriteLine();
                    playlist.GoBackSong();
                    Song? previousSong = playlist.GetNowPlaying();
                    Console.WriteLine(previousSong is null ? "No song is playing" : previousSong.ToString());
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "Exit":
                    Environment.Exit(0);
                    break;
            }
        }

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

            while (true)
            {
                Console.Clear();
                DisplayMenu(menuItems, currentMenuIndex);

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        currentMenuIndex = (currentMenuIndex == 0) ? menuItems.Count - 1 : currentMenuIndex - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        currentMenuIndex = (currentMenuIndex == menuItems.Count - 1) ? 0 : currentMenuIndex + 1;
                        break;
                    case ConsoleKey.Enter:
                        HandleSelection(menuItems[currentMenuIndex], playlist);
                        break;
                }

            }

        }
    }
}