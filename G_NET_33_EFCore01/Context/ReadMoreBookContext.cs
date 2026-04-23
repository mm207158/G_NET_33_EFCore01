using G_NET_33_EFCore01.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_33_EFCore01.Context
{
    internal class ReadMoreBookContext:DbContext

    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseSqlServer("server=localhost\\SQLEXPRESS01; database=ReadMoreBookDb;trusted_Connection=true;trustServerCertificate=true");
        }
    }
}
