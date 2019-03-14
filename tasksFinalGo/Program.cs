using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tasksFinalGo
{
    class Program
    {


        static void Main(string[] args)
        {
          //  int taskSelected = -1;
          // var Actioned = new List<bool>();
            var task = new List<string>();

            bool quit = false;

            string[] tasks = File.ReadAllLines(@"C:\Users\WWStudent\OneDrive\Projects\tasksFinalGo\tasks.txt");
            foreach (string taskss in tasks)
            {
                task.Add(taskss);
            }
            do
            {
                menu();

                Console.WriteLine("\nChoose option");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        addtask(task);
                        break;

                    case "2":
                        displayTasks(task);
                        break;

                    case "3":

                        deleteItem(task);
                        break;

                    //case "4":
                    //    {
                    //        Console.WriteLine("Enter # for task to complete");
                    //        Console.ReadLine();
                            
                    //        //Console.Clear();

                    //        for (int i = 0; i < Actioned.Count; ++i)
                    //        {
                    //            if (Actioned[i])
                    //            {
                    //                Console.ForegroundColor = ConsoleColor.DarkGray;
                    //            }
                    //            else if (i == taskSelected)
                    //            {
                    //                Console.BackgroundColor = ConsoleColor.Gray;
                    //                Console.ForegroundColor = ConsoleColor.Black;


                    //                Console.WriteLine(Actioned[i]);

                    //                Console.ForegroundColor = ConsoleColor.Gray;
                    //                Console.BackgroundColor = ConsoleColor.Black;

                    //            }

                    //            Console.WriteLine();
                    //        }
                    //    } // selectTask();
                    //    break;

                    case "0":

                        quit = true;
                        break;

                    default:
                        invalidInput();
                        break;
                }

                File.WriteAllLines(@"C:\Users\WWStudent\OneDrive\Projects\tasksFinalGo\tasks.txt", tasks);
            }
            while (!quit);

        }






        //private void selectTask()
        //{
        ////    bool over = false;

        ////    do
        ////    {
        ////        taskSelected += 1;

        ////        if (taskSelected >= Actioned.Count)
        ////        {
        ////            taskSelected = -1;
        ////            over = true;
        ////        }
        ////    } while (!over && Actioned[taskSelected]);
        ////}

        private static void menu()
        {
            Console.Clear();
            Console.WriteLine("List of tasks");
            Console.WriteLine("\n");
            Console.WriteLine("1. Put in a new task");
            Console.WriteLine("2. View tasks");
            Console.WriteLine("3. Remove task");
            Console.WriteLine("4. Complete task");
            Console.WriteLine("0. Exit");
        }

        private static void displayTasks(List<string> task)
        {
            Console.Clear();

            for (int i = 0; i < task.Count; ++i)
            {
                Console.WriteLine($"{i + 1}. {task[i]}");
            }

            Console.WriteLine("Press any key to return home");
            Console.ReadKey();
        }

        private static void invalidInput()
        {
            Console.WriteLine("Wrong key dude, press anything to try again");
            Console.ReadKey();
        }

        private static void addtask(List<string> task)
        {
            Console.WriteLine("Enter a new task: ");
            var newTask = Console.ReadLine();
            task.Add(newTask);
            Console.WriteLine("Enter another task? y/n");
            var y = Console.ReadLine();
            while (y == "y")
            {
                Console.Clear();
                Console.WriteLine("Enter a new task: ");
                var Task = Console.ReadLine();
                task.Add(Task);
                Console.WriteLine("Enter another task? y/n");
                var x = Console.ReadLine();
                if (x == "n")
                {
                    break;
                }
            }



        }

        private static void deleteItem(List<string> task)
        {
            Console.WriteLine("Enter # task to remove");
            if (int.TryParse(Console.ReadLine(), out int selection))
            {

                if (selection <= task.Count && selection >= 0)
                {
                    task.RemoveAt(selection - 1);
                    Console.WriteLine("Remove another? y/n");
                    var rem = Console.ReadLine();

                    while (rem == "y")
                    {
                        Console.Clear();
                        Console.WriteLine("Enter # task to remove");
                        var select = int.Parse(Console.ReadLine());

                        if (select <= task.Count && select >= 0)
                        {
                            task.RemoveAt(selection - 1);
                            Console.WriteLine("Remove another? y/n");
                            var remo = Console.ReadLine();

                            if (remo == "n")
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Item is not on the list, Press enter to try again");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid press enter to try again");
                Console.ReadKey();
            }
        }

        //private static void CompleteTask()
        //{
        //    //Console.Clear();

        //    //for (int i = 0; i < Actioned.Count; ++i)
        //    //{
        //    //    if (Actioned[i])
        //    //    {
        //    //        Console.ForegroundColor = ConsoleColor.DarkGray;
        //    //    }
        //    //    else if (i == taskSelected)
        //    //    {
        //    //        Console.BackgroundColor = ConsoleColor.Gray;
        //    //        Console.ForegroundColor = ConsoleColor.Black;


        //    //        Console.WriteLine(Actioned[i]);

        //    //        Console.ForegroundColor = ConsoleColor.Gray;
        //    //        Console.BackgroundColor = ConsoleColor.Black;

        //    //    }

        //    //    Console.WriteLine();
        //    //}
        //}
    }
}
