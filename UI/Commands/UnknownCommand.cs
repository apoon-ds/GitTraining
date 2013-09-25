using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTrainingApp.UI.Commands
{
    class UnknownCommand:CommandBase
    {
        public UnknownCommand()
            : base("Unknown Command")
        {

        }

        public override void Execute()
        {
            base.Execute();
            Console.WriteLine("Unknown Command.");
        }
    }
}
