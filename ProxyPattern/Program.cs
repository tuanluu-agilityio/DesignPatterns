using System;

namespace ProxyPattern
{
    /*
     * Concept:
     *      A proxy is basically a substitute for an intended object. When a client deals with a proxy
     *      object, it thinks that it is dealing with the actual object. You need to support this kind of
     *      design because dealing with an original object is not always possible. This is because of
     *      many factors such as security issues, for example. SO, in this pattern, you may want to
     *      use a class that can perform as an interface to something else.
     */

    /// <summary>
    /// Abstract class Subject
    /// </summary>
    public abstract class Subject
    {
        public abstract void DoSomeWork();
    }

    /// <summary>
    /// ConcreteSubject class
    /// </summary>
    public class ConcreteSubject : Subject
    {
        public override void DoSomeWork()
        {
            Console.WriteLine("ConcreteSubject.DoSomeWork()");
        }
    }

    /// <summary>
    /// Proxy class
    /// </summary>
    public class Proxy : Subject
    {
        Subject cs;
        public override void DoSomeWork()
        {
            Console.WriteLine("Proxy call happening now...");
            //Lazy initialization: We'll not instantiate until the method is
            //called
            if (cs == null)
            {
                cs = new ConcreteSubject();
            }
            cs.DoSomeWork();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Proxy Pattern Demo***\n");
            Proxy px = new Proxy();
            px.DoSomeWork();
            Console.ReadKey();
        }
    }
}
