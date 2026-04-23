using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_33_EFCore01.Models
{
    internal class Author
    {
        
        public int Id { get; set; }

        
        public string? FirstName { get; set; }
        public string ?LastName { get; set; } 
        public string ?Email { get; set; } 
        
        public string? Biography { get; set; }

        
        public DateOnly DateOfBirth { get; set; }

       
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
