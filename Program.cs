using System;
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
            Application.Run(new AgentContext());
        }
    }

    //TrayIcon
    public class AgentContext : ApplicationContext
    {
        //Variables
        private NotifyIcon trayIcon;
        SoundPlayer soundEffect;
        private Fml workerObject;
        private Thread fmlThread;

        public AgentContext()
        {
            //Initialize tray icon
            trayIcon = new NotifyIcon();      
            trayIcon.Icon = Properties.Resources.XmasTree;
            trayIcon.Text = "XmasBusylight";
            trayIcon.Visible = true;
            trayIcon.ContextMenu = new ContextMenu(
                new MenuItem[] {
                    new MenuItem("Stop it dad!", die)
                }
            );

            //Start annoying user
            soundEffect = new SoundPlayer(Properties.Resources.Jingle);
            soundEffect.PlayLooping();
            workerObject = new Fml();
            fmlThread = new Thread(workerObject.annoy);
            fmlThread.Start();

            //Friendly wish merry christmas
            trayIcon.BalloonTipTitle = "Hooray!";
            trayIcon.BalloonTipText = "Merry christmas and a happy new year!";
            trayIcon.BalloonTipIcon = ToolTipIcon.Info;
            trayIcon.ShowBalloonTip(10000);
        }

        private void die(object sender, EventArgs e)
        {
            //Killing me softly
            try
            {
                trayIcon.Visible = false;
                fmlThread.Abort();
            }
            catch (Exception exc)
            {
                Console.WriteLine("Error while dying: '{0}'", exc.Message);
            }
            finally
            {
                Application.Exit();
            }
        }
    }

}