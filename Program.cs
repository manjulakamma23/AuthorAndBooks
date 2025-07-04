// See https://aka.ms/new-console-template for more information
using LibraryManagementApp.Data;
using LibraryManagementApp.Models;
using Microsoft.EntityFrameworkCore;

using var context = new LibraryContext();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nLibrary Management");
            Console.WriteLine("1. Add Author");
            Console.WriteLine("2. Add Book");
            Console.WriteLine("3. List Authors");
            Console.WriteLine("4. List Books");
            Console.WriteLine("5. Update Book Title");
            Console.WriteLine("6. Delete Book");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddAuthor(context);
                    break;
                case "2":
                    AddBook(context);
                    break;
                case "3":
                    ListAuthors(context);
                    break;
                case "4":
                    ListBooks(context);
                    break;
                case "5":
                    UpdateBookTitle(context);
                    break;
                case "6":
                    DeleteBook(context);
                    break;
                case "7":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    

    static void AddAuthor(LibraryContext context)
    {
        Console.Write("Enter author name: ");
        var name = Console.ReadLine();
        Console.Write("Enter author email: ");
        var email = Console.ReadLine();

        var author = new Author { Name = name, Email = email };
        context.Authors.Add(author);
        context.SaveChanges();
        Console.WriteLine("Author added successfully.");
    }

    static void AddBook(LibraryContext context)
    {
        Console.Write("Enter book title: ");
        var title = Console.ReadLine();
        Console.Write("Enter year published: ");
        var year = int.Parse(Console.ReadLine());
        Console.Write("Enter author ID: ");
        var authorId = int.Parse(Console.ReadLine());

        var book = new Book { Title = title, YearPublished = year, AuthorId = authorId };
        context.Books.Add(book);
        context.SaveChanges();
        Console.WriteLine("Book added successfully.");
    }

    static void ListBooks(LibraryContext context)
    {
        var books = context.Books.Include(b => b.Author).ToList();
        foreach (var book in books)
        {
            Console.WriteLine($"ID: {book.BookId}, Title: {book.Title}, Year: {book.YearPublished}, Author: {book.Author.Name}");
        }
    }

    static void UpdateBookTitle(LibraryContext context)
    {
        Console.Write("Enter book ID: ");
        var id = int.Parse(Console.ReadLine());
        var book = context.Books.Find(id);

        if (book != null)
        {
            Console.Write("Enter new title: ");
            book.Title = Console.ReadLine();
            context.SaveChanges();
            Console.WriteLine("Book title updated.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }
static void ListAuthors(LibraryContext context)
{
    var authors = context.Authors.ToList();

    if (authors.Count == 0)
    {
        Console.WriteLine("No authors found.");
        return;
    }

    Console.WriteLine("\nAuthors:");
    foreach (var author in authors)
    {
        Console.WriteLine($"ID: {author.AuthorId}, Name: {author.Name}, Email: {author.Email}");
    }
}


static void DeleteBook(LibraryContext context)
    {
        Console.Write("Enter book ID: ");
        var id = int.Parse(Console.ReadLine());
        var book = context.Books.Find(id);

        if (book != null)
        {
            context.Books.Remove(book);
            context.SaveChanges();
            Console.WriteLine("Book deleted.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }


