using PulsarPluginLoader;
using PulsarPluginLoader.Chat.Commands;
using PulsarPluginLoader.Utilities;

namespace RSTS
{
    class CommandHandler : IChatCommand
    {
        public string[] CommandAliases()
        {
            return new string[] { "rsts" };
        }

        public string Description()
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
        public bool Execute(string arguments, int executor)
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
                        Messaging.Notification($"RSTS Version {PluginManager.Instance.GetPlugin("Reactor Stability and Thermal Status (RSTS)").Version}");
                        break;

                    default:
                        //Messaging.Notification("Too lazy to enter a subcommand, huh?");
                        RSTSPatch.IsReadoutEnabled = !RSTSPatch.IsReadoutEnabled;
                        string IREResultStringLazy = RSTSPatch.IsReadoutEnabled ? "Enabled!" : "Disabled!";
                        Messaging.Notification($"RSTS Readout is now {IREResultStringLazy}");
                        break;
                }
            }
            return false;
        }
    }
}
