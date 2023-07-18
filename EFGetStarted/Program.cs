using EFGetStarted.Data;
using EFGetStarted.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace EFGetStarted
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating the instance of our database:
            // var db = new BloggingContext();

            // or we can use the C# "using" decoration:
            using BloggingContext contextDb = new BloggingContext();
            /*
            using decoration: 
            ensures that the "BloggingContext" object is disposed properly when we're done using it
            */

            // In case if we use the DbPath:
            // Note: This sample requires the database to be created before running.
            Console.WriteLine($"Database Path (Main Program.cs): {contextDb.DbPath}");


            Console.WriteLine("Database Blogs Table: " + contextDb.Blogs);
            Console.WriteLine("Database Blogs Table: " + contextDb.Posts);

            Console.WriteLine("Querying the table blogs from our database:");
            

            /*
             Using C# code to query our database
             */
            // Create (adding) new blogs to blogs table:
            Console.WriteLine("Inserting a new blog");

            /*
            Our blogs table fields:
            - BlogId
            - Url
            - Rating
            */

            // Instead of Blog blog1 = new Blog() => we can use: Blog blog1 = new()
            Blog blog1 = new()
            {
                Url = "http://blogs.msdn.com/adonet",
                Rating = 7,
            };

            /*
            Using Add method of Blogs DB set property
            */
            contextDb.Blogs.Add( blog1 );

            // Creating a new blog category
            Blog blog2 = new()
            {
                Url = "https://www.pluralsight.com/resources/blog",
                Rating = 4,
            };
            /*
            Using Add method of the context object "contextDb"

            EF core can find that this entity "blog2" is a blog
            based on its type
           */
           contextDb.Add(blog2);


            /*
           After adding the entities, 
           finally we save them all
           */
            contextDb.SaveChanges();


            // Read from the "blogs" table:
            Console.WriteLine("Querying for a blog");
            var blog = contextDb.Blogs
                .OrderBy(b => b.BlogId)
                .First();

            // adding new posts to the post table:
            Post post1 = new()
            {
                Title = "Hello World",
                Content = "I wrote an app using EF Core!",
                BlogId = 1,
            };
            contextDb.Add(post1);

            Post post2 = new()
            {
                Title = "EF",
                Content = "EF is the Entity Framework in .NET Database Development",
                BlogId = 1,
            };
            contextDb.Add(post2);


            Post post3 = new()
            {
                Title = "EF with any Database",
                Content = "EF can work with any database",
                BlogId = 2,
            };
            contextDb.Add(post3);


            // Update
            //Console.WriteLine("Updating the blog and adding a post");
            //blog.Url = "https://devblogs.microsoft.com/dotnet";
            //blog.Posts.Add(
            //    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
            
            contextDb.SaveChanges();

            // Delete
            Console.WriteLine("Delete the blog");
            contextDb.Remove(blog);
            contextDb.SaveChanges();
        } // Main()
    } // class
} // namespace