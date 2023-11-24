using System;


namespace Tumakov.Tumakov_DZ_12._12._1
{
    class ComplexNumber
    {
        public double Real { get; }
        public double Imaginary { get; }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            double real = a.Real + b.Real;
            double imaginary = a.Imaginary + b.Imaginary;
            return new ComplexNumber(real, imaginary);
        }
        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            double real = a.Real - b.Real;
            double imaginary = a.Imaginary - b.Imaginary;
            return new ComplexNumber(real, imaginary);
        }
        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            double real = a.Real * b.Real - a.Imaginary* b.Imaginary;
            double imaginary = a.Real * b.Imaginary + a.Imaginary * b.Real;
            return new ComplexNumber(real, imaginary);
        }
        public static bool operator ==(ComplexNumber a, ComplexNumber b)
        {
            return a.Real == b.Real && a.Imaginary == b.Imaginary;
        }

        public static bool operator !=(ComplexNumber a, ComplexNumber b)
        {
            return !(a == b);
        }
        public override string ToString()
        {
            return $"{ Real} + { Imaginary}i";
        }
    }
}
