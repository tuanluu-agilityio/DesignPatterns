using System;
using System.Collections.Generic;

namespace Structure.FlyweightPattern
{
    /*
     * Concept:
     *      - A flyweight is an object. It tries to minimize memory usage by sharing
     *      data as much as possible with other similar objects. Shared objects
     *      may try to allow their usage at fine granularities with minimum costs.
     *      - Two common terms are used in the previous extract: intrinsic and
     *      extrinsic. Intrinsic state is stored/shared in the flyweight object. On the
     *      other hand, client objects store the extrinsic state, and these objects
     *      are passed to a flyweight object when they invoke the operations.
     */

    /// <summary>
    /// The 'Flyweight' interface
    /// </summary>
    interface IRobot
    {
        void Print();
    }

    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    class SmallRobot : IRobot
    {
        public void Print()
        {
            Console.WriteLine("This is small Robot");
        }
    }

    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    class LargeRobot : IRobot
    {
        public void Print()
        {
            Console.WriteLine("I am a large Robot");
        }
    }

    class RobotFactory
    {
        Dictionary<string, IRobot> shapes = new Dictionary<string, IRobot>();

        public int TotalObjectsCreated
        {
            get { return shapes.Count; }
        }

        public IRobot GetRobotFromFactory(string robotType)
        {
            IRobot robotCategory = null;

            if (shapes.ContainsKey(robotType))
            {
                robotCategory = shapes[robotType];
            }
            else
            {
                switch (robotType)
                {
                    case "Small":
                        robotCategory = new SmallRobot();
                        shapes.Add("Small", robotCategory);
                        break;
                    case "Large":
                        robotCategory = new LargeRobot();
                        shapes.Add("Large", robotCategory);
                        break;
                    default:
                        throw new Exception("Robot Factory can create only small and large robots");
                }
            }

            return robotCategory;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Flyweight Pattern Demo***\n");
            RobotFactory myfactory = new RobotFactory();
            IRobot shape = myfactory.GetRobotFromFactory("Small");
            shape.Print();
            /*
             * Now we are trying to get the 2 more Small robots.
             * Note that: now onwards we need not create additional small
             * robots because we have already created on of this category
             */
            for (int i = 0; i < 2; i++)
            {
                shape = myfactory.GetRobotFromFactory("Small");
                shape.Print();
            }

            int NumOfDistinctRobots = myfactory.TotalObjectsCreated;
            Console.WriteLine("\n Now, total numbers of distinct robot object is = {0}\n", NumOfDistinctRobots);

            /*
             * Here we are trying to get the 5 more Large robots.
             * Note that: now onwards we need not create additional small
             * robots because we have already created one of this category
             */
            for (int i = 0; i < 5; i++)
            {
                shape = myfactory.GetRobotFromFactory("Large");
                shape.Print();
            }

            NumOfDistinctRobots = myfactory.TotalObjectsCreated;
            Console.WriteLine("\n Distinct Robot objects created till now = {0}", NumOfDistinctRobots);
            Console.ReadKey();
        }
    }
}
