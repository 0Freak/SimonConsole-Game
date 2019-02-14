using System;
using System.Media;

namespace SimonSaysConsole
{
    class Sounds
    {

        private SoundPlayer _Notes;
        private readonly string _soundPath = Environment.CurrentDirectory + @"\Sounds\";
        private readonly string _musicPath = Environment.CurrentDirectory + @"\Sounds\Music\Menu.wav";

        public void PlaySound(string fileName)
        {
            _Notes = new SoundPlayer(_soundPath + fileName);
            _Notes.Play();
            _Notes.Dispose();
        }

        public void PlaySong(string action)
        {
            if (action == "play")
            {
                _Notes = new SoundPlayer(_musicPath);
                _Notes.PlayLooping();
            }
            else
            {
                _Notes.Stop();
                _Notes.Dispose();
            }
        }
    }
}

