using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GitTrainingApp.Infrastructures;

namespace GitTrainingApp.UI.Commands
{
    class HelpCommand : CommandBase
    {
        public HelpCommand()
            : base("help")
        {

        }

        public override string GetHelp
        {
            get
            {
                return "help - open this command menu.";
            }
        }

        public override void Execute()
        {
            base.Execute();
            Console.WriteLine("Available Commands:");

            foreach (CommandBase cmd in CommandFactory.Current.GetAllAvailableCommands())
            {
                Console.WriteLine(cmd.GetHelp);
            }
        }
    }
}
