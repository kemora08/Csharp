using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoItem
{
    class Program
    {
        internal class ToDoProgram
        {
            private static List<ToDoItem> ToDoList = new List<ToDoItem>();

            //ToDoItem item1 = new ToDoItem("Set Description Here", "Due/Date/Here", "Priority");
            private static bool quitProgram = false;

            private static bool continueProgram = true;

            public static void Main(string[] args)
            {
                Console.WriteLine("Press [Enter] to add item\nOtherwise press [Q] to quit");

                string quitInput = Console.ReadLine();
                quitInput.ToLower();

                do
                {
                    if (quitInput == "q")
                    {
                        quitProgram = true;
                        Console.WriteLine("Goodbye!");
                    }
                    else if (continueProgram == true)
                    {
                        Console.WriteLine("\nEnter in a Priority level (High, Medium, Low)");
                        string userPriority = Console.ReadLine();

                        Console.WriteLine("\nPlease enter in the task you need to do:");
                        string userDescription = Console.ReadLine();

                        Console.WriteLine("\nEnter in due date: ");
                        string userDueDate = Console.ReadLine();

                        

                        ToDoItem userItem = new ToDoItem(userPriority, userDescription, userDueDate);

                        ToDoList.Add(userItem);

                        Console.WriteLine("\nDo you want to enter in another item?");
                        string newItemInput = Console.ReadLine();
                        newItemInput.ToLower();

                        if (newItemInput == "Yes" || newItemInput == "Yes")
                        {
                            continueProgram = true;
                        }
                        else
                        {
                            foreach (ToDoItem Item in ToDoList)
                            {
                                Item.printItem();

                            }

                            Console.ReadLine();
                            quitProgram = true;
                        }
                    }

                } while (quitProgram == false);
            }

            public class ToDoItem
            {
                public string Priority { get; set; }
                public string Description { get; set; }
                public string DueDate { get; set; }

                public ToDoItem(string Priority, string Description, string DueDate)
                {
                    this.Priority = Priority;
                    this.Description = Description;
                    this.DueDate = DueDate;
                }

                public void printItem()
                {
                    Console.WriteLine("\n{0} | {1} | {2}\n", Priority, Description, DueDate);
                }
            }
        }
    }
}