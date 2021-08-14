using System;

namespace FacadePattern
{
    /*
     * Concept:
     *  This pattern supports loose coupling. With this pattern, you can emphasize the
     *  abstraction and hide the complex details by exposing a simple interface.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Facade Pattern Demo***\n");
            // creating robots
            RobotFacade rf1 = new RobotFacade();
            rf1.ConstructMilanoRobot();

            RobotFacade rf2 = new RobotFacade();
            rf2.ConstructRobonautRobot();

            // Destroying robots
            rf1.DestroyMilanoRobot();
            rf2.DestroyRobonauRobot();
            Console.ReadLine();
        }
    }
}
