using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitTrainingApp.UI;
using GitTrainingApp.UI.Commands;

namespace GitTrainingApp.Infrastructures
{
    class CommandFactory
    {
        #region Singleton
        private static CommandFactory _current = null;
        public static CommandFactory Current
        {
            get
            {
                if (_current == null)
                    _current = new CommandFactory();
                return _current;
            }
        }
        #endregion

        private Dictionary<string, CommandBase> _availableCommands;

        public CommandFactory()
        {
            _availableCommands = new Dictionary<string, CommandBase>();

            AddToAvailableCommandList(new ListCommand());
            AddToAvailableCommandList(new SaveCommand());
            AddToAvailableCommandList(new RemoveCommand());
            AddToAvailableCommandList(new HelpCommand());
            AddToAvailableCommandList(new ExitCommand());
        }

        public CommandBase GetCommand(string commandName, params string[] args)
        {
            CommandBase result;

            string cmdStr = commandName.Trim().ToLowerInvariant();
            if (_availableCommands.ContainsKey(cmdStr))
                result = _availableCommands[cmdStr];
            else
                result = new UnknownCommand();

            result.InitParams(args);

            return result;
        }

        public ICollection<CommandBase> GetAllAvailableCommands()
        {
            return _availableCommands.Values;
        }


        private void AddToAvailableCommandList(CommandBase cmd)
        {
            _availableCommands.Add(cmd.CommandName, cmd);
        }


    }
}
