using EFGetStarted.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGetStarted.Data
{
    /*
    All Data Context extend the "DBContext" 
    */
    internal class BloggingContext : DbContext
    {
        /*
        This Constructor is needed for initializing Database connection
        */
        public BloggingContext()
        {
            /*       var folder = Environment.SpecialFolder.LocalApplicationData;
                     var path = Environment.GetFolderPath(folder);
                     DbPath = System.IO.Path.Join(path, "blogging.db");
            */
            DbPath = "Blogging.db";
        }

        /*
        > 2 Properties of type DBSet<>
        > Each DBSet is linked to a table in our database
        */
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        // We used VS IDE quick fix :-) to generate this property:
        public string DbPath { get; }

        /*
        Finally, overriding the configuration method "OnConfiguring":
        for configuring the EF to use a SQLite database file in the project folder:
        
        using the the method .UseSqlite() 
        Link: https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/connection-strings
         */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source=Blogging.db");

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
            optionsBuilder.UseSqlite($"Data Source=Blogging.db");
        }
        */
    } // class
} // namespace
