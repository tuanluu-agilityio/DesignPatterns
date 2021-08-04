using System;
using System.Collections.Generic;

namespace BuilderPattern
{
    /// <summary>
    /// The Builder pattern is useful for creating complex objects that have multiple parts.
    /// The creation process of an object should be independent of these parts; in other words,
    /// the construction process does not care how these parts are assembled. In addition, you
    /// should be able to use the same construction process to create different representations 
    /// of the objects.
    /// 
    /// Real-Life example:
    ///     To complete an order for a computer, different hardware parts are assembled based on
    ///     customer preferences. For example, a customer can opt for a 500GB hard disk with an Intel
    ///     processor, and another customer can choose a 250GB hard disk with an AMD processor.
    /// </summary>
    interface IBuilder
    {
        void StartUpOperations();
        void BuildBody();
        void InsertWheels();
        void AddHeadlights();
        void EndOperations();
        Product GetVehicle();
    }

    class Car : IBuilder
    {
        private string brandName;
        private Product product;
        public Car(string brand)
        {
            product = new Product();
            this.brandName = brand;
        }
        public void AddHeadlights()
        {
            product.Add("2 Headlights are added");
        }

        public void BuildBody()
        {
            product.Add("This is a body of Car");
        }

        public void EndOperations()
        {
            // Nothing in this case
        }

        public Product GetVehicle()
        {
            return product;
        }

        public void InsertWheels()
        {
            product.Add("4 wheels are added");
        }

        public void StartUpOperations()
        {
            // starting with brandname
            product.Add(string.Format("Car Model name : {0}", this.brandName));
        }
    }

    // ConcretedBuilder:Motorcycle
    class MotorCycle : IBuilder
    {
        private string brandName;
        private Product product;
        public MotorCycle(string brand)
        {
            product = new Product();
            this.brandName = brand;
        }
        public void AddHeadlights()
        {
            product.Add("1 Headlights are added");
        }

        public void BuildBody()
        {
            product.Add("This is a body of a Motorcycle");
        }

        public void EndOperations()
        {
            // Finishing up with brandname
            product.Add(string.Format("Motorcycle Model name : {0}", this.brandName));
        }

        public Product GetVehicle()
        {
            return product;
        }

        public void InsertWheels()
        {
            product.Add("2 wheels are added");
        }

        public void StartUpOperations()
        {
            //Nothing in this case
        }
    }

    class Product
    {
        private LinkedList<string> parts;
        public Product()
        {
            parts = new LinkedList<string>();
        }

        public void Add(string part)
        {
            parts.AddLast(part);
        }

        public void Show()
        {
            Console.WriteLine("\n Product completed as below: ");
            foreach (string part in parts)
            {
                Console.WriteLine(part);
            }
        }
    }

    // Director
    class Director
    {
        IBuilder builder;
        // A series of steps-in real life, steps are complex.
        public void Construct(IBuilder builder)
        {
            this.builder = builder;
            builder.StartUpOperations();
            builder.BuildBody();
            builder.InsertWheels();
            builder.AddHeadlights();
            builder.EndOperations();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Builder Pattern Demo***");
            Director director = new Director();

            IBuilder b1 = new Car("Ford");
            IBuilder b2 = new MotorCycle("Honda");

            // Making Car
            director.Construct(b1);
            Product p1 = b1.GetVehicle();
            p1.Show();

            // Making Motorcycle
            director.Construct(b2);
            Product p2 = b2.GetVehicle();
            p2.Show();

            Console.ReadLine();
        }
    }
}
