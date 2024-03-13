using System;
using System.Collections.Generic;

class Books
{
    public string BookName { get; set; }
    public string AuthorName { get; set; }

    public Books(string bookName, string authorName)
    {
        BookName = bookName;
        AuthorName = authorName;
    }

    public void Display()
    {
        Console.WriteLine($"Book Name: {BookName}\nAuthor Name: {AuthorName}");
    }
}

class BookShelf
{
    private List<Books> books = new List<Books>();

    public void AddBook(Books book)
    {
        books.Add(book);
    }

    public Books GetBook(int index)
    {
        return books[index];
    }

    public int BookCount()
    {
        return books.Count;
    }
}

class Program
{
    static void Main()
    {
        BookShelf shelf = new BookShelf();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Enter details for Book {i + 1}:");
            Console.Write("Book Name: ");
            string bookName = Console.ReadLine();
            Console.Write("Author Name: ");
            string authorName = Console.ReadLine();

            shelf.AddBook(new Books(bookName, authorName));
        }

        for (int i = 0; i < shelf.BookCount(); i++)
        {
            Console.WriteLine($"Book {i + 1}:");
            shelf.GetBook(i).Display();
            Console.WriteLine();
            Console.Read();
        }
    }
}