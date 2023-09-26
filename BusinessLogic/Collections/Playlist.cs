using System.Security.Cryptography.X509Certificates;
using MusicPlaylist.BusinessLogic.Models;

namespace MusicPlaylist.BusinessLogic.Collections
{
    public class Node 
    {
        public Song? Data { get; set; }
        public Node? Next { get; set; } = null;
        public Node? Previous { get; set; } = null;

        public Node(Song? song)
        {
            Data = song;
            Next = null;
            Previous = null;
        }
    }

    public class Playlist 
    {
        public Node? Head { get; set; }
        public Node? NowPlaying { get; set; }

        public Playlist()
        {
            Head = null;
            NowPlaying = null;
        }

        public void AddToStart(Song song)
        {
            Node newSong = new Node(song) {
                Next = Head,
                Previous = null
            };

            Head = newSong;
        }

        public void AddToEnd(Song song)
        {
            Node newSong = new Node(song);

            if (Head is null)
            {
                Head = newSong;
                return;
            }

            var current = Head;
            while (current.Next is not null) 
            {
                current = current.Next;
            }

            newSong.Previous = current;
            current.Next = newSong;
        }

        public void RemoveSongByObject(Song? song) 
        {
            if (Head is null) return;

            if (Head.Data?.Equals(song) == true)
            {
                Head = Head.Next;
                if (Head is not null)
                {
                    Head.Previous = null;
                }
                
                return;
            }

            var trailingNode = Head;
            var leadNode = Head.Next;

            while (leadNode is not null)
            {
                if (leadNode.Data?.Equals(song) == true)
                {
                    trailingNode.Next = leadNode.Next;
                 
                    if (leadNode.Next is not null)
                    {
                        leadNode.Next.Previous = trailingNode;
                    }
                    
                    break;
                }
                else 
                {
                    trailingNode = leadNode;
                    leadNode = leadNode.Next;
                }
            }
        }
    
        public void RemoveSongByName(string songName)
        {
            if (Head is null) return;

            if (Head.Data?.SongName == songName) 
            {
                Head = Head.Next;
                if (Head is not null)
                {
                    Head.Previous = null;
                }

                return;
            }

            var trailingNode = Head;
            var leadNode = Head.Next;

            while (leadNode is not null)
            {
                if (leadNode.Data?.SongName?.Equals(songName) == true)
                {
                    trailingNode.Next = leadNode.Next;
                 
                    if (leadNode.Next is not null)
                    {
                        leadNode.Next.Previous = trailingNode;
                    }
                    
                    break;
                }
                else 
                {
                    trailingNode = leadNode;
                    leadNode = leadNode.Next;
                }
            }
        }
    
        public Song? SearchSongByName(string songName)
        {
            if (Head is null) return null;

            if (Head.Data?.SongName == songName) 
            {
                return Head.Data;
            }

            var current = Head.Next;

            while (current is not null)
            {
                if (current.Data?.SongName == songName)
                {
                    return current.Data;
                }
                else 
                {
                    current = current.Next;
                }
            }

            return null;
        }

        public Song? SearchSongByObject(Song? song)
        {
            if (Head is null) return null;


            if (Head.Data?.Equals(song) == true) 
            {
                return Head.Data;
            }

            var current = Head.Next;
            while (current is not null)
            {
                if (current.Data?.Equals(song) == true)
                {
                    return current.Data;
                }
                else 
                {
                    current = current.Next;
                }
            }


            return null;
        }
        
        public void StartPlaylist()
        {
            if (Head is null) 
            {
                Console.WriteLine("Cannot start: Playlist is empty");
                return;
            }

            NowPlaying = Head;
        }

        public Song? GetNowPlaying()
        {
            if (NowPlaying is null) 
            {
                Console.WriteLine("Cannot get current song: Playlist hasn't started yet.");
                return null;
            }

            return NowPlaying.Data;
        }

        public void SkipSong()
        {
            if (NowPlaying is null)
            {
                Console.WriteLine("Cannot skip: Playlist hasn't started yet.");
                return;
            }
            else
            {
                if (NowPlaying.Next is not null)
                {
                    NowPlaying = NowPlaying.Next;
                }
                else 
                {
                    NowPlaying = null;
                    Console.WriteLine("Playlist is over.");
                }
            }
        }

        public void GoBackSong()
        {
            if (NowPlaying is null)
            {
                Console.WriteLine("Cannot go back: Playlist hasn't started yet.");
                return;
            }
            else
            {
                if (NowPlaying.Previous is not null)
                {
                    NowPlaying = NowPlaying.Previous;
                }
                else 
                {
                    System.Console.WriteLine("No songs before this one.");
                }
            }
        }

        public void AddRange(List<Song> songs)
        {
            foreach (var song in songs)
            {
                AddToEnd(song);
            }
        }

        public void PrintSongs(TextWriter? writer = null)
        {
            writer ??= Console.Out;
            var current = Head;
            while (current is not null)
            {
                writer.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }
}