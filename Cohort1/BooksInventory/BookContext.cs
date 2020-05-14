// add the following imports to the top for your file
using BooksInventory;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

class BooksContext : DbContext
{

    // This property corresponds to the table in our database
    public DbSet<book> books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // get the directory the code is being executed from
        DirectoryInfo ExecutionDirectory = new DirectoryInfo(AppContext.BaseDirectory);

        // get the base directory for the project
        DirectoryInfo ProjectBase = ExecutionDirectory.Parent.Parent.Parent;

        // add 'books.db' to the project directory
        string DatabaseFile = Path.Combine(ProjectBase.FullName, "books.db");

        // to check what the path of the file is, uncomment the file below
        //Console.WriteLine("using database file :"+DatabaseFile);

        optionsBuilder.UseSqlite("Data Source=" + DatabaseFile);
    }
}