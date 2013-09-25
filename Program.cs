using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTrainingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ShowOptions();
                string input = Console.ReadLine();

                if (input.Trim().Equals("exit", StringComparison.InvariantCultureIgnoreCase) || input.Trim() == "")
                    break;

                else
                {
                    HandleResponse(input);
                }
            }
        }

        private static void ShowOptions()
        {
            Console.WriteLine("Options:");
            Console.WriteLine("list - show all objects in the store.");
            Console.WriteLine("save <id> <value> - save id/value pair in the store.");
            Console.WriteLine("remove <id> - remove object from the store.");
            Console.WriteLine("exit - exit app.");
            Console.Write("> ");
        }

        private static void HandleResponse(string input)
        {
            string[] args = input.Split(new char[] {' '}, 3);
            switch (args[0])
            {
                case "list":
                    Console.WriteLine("list is not implemented");
                    break;
                case "save":
                    Console.WriteLine("save is not implemented");
                    break;
                case "remove":
                    Console.WriteLine("remove is not implemented");
                    break;
            }
        }

    }
}
