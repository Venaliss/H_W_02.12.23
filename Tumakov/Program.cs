using System;
using Tumakov.Tumakov_DZ_12._12._2;
using Tumakov.Tumakov_Task_11._1;
using Tumakov.Tumakov_Task_12._1;
using Tumakov.Tumakov_Task_12._2;

namespace Tumakov.Tumakov_DZ_12._12._1
{
    class Program
    {
        static void Main()
        {
            /*Упражнение Тумаков 11.1*/
            Console.WriteLine("Упражнение Тумаков 11.1 - Создать новый класс фабрику банковского счета. Изменить модификатор класса на internal.\nДобавить в фабричный класс перегруженные методы создания счета CreateAccount,которые бы вызывали конструктор класса банковский счет и возвращали номер созданного счета.Использовать Хеш-Таблицу\n");

            BankAccountFactory factory = new BankAccountFactory();

            /*Создаем новый аккаунт банка*/
            int AccountNumber = factory.CreateAccount();
            Console.WriteLine("Новый номер банковского счета: " + AccountNumber);

            /*Закрываем счет в банке*/
            factory.CloseAccount(AccountNumber);
            Console.WriteLine("Аккаунт закрыт.\n");



            /*Упражнение Тумаков 12.1*/
            Console.WriteLine("\nУпражнение Тумаков 12.1 - Для класса банковский счет переопределить операторы == и != для сравнения информации в двух счетах.Методы Equals и GetHashCode и ToString.\n");
            BankAccountOp account1 = new BankAccountOp
            {
                AccountNumber = "1564688451",
                AccountHolder = "Valery Scvorec",
                Balance = 175624
            };

            BankAccountOp account2 = new BankAccountOp
            {
                AccountNumber = "1564688451",
                AccountHolder = "Valery Scvorec",
                Balance = 175624
            };
            /*Сравниваем при помощи оператора ==*/
            bool Equal = account1 == account2;
            Console.WriteLine($"Счета являются одинаковыми: {Equal}\n");
            /*Метод Equals*/
            bool Equal2 = account1.Equals(account2);
            Console.WriteLine($"Счета являются одинаковыми: {Equal2}\n");
            /*Метод GetHashCode*/
            int HashCode = account1.GetHashCode();
            Console.WriteLine($"Hash Code: {HashCode}\n");
            /*Выводим информацию о счете*/
            Console.WriteLine(account1);



            /*Упражнение Тумаков 12.2 - Переопределение операторов для рациональных чисел*/
            Console.WriteLine("\nУпражнение Тумаков 12.2 - Переопределение операторов для рациональных чисел");
            RationalDigit r1 = new RationalDigit(1, 2);
            RationalDigit r2 = new RationalDigit(2, 3);
            Console.WriteLine($"{r1} == {r2} будет равно {r1 == r2}");
            Console.WriteLine($"{r1} != {r2} будет равно {r1 != r2}");
            Console.WriteLine($"{r1} < {r2} будет равно {r1 < r2}");
            Console.WriteLine($"{r1} > {r2} будет равно {r1 > r2}");
            Console.WriteLine($"{r1} <= {r2} будет равно {r1 <= r2}");
            Console.WriteLine($"{r1} >= {r2} будет равно {r1 >= r2}");
            Console.WriteLine($"{r1} + {r2} будет равно {r1 + r2}");
            Console.WriteLine($"{r1} - {r2} будет равно {r1 - r2}");
            Console.WriteLine($"{r1} ++ будет равно {++r1}");
            Console.WriteLine($"{r1} -- будет равно {--r1}");
            Console.WriteLine($"{r1} * {r2} будет равно {r1 * r2}");
            Console.WriteLine($"{r1} / {r2} будет равно {r1 / r2}");
            Console.WriteLine($"{r1} % {r2} будет равно {r1 % r2}");


            /*Домашнее задание Тумаков 12.1*/
            Console.WriteLine("\nД.З Тумаков 12.1 - На перегрузку операторов. Описать класс комплексных чисел.");
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



            /*Домашнее задание Тумаков 12.2*/
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

