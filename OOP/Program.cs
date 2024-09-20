using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using static System.Reflection.Metadata.BlobBuilder;

namespace OOP
{
    internal class Program
    {
        class Book
        {
            public string title { get; }
            public string author { get; }
            public string isbn { get; }
            public bool availability { get; set; }

            public Book(string title, string author, string isbn, bool availability = true)
            {
                this.title = title;
                this.author = author;
                this.isbn = isbn;
                this.availability = availability;
            }
        }
        class Library
        {
            public List<Book> books = new();
            public List<Book> AddBook(Book book)
            {
                books.Add(book);
                return books;
            }
            public bool BorrowBook(string title)
            {
                for (int i = 0; i < books.Count; i++)
                {
                    if (title == books[i].title)
                    {
                        Console.WriteLine("you can boorow it");
                        return books[i].availability = false;
                    }
                }
                Console.WriteLine("this book is not in the library");
                return false;
            }

            public void ReturnBook(string title)
            {
                for(int i=0; i<books.Count;i++)
                {
                    if (title == books[i].title && books[i].availability==false)
                    {
                        Console.WriteLine("The book can be returned");
                        books[i].availability = true;
                        return;
                    }
                }
                Console.WriteLine("The book isn't borrowed");
            }

        }
        static void Main(string[] args)
        {
            Library library = new Library();
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            bool x = library.BorrowBook("The Great Gatsby");
            bool y = library.BorrowBook("1984");
            bool z = library.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("The Great Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed
        }
    }
}
