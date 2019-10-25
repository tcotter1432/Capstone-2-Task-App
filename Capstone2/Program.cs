using System;
using System.Collections.Generic;

namespace Capstone2
{
    class Program
    {
        //static List<Task> theTasks = new List<Task>();
        static void Main(string[] args)
        {
            //string input;
            //int intInput;

            while (true)
            {
                Console.WriteLine("What do you want to do?");
                PrintOptions();
                SelectMenuOption(Console.ReadLine());
            }
        }

        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static int ValidateInput(string thingToValidate)
        {
            try
            {
                return int.Parse(thingToValidate);
            }catch (FormatException)
            {
                Console.WriteLine("Bad input, try again...");
                return ValidateInput(Console.ReadLine());
            }
        }

        public static void PrintOptions()
        {
            Console.WriteLine("1. List tasks");
            Console.WriteLine("2. Add task");
            Console.WriteLine("3. Delete task");
            Console.WriteLine("4. Mark task complete");
            Console.WriteLine("5. Quit");
        }

        public static void AddTask()
        {
            Task task = new Task();
            task.Name = GetUserInput("Enter task owner's Name: ");
            task.Description = GetUserInput("What is this Task? ");
            task.DueDate = CheckDateTime(GetUserInput("When is it due? "));
            task.Completed = false;
            Task.AddTask(task);
        }

        public static DateTime CheckDateTime(string input)
        {
            try
            {
                return DateTime.Parse(input);
            }
            catch (FormatException)
            {
                return CheckDateTime(GetUserInput("You entered a bad."));
            }
        }

        public static void SelectMenuOption(string userInput)
        {
            switch (userInput.ToLower())
            {
                case ("1"):
                case ("list tasks"):
                    Task.DisplayTasks();
                    break;
                case ("2"):
                case ("add task"):
                    AddTask();
                    break;
                case ("3"):
                case ("delete task"):
                    Task.DisplayTasks();
                    Console.WriteLine("Enter the number you want to delete.");
                    Task.DeleteTask(ValidateInput(Console.ReadLine())-1);
                    break;
                case ("4"):
                case ("mark task complete"):
                    Task.DisplayTasks();
                    Console.WriteLine("Which task is now complete?");
                    Task.CompleteTask(ValidateInput(Console.ReadLine()) - 1);
                    break;
                case ("5"):
                case ("quit"):
                    Environment.Exit(0);
                    break;
                default:

                    break;
            }
        }
    }
}
