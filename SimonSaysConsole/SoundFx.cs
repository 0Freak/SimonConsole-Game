using System;
using System.Media;

namespace SimonSaysConsole
{
    class SoundFx
    {

        private SoundPlayer _Notes;
        private readonly string soundPath = Environment.CurrentDirectory + @"\Sounds\";
        private string fileName;

        public SoundFx()
        {
        }

        public void PlaySound(string fileName)
        {
            _Notes = new SoundPlayer(soundPath + fileName);
            _Notes.Play();
        }

        //public void Notes(string note)
        //{

        //    switch (note.ToUpper())
        //    {
        //        case "C":
        //            {
        //                try
        //                {
        //                    this._NoteC4.Play();
        //                    this._NoteC4.Dispose();
        //                    break;
        //                }
        //                catch (Exception)
        //                {
        //                    Console.WriteLine();
        //                    Console.WriteLine("Error: The Sound \"s262.wav\" cannot be found");
        //                    break;
        //                }
        //            }
        //        case "D":
        //            {
        //                try
        //                {
        //                    this._NoteD4.Play();
        //                    break;
        //                }
        //                catch (Exception)
        //                {
        //                    Console.WriteLine();
        //                    Console.WriteLine("Error: The Sound \"s294.wav\" cannot be found");
        //                    break;
        //                }
        //            }
        //        default:
        //            break;
        //    }
        //}
    }
}

