using G_NET_33_EFCore01.Context;
using G_NET_33_EFCore01.Models;

namespace G_NET_33_EFCore01
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("   ReadMore Books - Database System");
            Console.WriteLine("===========================================\n");

            using var context = new ReadMoreBookContext();

            bool created = await context.Database.EnsureCreatedAsync();
            Console.WriteLine(created
                ? "  Database created successfully!\n"
                : "    Database already exists.\n");

            if (created)
            {
                var fiction = new Category
                {
                    Name = "Fiction",
                    Description = " short stories .",
                    IsActive = true
                };

                var sciTech = new Category
                {
                    Name = "Science & Technology",
                    Description = "Books covering scientific discoveries .",
                    IsActive = true
                };

                var orwell = new Author
                {
                    FirstName = "Mariam",
                    LastName = "Mahmoud",
                    Email = "mariam@authors.com",
                    Biography = "English novelist",
                    DateOfBirth = new DateOnly(2001, 6, 25)
                };

                var knuth = new Author
                {
                    FirstName = "Fatma",
                    LastName = "mahmoud",
                    Email = "fatma@gmail.com",
                    Biography = "Professor Computer Programming.",
                    DateOfBirth = new DateOnly(1938, 1, 10)
                };

                context.Categories.AddRange(fiction, sciTech);
                context.Authors.AddRange(orwell, knuth);
                await context.SaveChangesAsync();

                context.Books.AddRange(
                    new Book
                    {
                        Title = "1984",
                        ISBN = "978-0451524935",
                        Price = 9.99m,
                        NumberOfPages = 328,
                        YearPublished = 1949,
                        IsInStock = true,
                        AuthorId = orwell.Id,
                        CategoryId = fiction.Id
                    },
                    new Book
                    {
                        Title = "zoo",
                        ISBN = "978-04515-26342",
                        Price = 7.99m,
                        NumberOfPages = 140,
                        YearPublished = 1945,
                        IsInStock = false,
                        AuthorId = orwell.Id,
                        CategoryId = fiction.Id
                    },
                    new Book
                    {
                        Title = "The Art of Computer Programming, Vol. 1",
                        ISBN = "978-0201-896831",
                        Price = 59.99m,
                        NumberOfPages = 672,
                        YearPublished = 1968,
                        IsInStock = true,
                        AuthorId = knuth.Id,
                        CategoryId = sciTech.Id
                    }
                );

                await context.SaveChangesAsync();
                Console.WriteLine(" Sample data seeded.\n");
            }

            Console.WriteLine(">>> All Books in Inventory:");
            Console.WriteLine(new string('-', 65));

            var books = context.Books
                .Select(b => new
                {
                    b.Title,
                    b.ISBN,
                    b.Price,
                    b.NumberOfPages,
                    b.YearPublished,
                    b.IsInStock,
                    Author = (b.Author.FirstName ?? "") + " " + (b.Author.LastName ?? ""),
                    Category = b.Category.Name ?? "N/A"
                })
                .ToList();

            foreach (var book in books)
            {
                Console.WriteLine($"  Title      : {book.Title}");
                Console.WriteLine($"  ISBN       : {book.ISBN}");
                Console.WriteLine($"  Price      : ${book.Price:F2}");
                Console.WriteLine($"  Pages      : {book.NumberOfPages}");
                Console.WriteLine($"  Published  : {book.YearPublished}");
                Console.WriteLine($"  In Stock   : {(book.IsInStock ? "Yes" : "No")}");
                Console.WriteLine($"  Author     : {book.Author}");
                Console.WriteLine($"  Category   : {book.Category}");
                Console.WriteLine(new string('-', 65));
            }

            Console.WriteLine("\n>>> Authors:");
            foreach (var author in context.Authors.ToList())
            {
                Console.WriteLine($"  {author.FirstName} {author.LastName} | {author.Email} | DOB: {author.DateOfBirth}");
            }

            Console.WriteLine("\n>>> Categories:");
            foreach (var cat in context.Categories.ToList())
            {
                Console.WriteLine($"  {cat.Name} | Active: {cat.IsActive} | {cat.Description}");
            }

            Console.WriteLine("\n===========================================");
            Console.WriteLine("   Database demonstration complete!");
            Console.WriteLine("===========================================");
        }
    }
}