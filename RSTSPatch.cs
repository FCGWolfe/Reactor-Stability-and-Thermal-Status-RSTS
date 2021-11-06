using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace RSTS
{
    [HarmonyPatch(typeof(PLInGameUI), "Update")]
    public class RSTSPatch
    {
        public static bool IsReadoutEnabled = false;
        public static string ReactorStatus;
        //public static GameObject BrokenReactorVisual = PLEncounterManager.Instance.PlayerShip.InteriorDynamic.Find("Reactor_01_GlassBroken");
        static void Postfix(PLNetworkManager __instance, Text ___CurrentVersionLabel)
        {
            if (PLServer.Instance != null && PLEncounterManager.Instance.PlayerShip != null && PLEncounterManager.Instance.PlayerShip.ReactorInstance != null)
            {
                //string ReactorStatus = string.Empty;
                //bool ReactorIsFine = (!PLEncounterManager.Instance.PlayerShip.IsReactorOverheated() && !PLEncounterManager.Instance.PlayerShip.IsReactorTempCritical() && !PLEncounterManager.Instance.PlayerShip.IsReactorInMeltdown());
                /*
                 * This is gonna be neat.
                 * 
                string CurrentReactorIcon = "";
                string ReactorIcon1 = "╪";
                string ReactorIcon2 = "╬";
                string ReactorIcon3 = "╫";
                string ReactorIcon4 = "║";
                string ReactorIcon5 = "Φ";
                string ReactorIcon6 = "Θ";
                */

                if (PLEncounterManager.Instance.PlayerShip.IsReactorOverheated())
                {
                    ReactorStatus = "<color=#ff8c00>REACTOR SAFETY SHUTDOWN ENGAGED!</color> <color=#B8860B>~╫~</color>";
                }
                else if (PLEncounterManager.Instance.PlayerShip.ShouldEjectReactorCore())
                {
                    ReactorStatus = "<color=red>CORE IMPLOSION</color> <color=red><╪></color> <color=red>IMMINENT</color>";
                }
                else if (PLEncounterManager.Instance.PlayerShip.IsReactorInMeltdown())
                {
                    ReactorStatus = "<color=red>CORE</color> <color=red><╪></color> <color=red>JETTISONED</color>";
                }
                else if (PLEncounterManager.Instance.PlayerShip.IsReactorTempCritical())
                {
                    ReactorStatus = "<color=red>DANGER:</color> <color=#FFA500>THERMAL STRESS</color> <color=red><b>~╫~</b></color>";
                }
                else if (PLEncounterManager.Instance.PlayerShip.CoreInstability > 0)
                {
                    ReactorStatus = "<color=yellow>Unstable - Recovering </color><color=#ff8c00><b><<╪>></b></color>";
                }
                else
                { 
                    ReactorStatus = "Stable <color=#32CD32><╫></color>";
                }
                if (PLEncounterManager.Instance.PlayerShip.CoreInstability > 0)
                {
                    ReactorStatus += " <color=#FFA500>STABILITY: " + Mathf.RoundToInt(Mathf.Clamp01(1f - PLEncounterManager.Instance.PlayerShip.CoreInstability) * 100f).ToString("000") + "%</color>";
                }
                else
                {
                    ReactorStatus += " Temperature: " + Mathf.RoundToInt(PLEncounterManager.Instance.PlayerShip.MyStats.ReactorTempCurrent / PLEncounterManager.Instance.PlayerShip.MyStats.ReactorTempMax * 100f).ToString("000") + "%";
                }

                if (IsReadoutEnabled)
                {
                    PLGlobal.SafeLabelSetText(___CurrentVersionLabel, $"{___CurrentVersionLabel.text}\n\n\n\nRSTS: {ReactorStatus}");
                }
                else if (!IsReadoutEnabled)
                {
                    ReactorStatus = string.Empty;
                }

            }
        }
    }
}
