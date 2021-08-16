using System;

namespace Creational.PrototypePattern
{
    class Program
    {
        /// <summary>
        /// This pattern provides an alternative method for instantiating new objects by copying or
        /// cloning an instance of an existing object. You can avoid the expense of creating a new instance using this concept.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("***Prototype Pattern Demo***\n");
            //Base or Original Copy
            BasicCar nano_base = new Nano("Green Nano")
            {
                Price = 100000
            };

            BasicCar ford_base = new Ford("Ford Yellow")
            {
                Price = 500000
            };

            BasicCar bc1;
            // Nano
            bc1 = nano_base.Clone();
            bc1.Price = nano_base.Price + BasicCar.SetPrice();

            Console.WriteLine("Car is: {0}, and it's price is Rs. {1}", bc1.ModelName, bc1.Price);

            // Ford
            bc1 = ford_base.Clone();
            bc1.Price = ford_base.Price + BasicCar.SetPrice();

            Console.WriteLine("Car is: {0}, and it's price is Rs. {1}", bc1.ModelName, bc1.Price);

            Console.ReadLine();
        }
    }
}
