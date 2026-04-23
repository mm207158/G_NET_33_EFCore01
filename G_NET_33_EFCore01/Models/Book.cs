using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_33_EFCore01.Models
{
    internal class Book
    {
        
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

       
        public string ISBN { get; set; } = string.Empty;

        
        public decimal Price { get; set; }

        
        public int NumberOfPages { get; set; }

        public int YearPublished { get; set; }

        
        public bool IsInStock { get; set; }

        
        public int AuthorId { get; set; }
        public Author? Author { get; set; } 
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
