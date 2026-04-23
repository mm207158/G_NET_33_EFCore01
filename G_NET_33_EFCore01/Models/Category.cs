using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_33_EFCore01.Models
{
    internal class Category
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        
        public string? Description { get; set; }

        public bool IsActive { get; set; }

        
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
