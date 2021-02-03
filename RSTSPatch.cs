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
    class RSTSPatch
    {
        public static bool IsReadoutEnabled = false;
        static void Postfix(PLNetworkManager __instance, Text ___CurrentVersionLabel)
        {
            if (PLServer.Instance != null && PLEncounterManager.Instance.PlayerShip != null && IsReadoutEnabled)
            {
                string ReactorStatus;
                bool ReactorIsFine = (!PLEncounterManager.Instance.PlayerShip.IsReactorOverheated() && !PLEncounterManager.Instance.PlayerShip.IsReactorTempCritical() && !PLEncounterManager.Instance.PlayerShip.IsReactorInMeltdown());
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
                if (Mathf.RoundToInt(Mathf.Clamp01(1f - PLEncounterManager.Instance.PlayerShip.CoreInstability) * 100f) < 100 && ReactorIsFine)
                {
                    ReactorIsFine = false;
                    ReactorStatus = "<color=yellow>Unstable - Recovering </color><color=#ff8c00><b><<╪>></b></color><color=yellow> Stability: " + Mathf.RoundToInt(Mathf.Clamp01(1f - PLEncounterManager.Instance.PlayerShip.CoreInstability) * 100f).ToString("000") + "%</color>";
                }
                else if (Mathf.RoundToInt(Mathf.Clamp01(1f - PLEncounterManager.Instance.PlayerShip.CoreInstability) * 100f) < 100 && PLEncounterManager.Instance.PlayerShip.IsReactorOverheated() && (ReactorIsFine || !ReactorIsFine))
                {
                    ReactorStatus = "<color=#ff8c00>OVERHEATED!</color> <color=#B8860B>~╫~</color> Temp: " + Mathf.RoundToInt(PLEncounterManager.Instance.PlayerShip.ReactorOverheatTime / PLEncounterManager.Instance.PlayerShip.MyStats.ReactorTempMax * 100f).ToString("000") + "%";
                }
                else if (Mathf.RoundToInt(Mathf.Clamp01(1f - PLEncounterManager.Instance.PlayerShip.CoreInstability) * 100f) < 100 && PLEncounterManager.Instance.PlayerShip.IsReactorTempCritical() && (ReactorIsFine || !ReactorIsFine))
                {
                    ReactorStatus = "<color=#DC143C>DANGER:</color> <color=#FFA500>THERMAL STRESS</color> <color=red><b>~╫~</b></color> <color=#FFA500>STABILITY: " + Mathf.RoundToInt(Mathf.Clamp01(1f - PLEncounterManager.Instance.PlayerShip.CoreInstability) * 100f).ToString("000") + "%</color>";
                }
                else if (Mathf.RoundToInt(Mathf.Clamp01(1f - PLEncounterManager.Instance.PlayerShip.CoreInstability) * 100f) < 100 && PLEncounterManager.Instance.PlayerShip.IsReactorInMeltdown() && (ReactorIsFine || !ReactorIsFine))
                {
                    ReactorStatus = "<color=#8B0000>EJECTING</color> <color=red><╪></color> <color=#8B0000>REACTOR CORE</color>";
                }
                else
                {
                    ReactorIsFine = true;
                    ReactorStatus = "Stable <color=#32CD32><╫></color> Temp: " + Mathf.RoundToInt(PLEncounterManager.Instance.PlayerShip.MyStats.ReactorTempCurrent / PLEncounterManager.Instance.PlayerShip.MyStats.ReactorTempMax * 100f).ToString("000") + "%";
                }

                PLGlobal.SafeLabelSetText(___CurrentVersionLabel, $"{___CurrentVersionLabel.text}\n\n\n\nRSTS: {ReactorStatus}");
            }
        }
    }
}
