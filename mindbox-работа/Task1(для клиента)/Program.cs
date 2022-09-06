using System;
using LibraryFigure;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Area_object
{
    class Program
    {
        static void Main(string[] args)
        {
            Figure[] figures = { new Triangle(10, 12, 17, MessageDialog),
                                 new Circle(6),
                                 new Circle(7),
                                 new Triangle(9, 10, 11, MessageDialog),
                                 new Triangle(6, 8, 10, MessageDialog) //Прямоугольный треугольник
            };
            foreach (var item in figures)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static void MessageDialog(string message) => Console.Write(message);
    }
}
