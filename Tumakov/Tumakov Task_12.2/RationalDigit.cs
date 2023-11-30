using System;

namespace Tumakov.Tumakov_Task_12._2
{
    class RationalDigit
    {
        private int numerator;
        private int denominator;

        public RationalDigit(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new Exception("Знаменатель не может равняться нулю(0).");

            this.numerator = numerator;
            this.denominator = denominator;
        }
        public override string ToString()
        {
            return numerator + "/" + denominator;
        }
        /*Переопределяем оператор ==*/
        public static bool operator ==(RationalDigit r1, RationalDigit r2)
        {
            if (object.ReferenceEquals(r1, null))
                return object.ReferenceEquals(r2, null);

            return r1.Equals(r2);
        }
        /*Переопределяем оператор !=*/
        public static bool operator !=(RationalDigit r1, RationalDigit r2)
        {
            return !(r1 == r2);
        }
        /*Переопределяем метод Equals*/
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is RationalDigit))
                return false;

            RationalDigit other = (RationalDigit)obj;
            return numerator == other.numerator && denominator == other.denominator;
        }
        /*Переопределяем оператор <*/
        public static bool operator <(RationalDigit r1, RationalDigit r2)
        {
            return r1.numerator * r2.denominator < r2.numerator * r1.denominator;
        }
        /*Переопределяем оператор >*/
        public static bool operator >(RationalDigit r1, RationalDigit r2)
        {
            return r1.numerator * r2.denominator > r2.numerator * r1.denominator;
        }
        /*Переопределяем оператор <=*/
        public static bool operator <=(RationalDigit r1, RationalDigit r2)
        {
            return r1.numerator * r2.denominator <= r2.numerator * r1.denominator;
        }
        /*Переопределяем оператор >=*/
        public static bool operator >=(RationalDigit r1, RationalDigit r2)
        {
            return r1.numerator * r2.denominator >= r2.numerator * r1.denominator;
        }
        /*Переопределяем оператор +*/
        public static RationalDigit operator +(RationalDigit r1, RationalDigit r2)
        {
            int newNumerator = r1.numerator * r2.denominator + r2.numerator * r1.denominator;
            int newDenominator = r1.denominator * r2.denominator;
            return new RationalDigit(newNumerator, newDenominator);
        }
        /*Переопределяем оператор -*/
        public static RationalDigit operator -(RationalDigit r1, RationalDigit r2)
        {
            int newNumerator = r1.numerator * r2.denominator - r2.numerator * r1.denominator;
            int newDenominator = r1.denominator * r2.denominator;
            return new RationalDigit(newNumerator, newDenominator);
        }
        /*Переопределяем оператор ++*/
        public static RationalDigit operator ++(RationalDigit r)
        {
            return new RationalDigit(r.numerator + r.denominator, r.denominator);
        }
        /*Переопределяем оператор --*/
        public static RationalDigit operator --(RationalDigit r)
        {
            return new RationalDigit(r.numerator - r.denominator, r.denominator);
        }
        /*Переопределяем операторы преобразования float и int*/
        public static implicit operator RationalDigit(float f)
        {
            int numerator = (int)(f * 100);
            return new RationalDigit(numerator, 100);
        }
        public static explicit operator int(RationalDigit r)
        {
            return r.numerator / r.denominator;
        }
        /*Переопределяем оператор '*' */
        public static RationalDigit operator *(RationalDigit r1, RationalDigit r2)
        {
            int newNumerator = r1.numerator * r2.numerator;
            int newDenominator = r1.denominator * r2.denominator;
            return new RationalDigit(newNumerator, newDenominator);
        }
        /*Переопределяем оператор '/' */
        public static RationalDigit operator /(RationalDigit r1, RationalDigit r2)
        {
            int newNumerator = r1.numerator * r2.denominator;
            int newDenominator = r1.denominator * r2.numerator;
            return new RationalDigit(newNumerator, newDenominator);
        }
        /*Переопределяем оператор % */
        public static RationalDigit operator %(RationalDigit r1, RationalDigit r2)
        {
            int result = r1.numerator * r2.denominator % r2.numerator * r1.denominator;
            return new RationalDigit(result, r1.denominator * r2.denominator);
        }
    }
}
