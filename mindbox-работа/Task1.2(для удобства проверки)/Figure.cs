using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area_object
{
    public abstract class Figure
    {
        public Figure() { }
        public abstract double GetSquare();
    }

    delegate void MyMessage(string message);
    class Triangle : Figure
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;
        private readonly MyMessage message;
        //Определение, является ли треугольник прямоугольным. Формула Пифагора
        private bool ThisRightTriangle() => ((a * a + b * b == c * c) ||
            (a * a + c * c == b * b) || (b * b + c * c == a * a));

        public Triangle(double a, double b, double c, MyMessage message)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.message = message;
        }

        public override double GetSquare()
        {
            if (ThisRightTriangle())
            {
                if (c * c == a * a + b * b)
                    return (a * b) / 2;
                if (b * b == a * a + c * c)
                    return (a * c) / 2;
                if (a * a == b * b + c * c)
                    return (b * c) / 2;
            }
            else
            {
                //Формула герона
                double p = (a + b + c) / 2; //Полупериметр
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
            return 0;
        }

        public override string ToString()
        {
            if (ThisRightTriangle())
                message?.Invoke($"Треугольник со сторонами {a}, {b}, {c} является прямоугольным. ");
            return $"Площадь треугольника равна {GetSquare()}";
        }
    }
    class Circle : Figure
    {
        private readonly double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }
        public override double GetSquare() => Math.PI * radius * radius;
        public override string ToString() => $"Площадь круга равна {GetSquare()}. Радиус круга равен {radius}";
     }
}
