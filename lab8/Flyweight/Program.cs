using System;
using System.Collections;

namespace FlyweightBooks
{
    // Flyweight
    abstract class Book
    {
        protected string title;
        protected string author;

        public abstract void Display(int id);
    }

    class BookFactory
    {
        private Hashtable books = new Hashtable();

        public Book GetBook(string key)
        {
            Book book = books[key] as Book;

            if (book == null)
            {
                string[] data = key.Split('|');

                string title = data[0];
                string author = data[1];

                book = new ConcreteBook(title, author);

                books.Add(key, book);
            }

            return book;
        }
    }

    class ConcreteBook : Book
    {
        public ConcreteBook(string title, string author)
        {
            this.title = title;
            this.author = author;
        }

        public override void Display(int id)
        {
            Console.WriteLine($"Book ID: {id}, Title: {title}, Author: {author}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BookFactory factory = new BookFactory();

            int id = 0;

            string[] requests =
            {
                "Harry Potter|Rowling",
                "Harry Potter|Rowling",
                "Lord of the Rings|Tolkien",
                "Harry Potter|Rowling",
                "Lord of the Rings|Tolkien"
            };

            foreach (string req in requests)
            {
                id++;
                Book book = factory.GetBook(req);
                book.Display(id);
                //Console.WriteLine(book.GetHashCode());
            }

            Console.Read();
        }
    }
}