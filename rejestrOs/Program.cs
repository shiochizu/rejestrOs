using System;
using System.Collections.Generic;
using System.IO;

namespace rejestrOs
{
    class Program
    {
        static void Main(string[] args)
        {
            
       

            Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();
            commands["add"] = new AddCommand();
            commands["edit"] = new EditCommand();
            commands["search"] = new SearchCommand();
            commands["list"] = new ListCommand();
            commands["remove"] = new RemoveCommand();

            string currentCommand = "";
            while (currentCommand != "exit")
            {
                Console.WriteLine("What do you want to do? (add | edit | remove | search | list | exit)");
                currentCommand = Console.ReadLine();
                foreach(var com in commands)
                {
                    if (com.Key == currentCommand) com.Value.Execute();
                }
            }

        }
    }
}
