using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Books
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
            Console.WriteLine($"Book Name: {BookName}, Author Name: {AuthorName}");
        }
    }

    public class BookShelf
    {
        private Books[] bookArray = new Books[5];

        public Books this[int index]
        {
            get { return bookArray[index]; }
            set { bookArray[index] = value; }
        }

        public void DisplayBooks()
        {
            foreach (var book in bookArray)
            {
                book?.Display();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            BookShelf shelf = new BookShelf();

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter the name of Book {i + 1}: ");
                string bookName = Console.ReadLine();

                Console.Write($"Enter the author of Book {i + 1}: ");
                string authorName = Console.ReadLine();

                shelf[i] = new Books(bookName, authorName);
            }

            Console.WriteLine("\nDisplaying all books:");
            shelf.DisplayBooks();
            Console.Read();
        }
        
    }
}
