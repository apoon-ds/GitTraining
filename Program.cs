using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitTrainingApp.Infrastructures;

namespace GitTrainingApp
{
    class Program
    {
        private static CommandFactory commandFactory = new CommandFactory();

        static void Main(string[] args)
        {
            while (true)
            {
                ShowOptions();
                string input = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(input))
                {
                    string[] strArgs = input.Split(new char[] { ' ' });

                    var command = commandFactory.GetCommand(strArgs[0], strArgs.Skip(1).ToArray());

                    try
                    {
                        command.Execute();
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine("Error Occur: " + err.ToString());
                    }

                    if (command.ShouldTerminateApp())
                        break;
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
    }
}
