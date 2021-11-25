using System;

namespace ProgrammingFinals
{
    class Singer : Person
    {
        string[] songs;
        public Singer(string name, string pronoun, string message, string[] songs)
        : base(name, pronoun, message)
        {
            this.songs = songs;
        }

        public string sing()
        {
            return songs[new Random().Next(0, songs.Length)];
        }
    }
}