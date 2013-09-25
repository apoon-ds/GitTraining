using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitTrainingApp.Common.Entities;

namespace GitTrainingApp.UI
{
    class SaveCommand:CommandBase
    {
        private LookupItem _item = null;

        public SaveCommand()
            : base("save")
        {

        }

        public override void InitParams(params string[] args)
        {
            base.InitParams(args);

            if (args != null && args.Count() == 2)
            {
                _item = new LookupItem
                {
                    Id = args[0],
                    Value = args[1]
                };
            }
            else
            {
                _item = null;
            }
        }

        public override void Execute()
        {
            base.Execute();
            if (_item != null)
            {
                MainRepository.Save(_item);
                Console.WriteLine("Object saved successfully.");
            }
            else
            {
                Console.WriteLine("Invalid parameters.");
            }
        }
    }
}
