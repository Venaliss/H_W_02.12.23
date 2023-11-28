using System;
using Tumakov.Tumakov_DZ_12._12._2;
using Tumakov.Tumakov_DZ_12._12._1;

namespace Tumakov.Tumakov_DZ_12._12._1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Д.З Тумаков 12.1 - На перегрузку операторов. Описать класс комплексных чисел.");
            ComplexNumber a = new ComplexNumber(1, 2);
            ComplexNumber b = new ComplexNumber(3, 4);

            ComplexNumber sum = a + b;
            ComplexNumber product = a * b;
            ComplexNumber difference = a - b;

            bool isEqual = a == b;

            Console.WriteLine($"Сумма: { sum}");
            Console.WriteLine($"Произведение: { product}");
            Console.WriteLine($"Разность: { difference}");
            Console.WriteLine($"Числа равны: { isEqual}\n");


            Console.WriteLine("Д.З Тумаков 12.2 - Написать делегат, с помощью которого реализуется сортировка книг.");
            Book[] books = new Book[]
            {
                new Book("Книга 1", "Автор 1", "Издательство 1"),
                new Book("Книга 3", "Автор 2", "Издательство 2"),
                new Book("Книга 2", "Автор 3", "Издательство 1")
            };
            
            BookContainer container = new BookContainer(books);

            Console.WriteLine("\nСортировка по названию книги");
            container.SortBooks((book1, book2) => book1.Title.CompareTo(book2.Title) < 0);
            container.PrintBooks();
            Console.WriteLine("\nСортировка по автору");
            container.SortBooks((book1, book2) => book1.Author.CompareTo(book2.Author) < 0);
            container.PrintBooks();
            Console.WriteLine("\nСортировка по издательству");
            container.SortBooks((book1, book2) => book1.Publisher.CompareTo(book2.Publisher) < 0);
            container.PrintBooks();
            Console.ReadKey();

        }
    }
}

