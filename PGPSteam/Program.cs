using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PGPSteam
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // setup
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // setup key cache
            if (!Directory.Exists("key_cache"))
            {
                Directory.CreateDirectory("key_cache");
            }

            // setup key locals
            if (!Directory.Exists("key_local"))
            {
                Directory.CreateDirectory("key_local");
            }

            // generate keypairs if need be
            bool shouldGen = false;
            if (!File.Exists("key_local/private.key"))
            {
                if (File.Exists("key_local/public.key"))
                {
                    File.Delete("key_local/public.key");
                }

                shouldGen = true;
            }
            else if (!File.Exists("key_local/public.key"))
            {
                File.Delete("key_local/private.key");

                shouldGen = true;
            }
            
            if (shouldGen)
            {
                Generate.GenerateKeypair("key_local/private.key", "key_local/public.key");
            }

            // run
            App app = new App();
            app.Run();
        }
    }
}
