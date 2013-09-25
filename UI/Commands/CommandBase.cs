using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitTrainingApp.Infrastructures;

namespace GitTrainingApp.UI.Commands
{
    abstract class CommandBase
    {
        public virtual string GetHelp
        {
            get { return ""; }
        }

        public string CommandName { get; set; }

        protected IMainRepository MainRepository { get { return RepositoryFactory.Current.MainRepository; } }

        public CommandBase(string commandName)
        {
            CommandName = commandName;
        }

        public virtual void InitParams(params string[] args)
        {

        }

        public virtual void Execute()
        {

        }

        public virtual bool ShouldTerminateApp()
        {
            return false;
        }
    }
}
