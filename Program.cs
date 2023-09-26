using System;
using MusicPlaylist.BusinessLogic;
using MusicPlaylist.BusinessLogic.Collections;
using MusicPlaylist.BusinessLogic.Models;
using Newtonsoft.Json;

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


            char response = new char();
            System.Console.WriteLine("");

            while (response != 'q')
            {
                Console.WriteLine("Welcome to your MP3 player!");
                Console.WriteLine("Here are your actions:");
                Console.WriteLine("a - See all songs");
                Console.WriteLine("s - Start playlist");
                Console.WriteLine("p - Get song playing");
                Console.WriteLine("n - Go forward one song");
                Console.WriteLine("b - Go back one song");
                Console.WriteLine("q - Quit the program");

                response = Console.ReadKey().KeyChar;

                System.Console.WriteLine("");

                switch(response)
                {
                    case 'a':
                    case 'A':
                        playlist.PrintSongs();
                        break;
                    case 's':
                    case 'S':
                        playlist.StartPlaylist();
                        break;
                    case 'p':
                    case 'P':
                        Song? nowPlaying = playlist.GetNowPlaying();
                        System.Console.WriteLine(nowPlaying);
                        break;
                    case 'n':
                    case 'N':
                        playlist.SkipSong();
                        break;
                    case 'b':
                    case 'B':
                        playlist.GoBackSong();
                        break;
                    case 'q':
                    case 'Q':
                        break;
                    default:
                        continue;

                }
            }

        }
    }
}