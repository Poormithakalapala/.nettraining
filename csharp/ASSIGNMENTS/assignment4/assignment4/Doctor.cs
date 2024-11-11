using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
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
            Console.WriteLine($"Book Name: {BookName}, Author: {AuthorName}");
        }
    }
    public class BookShelf
    {
        Book[] books = new Book[5];
        public Book this[int index]
        {
            get { return books[index]; }
            set { books[index] = value; }
        }
        public void DisplayAllBooks()
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

    public class DoctorBook
    {
        public static void Main(string[] args)
        {
            BookShelf shelf = new BookShelf();
            shelf[0] = new Book("Mental Health", "KVR");
            shelf[1] = new Book("Science", "GVK");
            shelf[2] = new Book("YOGA", "Geetha");
            shelf.DisplayAllBooks();
            Console.Read();
        }
    }
}

