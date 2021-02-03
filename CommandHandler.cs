using PulsarPluginLoader.Chat.Commands;
using PulsarPluginLoader.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        if (!RSTSPatch.IsReadoutEnabled)
                        {
                            RSTSPatch.IsReadoutEnabled = true;
                            Messaging.Notification("RSTS Readout Enabled!");
                        }
                        else if (RSTSPatch.IsReadoutEnabled)
                        {
                            RSTSPatch.IsReadoutEnabled = false;
                            Messaging.Notification("RSTS Readout Disabled!");
                        }
                        break;

                    case "":
                        Messaging.Notification("Too lazy to enter a subcommand, huh?");
                        break;
                }
            }
            return false;
        }
    }
}
