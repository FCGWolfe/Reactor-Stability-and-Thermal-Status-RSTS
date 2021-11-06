using PulsarModLoader;
using PulsarModLoader.Chat.Commands.CommandRouter;
using PulsarModLoader.Utilities;
using PulsarModLoader.Chat.Commands;

namespace RSTS
{
    class CommandHandler : ChatCommand
    {
        public override string[] CommandAliases()
        {
            return new string[] { "rsts" };
        }

        public override string Description()
        {
            return "RSTS";
        }

        public string UsageExample()
        {
            return "/rsts [togglereadout/tr]";
        }
        public bool PublicCommand()
        {
            return false;
        }
        public override void Execute(string arguments)
        {
            string[] SplitArguments = arguments.Split(' ');
            {
                switch (SplitArguments[0].ToLower())
                {
                    case "togglereadout":
                    case "tr":
                        RSTSPatch.IsReadoutEnabled = !RSTSPatch.IsReadoutEnabled;
                        PLXMLOptionsIO.Instance.CurrentOptions.SetStringValue("RSTSReadoutEnabled", RSTSPatch.IsReadoutEnabled.ToString());
                        string IREResultString = RSTSPatch.IsReadoutEnabled ? "Enabled!" : "Disabled!";
                        Messaging.Notification($"RSTS Readout is now {IREResultString}");
                        break;

                    case "ver":
                        Messaging.Notification($"RSTS Version {ModManager.Instance.GetMod("Reactor Stability and Thermal Status (RSTS)").Version}");
                        break;

                    default:
                        //Messaging.Notification("Too lazy to enter a subcommand, huh?");
                        RSTSPatch.IsReadoutEnabled = !RSTSPatch.IsReadoutEnabled;
                        string IREResultStringLazy = RSTSPatch.IsReadoutEnabled ? "Enabled!" : "Disabled!";
                        Messaging.Notification($"RSTS Readout is now {IREResultStringLazy}");
                        break;
                }
            }
        }
    }
}
