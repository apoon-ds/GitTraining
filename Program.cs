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
        static void Main(string[] args)
        {
            Console.WriteLine("Type 'help' for list of commands.");

            RepositoryFactory.Current.MainRepository.LoadDataStore();

            while (true)
            {
                string input = Prompt();

                if (!String.IsNullOrWhiteSpace(input))
                {
                    string[] strArgs = input.Split(new char[] { ' ' });

                    var command = CommandFactory.Current.GetCommand(strArgs[0], strArgs.Skip(1).ToArray());

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

            RepositoryFactory.Current.MainRepository.SaveDataStore();
        }

        private static string Prompt()
        {
            Console.Write("> ");
            return Console.ReadLine();
        }
    }
}
