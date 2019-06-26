using System;
using System.Media;
using System.Windows;
namespace ALertMe
{
    public class ClockEngine : IClock
    {
        private string path = Environment.CurrentDirectory;
        private Clocks clo = ClockValueParsing() as Clocks;
        public MainWindow form { get; set; }
        public ClockEngine(MainWindow win)
        {
            form = win;
        }
        public bool MsgAlert(Clocks userdefine)
        {
            
            if (clo.Stunde == userdefine.Stunde && clo.Mintue == userdefine.Mintue && clo.Sekunde == 10)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }
        public Clocks SetWatch()
        {
            clo.Stunde = DateTime.Now.Hour;
            clo.Mintue = DateTime.Now.Minute;
            clo.Sekunde = DateTime.Now.Second;
            return clo;
        }

        public void PlaySound()
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = path + @"\alerttrain.wav";
            player.Play();

        }

        public static Clocks ClockValueParsing() 
        {
            int x = DateTime.Now.Hour;
            int y = DateTime.Now.Minute;
            int z = DateTime.Now.Second;

            return new Clocks()
            {
                Stunde = x,
                Mintue = y,
                Sekunde = z
            };
        }        
        
    }
}