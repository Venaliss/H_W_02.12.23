using System;

namespace Tumakov.Tumakov_DZ_12._12._1
{
    class Program
    {
        static void Main()
        {
            ComplexNumber a = new ComplexNumber(1, 2);
            ComplexNumber b = new ComplexNumber(3, 4);

            ComplexNumber sum = a + b;
            ComplexNumber product = a * b;
            ComplexNumber difference = a - b;

            bool isEqual = a == b;

            Console.WriteLine($"Сумма: { sum}"); 
            Console.WriteLine($"Произведение: { product}"); 
            Console.WriteLine($"Разность: { difference}"); 
            Console.WriteLine($"Числа равны: { isEqual}");
            Console.ReadKey();
        }
    }
}
