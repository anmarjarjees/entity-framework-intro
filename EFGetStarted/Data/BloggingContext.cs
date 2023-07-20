using EFGetStarted.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGetStarted.Data
{
    /*
    Preparing the Context class for our database:
    The Context class derived from the "DBContext" class type
    "DBContext" is the base type for Entity Framework (EF) to query data from a database

    Always by convention => DatabaseName + the word "Context" => DatabaseNameContext
    Example: BloggingContext
    All Data Context extend the "DBContext" 
    */
    public class BloggingContext : DbContext
    {
        /*
        This Constructor is needed for specifying the database file path:
        Link: https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli#create-the-model
        */
        public BloggingContext()
        {
            // To understand the concepts start from the bottom:
            // NOTE: Using the default Windows "localApp":
            // :C:\Users\YourName\AppData\Local\blogging.db

            // 3. Getting the current project folder  
            // var folder = Environment.SpecialFolder.LocalApplicationData;

            // 2. Assign the current project folder to the "path" variable 
            // var path = Environment.GetFolderPath(folder);

            // 1. Using Path.Join() to link the database file "blogging.db"
            // with the current project path which is inside the variable "path"
            // DbPath = System.IO.Path.Join(path, "blogging.db");


            // Or using the current project folder (directory):
            // ************************************************
            // Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory?view=net-7.0

            string path = Directory.GetCurrentDirectory();
   
            DbPath = System.IO.Path.Join(path, "blogging.db");

            Console.WriteLine($"Database Path (BloggingContext.cs): {DbPath}");
        } // Constructor

        /*
        Adding 2 Properties of type DBSet<> which are the Model classes that we created
        > Each DBSet is build of type "Models" like in our case: Blog.cs and Post.cs
        > Each DBSet is linked to (represents) a table in our database
        > DBSet allows us to query inside each table of the corresponding model
        */
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        // We used VS IDE quick fix :-) to generate this property:
        public string DbPath { get; } = "";

        /*
        Finally, overriding the configuration method "OnConfiguring":
        for configuring the EF to use a SQLite database file in the project folder:
        
        using the the method .UseSqlite() 
        Link: https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/connection-strings
        */

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        // Link: https://learn.microsoft.com/en-us/ef/core/?WT.mc_id=EducationalEF-c9-niner#the-model
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}"); ;
        }

        // Or Using the short version:
        // ***************************
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source=:{DbPath}");
        */

        // If using SQL Server:
        /*
            optionsBuilder.UseSqlServer(
            @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True");
        */

        /*
        NOTE: 
        This application intentionally keeps things simple for clarity. 
        Connection strings should not be stored in the code for production applications.
        With ASP.NET, we use the JSON file "appsettings.json" for our application to save the connection string:

        "Server=(localdb)\\mssqllocaldb;Database=EFGetStarted.ConsoleApp.NewDb;Trusted_Connection=True;"
        */

        /*
        IMPORNTAT NOTE:
        ***************
        Notice the other alternative short way below:
        in such case no need for a constructor or a property for the "DbPath" :-)
         */
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
        */
    } // class
} // namespace
