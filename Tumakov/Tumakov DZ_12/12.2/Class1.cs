using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov.Tumakov_DZ_12._12._2
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }

        public Book(string title, string author, string publisher)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
        }
    }

    // Делегат для сравнения книг
    public delegate bool BookComparer(Book book1, Book book2);

    // Класс контейнера для множества книг
    public class BookContainer
    {
        private Book[] books;

        public BookContainer(Book[] books)
        {
            this.books = books;
        }

        public void SortBooks(BookComparer comparer)
        {
            Array.Sort(books, (book1, book2) => comparer(book1, book2) ? -1 : 1);
        }

        public void PrintBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} - {book.Author} - {book.Publisher}");
            }
        }
    }


}
