using System;

namespace ToDoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintUsage Introduce = new PrintUsage(args);
            if (args.Length == 0)
            {
                Introduce.PrintCommands();
            }
            else
            {
                Introduce.ReadInput();
            }


        }
    }
}
