using System;

namespace Assignment5
{
    public class Book
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Book(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine($"Book: {BookName}, Author: {AuthorName}");
        }
    }

    public class BookShelf
    {
        private Book[] books = new Book[5];

        public void AddBook(int index, string bookName, string authorName)
        {
            if (index < 0 || index >= books.Length)
                throw new IndexOutOfRangeException("Index out of range.");
            books[index] = new Book(bookName, authorName);
        }

        public Book this[int index]
        {
            get
            {
                if (index < 0 || index >= books.Length)
                    throw new IndexOutOfRangeException("Index out of range.");
                return books[index];
            }
        }

        public void DisplayBooks()
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null)
                {
                    books[i].Display();
                }
            }
        }
    }

    public class Program3
    {
        public static void Main()
        {
            BookShelf shelf = new BookShelf();

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter the name of book {i + 1}: ");
                string bookName = Console.ReadLine();

                Console.Write($"Enter the author of book {i + 1}: ");
                string authorName = Console.ReadLine();

                shelf.AddBook(i, bookName, authorName);
            }

            Console.WriteLine("Books in the shelf:");
            shelf.DisplayBooks();
            Console.Read();
        }
    }
}
