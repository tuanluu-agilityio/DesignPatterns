using System;

namespace BridgePattern
{
    /*
     * Concept:
     *      This pattern is also known as the Handle/Body pattern. With it, you decouple an
     *      implementation class from an abstract class by providing a bridge between them.
     *      
     *      This bridge interface makes the functionality of concrete classes independent from
     *      the interface implementer classes. You can alter different kinds of classes structurally
     *      without affecting each other.
     */

    // Implementor
    public interface IState
    {
        void MoveState();
    }

    // ConcreteImplementor-1
    public class OnState : IState
    {
        public void MoveState()
        {
            Console.Write("On State");
        }
    }

    // ConcreteImplementor-2
    public class OffState : IState
    {
        public void MoveState()
        {
            Console.Write("Off State");
        }
    }

    // Abstraction
    public abstract class ElectronicGoods
    {
        // Composition - implementor
        protected IState state;

        // Alternative approach to properties:
        // we can also pass an implementor (as input argument) inside a
        // constructor.
        public IState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        abstract public void MoveToCurrentState();
    }

    // Refined Abstraction
    public class Television : ElectronicGoods
    {
        public override void MoveToCurrentState()
        {
            Console.Write("\n Television is functioning at : ");
            state.MoveState();
        }
    }

    public class VCD : ElectronicGoods
    {
        public override void MoveToCurrentState()
        {
            Console.Write("\n VCD is functioning at : ");
            state.MoveState();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Bridge Pattern Demo***");
            Console.WriteLine("\nDealing with a Television");

            ElectronicGoods eItem = new Television();
            IState presentState = new OnState();
            eItem.State = presentState;
            eItem.MoveToCurrentState();

            // Verifying Off state of the Television now
            presentState = new OffState();
            eItem.State = presentState;
            eItem.MoveToCurrentState();

            Console.WriteLine("\n\nDealing with a VCD:");
            presentState = new OnState();
            eItem = new VCD();
            eItem.State = presentState;
            eItem.MoveToCurrentState();

            presentState = new OffState();
            eItem.State = presentState;
            eItem.MoveToCurrentState();

            Console.ReadLine();
        }
    }
}
