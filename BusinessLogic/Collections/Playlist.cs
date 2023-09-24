using System.Security.Cryptography.X509Certificates;
using MusicPlaylist.BusinessLogic.Models;

namespace MusicPlaylist.BusinessLogic.Collections
{
    public class Node<Song> 
    {
        public Song? Data { get; set; }
        public Node<Song>? Next { get; set; } = null;

        public Node(Song song)
        {
            Data = song;
            Next = null;
        }
    }

    public class Playlist 
    {
        public Node<Song>? Head { get; set; }
        public Node<Song>? NowPlaying { get; set; }

        public Playlist()
        {
            Head = null;
            NowPlaying = null;
        }

        public void AddToStart(Song song)
        {
            Node<Song> newSong = new Node<Song>(song) {
                Next = Head
            };

            Head = newSong;
        }

        public void AddToEnd(Song song)
        {
            Node<Song> newSong = new Node<Song>(song);

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

            current.Next = newSong;
        }

        public void RemoveSongByObject(Song? song) 
        {
            if (Head is null) return;

            if (Head.Data?.Equals(song) == true)
            {
                Head = Head.Next;
                return;
            }

            var current = Head;

            while (current?.Next is not null)
            {
                if (current.Next.Data?.Equals(song) == true)
                {
                    current.Next = current.Next.Next;
                    break;
                }   
                else 
                {
                    current = current.Next;
                }
            } 
        }
    
        public void RemoveSongByName(string songName)
        {
            if (Head is null) return;

            if (Head.Data?.SongName == songName) 
            {
                Head = Head.Next;
                return;
            }

            var current = Head;
            while (current?.Next is not null)
            {
                if (current.Next.Data?.SongName == songName) 
                {
                    current.Next = current.Next.Next;
                    break;
                }
                else 
                {
                    current = current.Next;
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
                throw new Exception("Playlist is empty");
            }

            NowPlaying = Head;
        }

        public Song? GetNowPlaying()
        {
            if (NowPlaying is null) 
            {
                throw new Exception("Playlist hasn't started yet.");
            }

            return NowPlaying.Data;
        }

        public void PrintSongs()
        {
            var current = Head;

            while (current is not null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }
}