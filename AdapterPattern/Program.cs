using System;

namespace Structure.AdapterPattern
{
    /*
     * GoF Definition:
     *  Convert the interface of a class into another interface that clients expect. The Adapter
     *  pattern lets classes work together that could not otherwise because of incompatible interfaces.
     */
    class Rect
    {

        public double length;

        public double width;
    }

    class Caculator
    {

        public double GetArea(Rect rect)
        {
            return rect.length * rect.width;
        }
    }

    class Triangle
    {

        public double baseT;

        public double height;
        public Triangle(int b, int h)
        {
            this.baseT = b;
            this.height = h;
        }
    }

    class CalculatorAdapter
    {

        public double GetArea(Triangle triangle) 
        {
            Caculator c = new Caculator();
            Rect rect = new Rect();
            rect.length = triangle.baseT;
            rect.width = triangle.height * 0.5;

            return c.GetArea(rect);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Adapter Pattern demo***\n");
            CalculatorAdapter cal = new CalculatorAdapter();
            Triangle t = new Triangle(20, 10);
            Console.WriteLine("Area of Triangle is: " + cal.GetArea(t) + " Square unit");
            Console.ReadKey();
        }
    }
}
