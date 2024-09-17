using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using static System.Reflection.Metadata.BlobBuilder;

namespace OOP
{
    internal class Program
    {
        class Book
        {
            public string title;
            public string author;
            public string isbn;

            public Book(string title, string author, string isbn)
            {
                this.title = title;
                this.author = author;
                this.isbn = isbn;
            }
        }
        class Library
        {
            public List<Book> books = new();
            public List<Book> borrowed = new();
            public List<Book> AddBook(Book book)
            {
                books.Add(book);
                return books;
            }
            public void BorrowBook(string title)
            {
               for(int i = 0; i<books.Count;i++)
                {
                    if (title == books[i].title)
                    {
                        borrowed.Add(books[i]);
                        Console.WriteLine("you can borrow it");
                        return;
                    }
                }
                Console.WriteLine("the book is not in the library");
            }
            public void ReturnBook(string title)
            {
                for (int i=0; i<borrowed.Count;i++ )
                {
                    if (title == borrowed[i].title)
                    {
                        Console.WriteLine("the book returned");
                        return;
                    }
                }
                Console.WriteLine("the book isnot borrowed");
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
            library.BorrowBook("The Great Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("The Great Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed
        }
    }
}
