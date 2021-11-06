using PulsarModLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSTS
{
    public class Plugin : PulsarMod
    {
        public override string HarmonyIdentifier()
        {
            return "FCGWolfe.RSTS";
        }

        public override string Version => "1.2c_public";

        private string LongAuthor = "Created by 💩Ship's Compooter💩, based off code from FloppyDisk's core temp readout mod, made fully functional by Dragon.";

        public override string Author => "💩Ship's Compooter💩 | Dragon";

        public override string ShortDescription => "Reactor Stability and Thermal Status.";

        public override string Name => "Reactor Stability and Thermal Status (RSTS)";

        //public static string VerCMDString = PluginManager.Instance.GetPlugin("FCGWolfe.RSTS").Version;

    }
}

