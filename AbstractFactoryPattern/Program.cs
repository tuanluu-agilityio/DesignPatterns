using System;

namespace AbstractFactoryPattern
{
    /*
     * An abstract factory is called a factory of factories. In this pattern, you provide a way to
     * encapsulate a group of individual factories that have a common theme. In this process,
     * you do not mention or specify their concrete classes.
     * 
     * This pattern helps you to interchange specific implementations without changing
     * the code that uses them, even at runtime. However, it may result in unnecessary
     * complexity and extra work. Even debugging becomes tough in some cases.
     */

    public interface IDog
    {
        void Speak();
        void Action();
    }

    public interface ITiger
    {
        void Speak();
        void Action();
    }

    #region Wild Animal collections
    class WildDog : IDog
    {
        public void Action()
        {
            Console.WriteLine("Wild Dogs prefer to roam freely in jungles.\n"); 
        }

        public void Speak()
        {
            Console.WriteLine("Wild Dog says: Bow-Wow.");
        }
    }

    class WildTiger : ITiger
    {
        public void Action()
        {
            Console.WriteLine("Wild Tigers prefer hunting in jungles.\n");
        }

        public void Speak()
        {
            Console.WriteLine("Wild Tiger says: Halum.");
        }
    }
    #endregion

    #region Pet Animal collections
    class PetDog : IDog
    {
        public void Action()
        {
            Console.WriteLine("Pet Dogs prefer to stay at home.\n");
        }

        public void Speak()
        {
            Console.WriteLine("Pet Dogs says: Bow-Wow.");
        }
    }

    class PetTiger : ITiger
    {
        public void Action()
        {
            Console.WriteLine("Pet Tigers play in animal circus.\n");
        }

        public void Speak()
        {
            Console.WriteLine("Pet Tigers says: Halum.");
        }
    }
    #endregion

    // Abstract Factory
    public interface IAnimalFactory
    {
        IDog GetDog();
        ITiger GetTiger();
    }

    // Concrete Factory-Wild Animal Factory
    public class WildAnimalFactrory : IAnimalFactory
    {
        public IDog GetDog()
        {
            return new WildDog();
        }

        public ITiger GetTiger()
        {
            return new WildTiger();
        }
    }

    // Concrete Factory-Pet Animal Factory
    public class PetAnimalFactory : IAnimalFactory
    {
        public IDog GetDog()
        {
            return new PetDog();
        }

        public ITiger GetTiger()
        {
            return new PetTiger();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Abstract Factory Pattern Demo***\n");

            // Making a wild dog through WildAnimalFactory
            IAnimalFactory wildAnimalFactory = new WildAnimalFactrory();
            IDog wildDog = wildAnimalFactory.GetDog();
            wildDog.Speak();
            wildDog.Action();

            // Making a wild tiger through WildAnimalFactory
            ITiger wildTiger = wildAnimalFactory.GetTiger();
            wildTiger.Speak();
            wildTiger.Action();

            Console.WriteLine("**********************");

            // Making a pet dog through PetAnimalFactory
            IAnimalFactory petAnimalFactory = new PetAnimalFactory();
            IDog petDog = petAnimalFactory.GetDog();
            petDog.Speak();
            petDog.Action();

            // Making a pet tiger through PetAnimalFactory
            ITiger petTiger = petAnimalFactory.GetTiger();
            petTiger.Speak();
            petTiger.Action();

            Console.ReadLine();
        }
    }
}
