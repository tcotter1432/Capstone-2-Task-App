using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone2
{
    class Task
    {
        static List<Task> theTasks = new List<Task> {
            new Task("Jack","Does the work",DateTime.Parse("10/25/2019")),
            new Task("Tristan","Stares Blankly",DateTime.Parse("10/24/2019")),
            new Task("Steve","Does Nothing",DateTime.Parse("10/25/2019"))
        };

        private string name;
        private string description;
        private DateTime dueDate;
        private bool completed;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }
        public bool Completed
        {
            get { return completed; }
            set { completed = value; }
        }

        public Task()
        {

        }
        public Task(string _name, string _description, DateTime _dueDate, bool _complete = false)
        {
            Name = _name;
            Description = _description;
            DueDate = _dueDate;
            Completed = _complete;
        }

        public static void DisplayTasks()
        {
            for (int i = 0; i < theTasks.Count; i++)
            {
                DisplayTask(i);
            }
        }
        public static void DisplayTask(int i)
        {
            Console.WriteLine($"\t{i + 1}. {theTasks[i].name}");
            Console.WriteLine($"\tDue Date: {theTasks[i].DueDate.ToShortDateString()}");
            Console.WriteLine($"\tCompleted? {theTasks[i].Completed}");
            Console.WriteLine($"\tTask: {theTasks[i].Description}\n");
        }

        public static void AddTask(Task task)
        {
            theTasks.Add(task);
        }

        public static void DeleteTask(int index)
        {
            if (index > 0 && index < theTasks.Count)
            {
                DisplayTask(index);
                Console.WriteLine("Do you want to eliminate this Task? (y/n)");
                if (Console.ReadLine().ToLower() == "y")
                {
                    theTasks.RemoveAt(index);
                }
            }
            else
            {
                Console.WriteLine("Bad input. Try again, dummy.");
                DisplayTasks();
                try
                {
                    DeleteTask(int.Parse(Console.ReadLine()));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bad Input. Try again.");
                    DeleteTask(int.Parse(Console.ReadLine()));
                }
            }
        }

        private void Complete()
        {
            completed = true;
        }

        public static void CompleteTask(int index)
        {
            if (index > 0 && index < theTasks.Count)
            {
                DisplayTask(index);
                Console.WriteLine("Do you want to complete this Task? (y/n)");
                if (Console.ReadLine().ToLower() == "y")
                {
                    theTasks[index].Complete();
                }
            }
            else
            {
                Console.WriteLine("Bad input. Try again, dummy.");
                DisplayTasks();
                try
                {
                    DeleteTask(int.Parse(Console.ReadLine()));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bad Input. Try again.");
                    DeleteTask(int.Parse(Console.ReadLine()));
                }
            }
        }
    }
}
