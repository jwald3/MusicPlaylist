using System;
using MusicPlaylist.BusinessLogic.Collections;
using MusicPlaylist.BusinessLogic.Models;

namespace MusicPlaylist
{
    class Program
    {
        static void Main(string[] args)
        {
            Song song1 = new Song {
                SongName = "FE!N",
                ArtistName = "Travis Scott",
                AlbumName = "UTOPIA",
                Length = 192
            };

            Song song2 = new Song 
            {
                SongName = "Stick Talk",
                ArtistName = "Future",
                AlbumName = "DS2",
                Length = 173
            };

            Song song3 = new Song 
            {
                SongName = "MIA (feat. Drake)",
                ArtistName = "Bad Bunny",
                AlbumName = "X 100pre",
                Length = 212
            };
            
            Playlist playlist = new Playlist();
            playlist.AddToEnd(song1);
            playlist.AddToEnd(song2);
            playlist.AddToStart(song3);

            Console.WriteLine("Before removal:");

            playlist.PrintSongs();

            playlist.RemoveSongByName("MIA (feat. Drake)");

            Console.WriteLine("After removal:");

            playlist.PrintSongs();

            Song song4 = new Song
            {
                SongName = "Half on a Sack",
                ArtistName = "Three 6 Mafia",
                AlbumName = "Most Known Unknown",
                Length = 207
            };

            playlist.AddToEnd(song4);

            Console.WriteLine("After adding song4:");
            playlist.PrintSongs();

            Console.WriteLine("Searching...");
            var searchedSong = playlist.SearchSongByName("Stick Talk");
            Console.WriteLine(searchedSong);
            Console.WriteLine("Searching again...");
            var secondSearchedSong = playlist.SearchSongByName("I KNOW ?");
            Console.WriteLine(secondSearchedSong);
            System.Console.WriteLine("Searching by node:");
            var searchedByObject = playlist.SearchSongByObject(searchedSong);
            System.Console.WriteLine(searchedByObject);
            System.Console.WriteLine("Deleting searchedSong");
            playlist.RemoveSongByName(searchedSong?.SongName ?? "");
            playlist.PrintSongs();
            System.Console.WriteLine("Print results:");
            var searchedByObjectAfterDelete = playlist.SearchSongByObject(searchedSong);
            System.Console.WriteLine(searchedByObjectAfterDelete);
            playlist.StartPlaylist();
            var nowPlaying = playlist.GetNowPlaying();
            System.Console.WriteLine($"Now playing: {nowPlaying}");

            playlist.SkipSong();

            playlist.GoBackSong();

            var nextNowPlaying = playlist.GetNowPlaying();
            Console.WriteLine($"Now playing: {nextNowPlaying}");

            playlist.SkipSong();
        }
    }
}