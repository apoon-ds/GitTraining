using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitTrainingApp.Common.Entities;

namespace GitTrainingApp.UI.Commands
{
    class RemoveCommand:CommandBase
    {
        private string _id = null;

        public override string GetHelp
        {
            get { return "remove <id> - remove object from the store."; }
        }

        public RemoveCommand() : base("remove") {  }

        public override void InitParams(params string[] args)
        {
            base.InitParams(args);

            if (args != null && args.Count() == 1)
            {
                _id = args[0];
            }
            else
            {
                _id = null;
            }
        }

        public override void Execute()
        {
            base.Execute();
            if (!String.IsNullOrWhiteSpace(_id))
            {
                MainRepository.RemoveById(_id);
                Console.WriteLine("Object removed successfully.");
            }
            else
            {
                Console.WriteLine("Invalid parameters.");
            }
        }
    }
}
