using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToDoApp
{
    public class PrintUsage
    {
        private string[] Args;
        public string path = @"C:\Users\Miroslav\cmder\greenfox\ToDoApp\ToDoApp_Jiranek\day-1\ToDoApp\ToDoApp\ToDoApp.txt";

        public PrintUsage(string[] args)
        {
            this.Args = args;
        }

        public void ReadInput()
        {
            switch (Args[0])
            {
                case "-l":
                    ListTasks();
                    break;
                case "-a":
                    AddTask();
                    break;
                case "-r":
                    RemoveTask();
                    break;
                case "-c":
                    Console.WriteLine("Completes an task");
                    break;
                default:
                    Console.WriteLine("Unsupported argument");
                    break;
            }
        }

        public void PrintCommands()
        {
            Console.WriteLine("Command Line Todo application\n" +
                              "=============================\n" +
                              "Command line arguments:\n" +
                              "       -l   Lists all the tasks\n" +
                              "       -a   Adds a new task\n" +
                              "       -r   Removes an task\n" +
                              "       -c   Completes an task");

        }
        public void ListTasks()
        {
            List<string> ReadList = new List<string>();
            string[] Lines = File.ReadAllLines(path);

            if (Lines.Length == 0)
            {
                Console.WriteLine("No todos for today! :)");
            }
            else
            {
                for (int i = 0; i < Lines.Length; i++)
                {
                    ReadList.Add(Lines[i]);
                    Console.WriteLine($"{i + 1} - [ ] {Lines[i]}");
                }
            }

        }
        public void AddTask()
        {
            //List<string> WriteList = new List<string>();
            //Console.Write("Add the task: ");
            //string newTask = Console.ReadLine();
            if (Args[1].Length == 0)
            {
                Console.WriteLine("Unable to add: no task provided");
            }
            else
            {
                //WriteList.Add(newTask);
                //File.AppendAllLines(path, newTask);

                File.AppendAllText(path, Args[1] + "\r\n");
            }

        }

        public void RemoveTask()
        {
            //Reading from file, writing to array string, then convert to a List and filling
            List<string> ReadList = new List<string>();
            string[] Lines = File.ReadAllLines(path);
            for (int i = 0; i < Lines.Length; i++)
            {
                ReadList.Add(Lines[i]);
            }
            //------------------------------------------------------------------------------
            Console.Write("Which task(index) should be removed: ");
            string IndexInput = Console.ReadLine();
            int ParsedInput;

            if (IndexInput.Length == 0)
            {
                Console.WriteLine("Unable to remove: no index provided");
            }
            else if (int.TryParse(IndexInput, out ParsedInput))
            {
                if (ParsedInput > 0 && (ParsedInput - 1) <= Lines.Length)
                {
                    Console.WriteLine($"'{Lines[ParsedInput - 1]}' was removed.");
                    ReadList.RemoveAt(ParsedInput - 1);
                    File.WriteAllLines(path, ReadList);
                }
                else
                {
                    Console.WriteLine("Unable to remove: index is out of bound");
                }
            }
            else
            {
                Console.WriteLine("Unable to remove: index is not a number");
            }

        }


    }
}
