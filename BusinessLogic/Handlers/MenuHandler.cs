using System.Text;
using MusicPlaylist.BusinessLogic.Collections;

namespace MusicPlaylist.BusinessLogic.Handlers
{
    public class MenuHandler
    {
        private readonly Playlist _playlist;

        public MenuHandler(Playlist playlist)
        {
            _playlist = playlist;
        }

        public void DisplayMenu(List<string> items, int selectedItemIndex)
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

        public void HandleSelection(string selectedItem, Playlist playlist)
        {
            Dictionary<string, Action> actions = new Dictionary<string, Action>
            {
                ["See all songs"] = () =>
                {
                    var allSongs = new StringBuilder();
                    using (var writer = new StringWriter(allSongs))
                    {
                        playlist.PrintSongs(writer);
                    }
                    DisplayMessageAndWaitForKey("All songs:", allSongs.ToString());
                },
                ["Start playlist"] = () =>
                {
                    playlist.StartPlaylist();
                    DisplayMessageAndWaitForKey("Starting playlist...");
                },
                ["Get current song"] = () =>
                {
                    var song = playlist.GetNowPlaying();
                    var message = song is null ? "No song is playing" : song.ToString();
                    DisplayMessageAndWaitForKey("Current song:", message);
                },
                ["Next song"] = () =>
                {
                    playlist.SkipSong();
                    var song = playlist.GetNowPlaying();
                    var message = song is null ? "No song is playing" : song.ToString();
                    DisplayMessageAndWaitForKey("Next song:", message);
                },
                ["Previous song"] = () =>
                {
                    playlist.GoBackSong();
                    var song = playlist.GetNowPlaying();
                    var message = song is null ? "No song is playing" : song.ToString();
                    DisplayMessageAndWaitForKey("Previous song:", message);
                },
                ["Exit"] = () => Environment.Exit(0)
            };

            if (actions.TryGetValue(selectedItem, out var action))
                action();
            else
                DisplayMessageAndWaitForKey("Invalid selection");
        }

        static void DisplayMessageAndWaitForKey(string title, string message = "")
        {
            Console.Clear();
            Console.WriteLine(title);
            Console.WriteLine();
            if (!string.IsNullOrWhiteSpace(message))
                Console.WriteLine(message);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}