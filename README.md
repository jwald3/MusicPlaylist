# Music Playlist

## Overview
Music Playlist Manager is a .NET Console Application designed to manage music playlists using a linked list data structure. It allows users to load, manage, and navigate through a list of songs, offering options such as starting a playlist, viewing the current song, going to the next or previous song, and more.

## Features
- Load songs from a JSON file.
- Manage songs in a playlist using a linked list.
- Navigate through the playlist.
- Interactive menu to perform different operations on the playlist.
- Display all songs in the playlist.

## Classes
### Song.cs
Represents a song with properties such as:
- SongName
- ArtistName
- AlbumName
- Length

### Playlist.cs
Manages the playlist using a doubly linked list and provides functionalities to:
- Add songs to the start or end of the playlist.
- Remove songs by name or object.
- Search for songs by name or object.
- Navigate to the next or previous song.
- Start the playlist from the beginning.
- Display all songs in the playlist.

### SongDataLoader.cs
Loads the songs from a JSON file and parses them into `Song` objects.

### MenuHandler.cs
Handles the interactive menu display and user selection.

### Program.cs
The entry point of the application, initializing all necessary classes and starting the user interaction loop.

## How to Run
1. Ensure that you have .NET SDK installed on your machine.
2. Clone this repository.
3. Navigate to the project folder in the terminal.
4. Run `dotnet run` to start the application.

## How to Use
- Use the Up and Down arrow keys to navigate through the menu.
- Press Enter to select a menu option.
- Follow on-screen instructions for further interactions.

## Example JSON Data
The application loads song data from a JSON file structured as follows:

```json
[
    {
        "SongName": "SongName1",
        "ArtistName": "Artist1",
        "AlbumName": "Album1",
        "Length": "00:03:12"
    },
    // ...
]
```

### Error Handling
The application provides clear error messages and handles exceptions gracefully, ensuring a smooth user experience even in the case of unexpected errors.

### Contributions
Feel free to contribute to this project by creating a Pull Request.

### License
MIT

