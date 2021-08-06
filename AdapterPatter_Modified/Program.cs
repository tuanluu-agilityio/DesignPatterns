using System;

namespace AdapterPatter_Modified
{
    interface RectInterface
    {
        void AboutRectangle();
        double CalculateAreaOfRectangle();
    }

    class Rect : RectInterface
    {

        public double Length;

        public double Width;

        public Rect(double l, double w)
        {
            this.Length = l;
            this.Width = w;
        }


        public void AboutRectangle()
        {
            Console.WriteLine("Actually, I am a Rectangle");
        }

        public double CalculateAreaOfRectangle()
        {
            return Length * Width;
        }
    }

    interface TriInterface
    {
        void AboutTriangle();
        double CalculateAreaOfTriangle();
    }

    class Triangle : TriInterface
    {

        public double BaseLength;
        public double Height;
        public Triangle(double b, double h)
        {
            this.BaseLength = b;
            this.Height = h;
        }

        public void AboutTriangle()
        {
            Console.WriteLine("Actually, I am a Triangle");
        }

        public double CalculateAreaOfTriangle()
        {
            return 0.5 * BaseLength * Height;
        }
    }

    class TriangoleAdapter : RectInterface
    {
        Triangle triangle;
        public TriangoleAdapter(Triangle t)
        {
            this.triangle = t;
        }

        public void AboutRectangle()
        {
            triangle.AboutTriangle();
        }

        public double CalculateAreaOfRectangle()
        {
            return triangle.CalculateAreaOfTriangle();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Adapter Pattern Modified Demo***\n");

            Rect r = new Rect(20, 10);
            Console.WriteLine("Area of Rectangle is : {0} Square unit", r.CalculateAreaOfRectangle());

            Triangle t = new Triangle(20, 10);
            Console.WriteLine("Area of Triangle is: {0} Square unit", t.CalculateAreaOfTriangle());

            RectInterface adapter = new TriangoleAdapter(t);
            Console.WriteLine("Area of Triangle using the triangle adapter is: {0} Square unit", GetArea(adapter));

            Console.ReadKey();
        }

        static double GetArea(RectInterface r)
        {
            r.AboutRectangle();
            return r.CalculateAreaOfRectangle();
        }
    }
}
