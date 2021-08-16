using System;

namespace Creational.FactoryMethodPattern
{
    /*
     * Real-Life example:
     *      In a restaurant, based on customer inputs, a chef varies the taste of dished to make the
     *      final products.
    */   

    public interface IAnimal
    {
        void Speak();
        void Action();

        void Run();
    }

    public class Dog : IAnimal
    {
        public void Action()
        {
            Console.WriteLine("Dogs prefer barking...\n");
        }

        public void Run()
        {
            Console.WriteLine("Dogs running...");
        }

        public void Speak()
        {
            Console.WriteLine("Dogs says: Bow-Wow.");
        }
    }

    public class Tiger : IAnimal
    {
        public void Action()
        {
            Console.WriteLine("Tigers prefer hungting...\n");
        }

        public void Run()
        {
            Console.WriteLine("Tigers run too...");
        }

        public void Speak()
        {
            Console.WriteLine("Tiger says: Halum.");
        }
    }

    public abstract class IAnimalFactory
    {
        public IAnimal MakeAnimal()
        {
            Console.WriteLine("\n IAnimalFactory.MakeAnimal() - You cannot ignore parent rules.");
            IAnimal animal = CreateAnimal();
            animal.Speak();
            animal.Action();
            animal.Run();

            return animal;
        }
        public abstract IAnimal CreateAnimal();
    }

    public class DogFactory : IAnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            // creating a Dog
            return new Dog();
        }
    }

    public class TigerFactory : IAnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            // creating a Tiger
            return new Tiger();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Factory Pattern Demo***\n");

            // Creating a Tiger Factory
            IAnimalFactory tigerFactory = new TigerFactory();
            IAnimal aTiger = tigerFactory.MakeAnimal();

            // Creating a tiger using the Factory method
            //IAnimal aTiger = tigerFactory.CreateAnimal();
            //aTiger.Speak();
            //aTiger.Action();

            // Creating a DogFactory
            IAnimalFactory dogFactory = new DogFactory();
            IAnimal aDog = dogFactory.MakeAnimal();

            // Creating a dog using the Factory method
            //IAnimal aDog = dogFactory.CreateAnimal();
            //aDog.Speak();
            //aDog.Action();

            Console.ReadKey();
        }
    }
}
