using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitTrainingApp.UI;

namespace GitTrainingApp.Infrastructures
{
    class CommandFactory
    {
        public CommandBase GetCommand(string commandName, params string[] args)
        {
            CommandBase result;

            switch (commandName.Trim().ToLowerInvariant())
            {
                case "list":
                    result = new ListCommand();
                    break;
                case "save":
                    result = new SaveCommand();
                    break;
                case "remove":
                    result = new RemoveCommand();
                    break;
                case "exit":
                    result = new ExitCommand();
                    break;
                default:
                    result = new UnknownCommand();
                    break;
            }

            result.InitParams(args);

            return result;
        }
    }
}
