using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGetStarted.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int BlogId { get; set; }

        /*
        Including the Blog property of "Blog" datatype 
        to represent the Foreign Key relationship to the "Blog" table in our Database

        Even if we omit this property, EF will create it automatically and it's called "Shadow Property"
        */
        public Blog? Blog { get; set; }
    }
}
