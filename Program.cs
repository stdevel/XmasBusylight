using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace XmasBusylight
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormAbout());
            Application.Run(new AgentContext());
        }
    }

    //TrayIcon
    public class AgentContext : ApplicationContext
    {
        private NotifyIcon trayIcon;

        public AgentContext()
        {
            //Initialize tray icon
            trayIcon = new NotifyIcon();      
            trayIcon.Icon = XmasBusylight.Properties.Resources.XmasTree;
            trayIcon.Text = "XmasBusylight";
            trayIcon.Visible = true;

            //Start annoying user
            SoundPlayer soundEffect = new SoundPlayer(XmasBusylight.Properties.Resources.Jingle);
            soundEffect.PlayLooping();

            var controller = new Busylight.SDK();
            Random rnd = new Random();
            do
            {
                //Get random colors and sound
                int random_r = rnd.Next(1, 255);
                int random_g = rnd.Next(1, 255);
                int random_b = rnd.Next(1, 255);

                //Annoy user
                Console.WriteLine("Setting color to RGB {0}/{1}/{2}", random_r, random_g, random_b);
                controller.Alert(new Busylight.BusylightColor { RedRgbValue = random_r, GreenRgbValue = random_g, BlueRgbValue = random_b }, Busylight.BusylightSoundClip.IM1, Busylight.BusylightVolume.Mute);
                System.Threading.Thread.Sleep(1000);
            }
            while (true);
        }

    }

}
