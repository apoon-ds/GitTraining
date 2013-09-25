using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitTrainingApp.Common.Entities;
using GitTrainingApp.Infrastructures;

namespace GitTrainingApp.UI
{
    class ListCommand : CommandBase
    {
        public ListCommand()
            : base("list")
        {

        }

        public override void Execute()
        {
            base.Execute();

            var list = MainRepository.RetrieveAll();

            if(list == null || list.Count() == 0)
            {
                Console.WriteLine("No objects in store.");
            }
            else
            {
                foreach (LookupItem item in list)
                    Console.WriteLine(item.Id.PadRight(10, ' ') + item.Value);

                Console.WriteLine("Total object(s): {0}", list.Count);
            }
        }
    }
}
