﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
/*
 Creating our Entity classes inside the "Models" folder:
 */
namespace EFGetStarted.Models
{
    // A table named "Blogs" that contains many posts
    public class Blog
    {
        // Creating the properties:
        // To recap: Type "prop" then TAB then TABBING to change each part:

        /*
        Code First Data Annotations:
        ****************************
        We can also use the annotations to provide more information to EF 
        about the classes and the database to which they map.

        we are decorating the property with the attribute [Key] (with capital "K")
        to indicate that it's a primary key

        Notice that adding the [Key] here is optional as by convention "Id" keyword means primary key
        Code First will look for a property named "Id", or a combination of class name and "Id", 
        such as "BlogId". This property will map to a primary key column in the database.
        */

        [Key]
        public int BlogId { get; set; } // The primary key => Blog + Id => BlogId

        /*
        Initializing the property "Name" with "null!"
        ---------------------------------------------
        Because in .NET6 and later, all projects enable nullable reference types by default.
        Otherwise, the complier gives warning because it CANNOT see where the non-nullable string name is initialized
        So we explicitly initializing the property as null by assigning the null! to the operator 
        */
        
        // public string Name { get; set; } = null!;
        
        /*
        To use a nullable reference type in our Model, 
        but we don't want to store "null" in the database,
        we can use the required attribute:
        */
        [Required]
        public string? Name { get; set; }
        public int Rating { get; set; }

        /*
        To summarize:  
        Using nullable and non-nullable reference type to define which DB field can be null or which one cannot:
        
        Case#1
        To define that this DB field can cannot be null:

        Examples:

        public string Name { get; set; } = null!;

        Since Name is non-nullable strings, 
        EF Core knows that when it creates the table, this column shouldn't allow null value.

        The other solution:

        [Required]
        public string? Name { get; set; }

        Case#2
        To define that this DB field can be null:
        
        public string? Name { get; set; }
        */

        /*
         Using generics as with Java,
         Creating a property "Posts" which is a list of "Post" datatype
         */
        public List<Post>? Posts { get; set; }
    }
}
