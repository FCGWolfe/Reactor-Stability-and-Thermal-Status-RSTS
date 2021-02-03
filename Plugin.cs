﻿using PulsarPluginLoader;
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
            return "FCGWolfe.RSTS";
        }

        public override string Version => "1.0_public";


        public override string Author => "💩Ship's Compooter💩 | Dragon";

        public override string ShortDescription => "Reactor Stability and Thermal Status.";

        //public static string VerCMDString = PluginManager.Instance.GetPlugin("FCGWolfe.RSTS").Version;

    }
}

