using System;

namespace BooksInventory
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //instantiate an instance of the context first
            BooksContext context = new BooksContext();

            //Ensures table context
            //creates one if it doesn't already exist
            context.Database.EnsureCreated();

            Console.WriteLine("Enter in a book title and author separated by a comma, to add in the database.");
            Console.WriteLine("Example: \"Harry Potter, J.K. Rowling\"");
            string bookEntry = Console.ReadLine();

            //Splits entry into parts
            string[] parts = bookEntry.Split(", ");
            if (parts.Length == 2)
            {
                //creates new book object
                book newBook = new book(parts[0], parts[1]);

                //adds newly created book instance to the context
                context.books.Add(newBook);

                //ask context to save any changes to the database
                context.SaveChanges();

                Console.WriteLine("Successfully added the book to the database.");
            }
            else
            {
                Console.WriteLine("Invalid entry, only input title and author of the book.");
            }

            Console.WriteLine("The current list of books are: ");

            foreach (book b in context.books)
            {
                Console.WriteLine("{0} - {1} | {2}",b.Id, b.Title, b.Author);
            }

        }

    }

}


