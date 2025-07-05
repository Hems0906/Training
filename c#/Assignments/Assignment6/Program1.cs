using System;


//1.Create a class called Books with BookName and AuthorName as members. Instantiate the class through constructor and also write a method Display() to display the details. 

//Create an Indexer of Books Object to store 5 books in a class called BookShelf.Using the indexer method assign values to the books and display the same.

//Hint(use Aggregation/composition)

class Books
{
    public string BookName;
    public string AuthorName;

    public Books(string bookName, string authorName)
    {
        BookName = bookName;
        AuthorName = authorName;
    }

    public void Display()
    {
        Console.WriteLine("Book Name: " + BookName + ", Author: " + AuthorName);
    }
}

class BookShelf
{
    private Books[] books = new Books[5];
    public Books this[int index]
    {
        get { return books[index]; }
        set { books[index] = value; }
    }
}

class Program1
{
    static void Main()
    {
        BookShelf shelf = new BookShelf();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Enter details for Book {i + 1}:");
            Console.Write("Book Name: ");
            string name = Console.ReadLine();
            Console.Write("Author Name: ");
            string author = Console.ReadLine();

            shelf[i] = new Books(name, author);
        }

        Console.WriteLine("--- Book Details ---");
        for (int i = 0; i < 5; i++)
        {
            shelf[i].Display();
        }
        Console.Read();
    }
}
