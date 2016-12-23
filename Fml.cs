using System;
using System.Threading;

namespace XmasBusylight
{
    class Fml
    {
        //Variables
        Busylight.SDK controller;

        public Fml()
        {
            //Initialize controller
            controller = new Busylight.SDK();
        }

        ~Fml()
        {
            //Stahp it, pls
            stahp();
        }

        public void annoy()
        {
            //Kill me please
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
                Thread.Sleep(1000);
            }
            while (true);
        }

        public void stahp()
        {
            //Terminate controller
            controller.Terminate();
        }
    }
}
