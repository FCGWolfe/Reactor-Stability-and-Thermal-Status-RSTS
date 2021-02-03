using PulsarPluginLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSTS
{
    public class Plugin : PulsarPlugin
    {
        public override string HarmonyIdentifier()
        {
            return "RSTS";
        }

        protected static string Version => "1.0_idb-1";

        protected static string Author => "FCGWolfe/Ship's Compooter";

        protected static string ShortDescription => "Reactor Stability and Thermal Status.";

    }
}

