using System;

namespace DecoratorPattern
{
    /*
     * Concept:
     *      This pattern promotes the concept that your class should be closed for modification
     *      but open for extension. In other words, you can add a functionality without disturbing
     *      the existing functionalities. The concept is useful when you want to add some special 
     *      functionality to a specific object instead of the whole class. This pattern prefers object
     *      composition over inheritance. Once you master this technique, you can add new
     *      responsibilities to an object without affecting the underlying classes.
     */

    abstract class Component
    {
        public abstract void MakeHouse();
    }


    class ConcreteComponent : Component
    {
        public override void MakeHouse()
        {
            Console.WriteLine("Original House is complete. It is closed for modification");
        }
    }

    abstract class AbstractDecorator : Component
    {
        protected Component com;

        public void SetTheComponent(Component c) 
        {
            com = c;
        }

        public override void MakeHouse()
        {
            if (com != null)
            {
                com.MakeHouse();
            }
        }
    }

    class ConcreteDecoratorEx1 : AbstractDecorator
    {
        public override void MakeHouse()
        {
            base.MakeHouse();
            Console.WriteLine("***Using a decorator");

            AddFloor();
        }

        private void AddFloor()
        {
            Console.WriteLine("I am making an additional floor on top of it.");
        }
    }

    class ConcreteDecoratorEx2 : AbstractDecorator
    {

        public override void MakeHouse() 
        {
            Console.WriteLine("");
            base.MakeHouse();
            Console.WriteLine("***Using another decorator***");
            // Decorating now.
            PaintTheHouse();
        }

        private void PaintTheHouse()
        {
            Console.WriteLine("Now I am painting the house.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Decorator pattern Demo***\n");
            ConcreteComponent cc = new ConcreteComponent();

            ConcreteDecoratorEx1 decorator1 = new ConcreteDecoratorEx1();
            decorator1.SetTheComponent(cc);
            decorator1.MakeHouse();

            ConcreteDecoratorEx2 decorator2 = new ConcreteDecoratorEx2();
            //Adding results from decorator1
            decorator2.SetTheComponent(decorator1);
            decorator2.MakeHouse();

            Console.ReadKey();
        }
    }
}
