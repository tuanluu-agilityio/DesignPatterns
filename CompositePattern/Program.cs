using System;
using System.Collections.Generic;

namespace Structure.CompositePattern
{
    interface IEmployee
    {
        void PrintStructures();
    }

    class CompositeEmployee : IEmployee
    {
        private string name;
        private string dept;

        // the container for child objects
        private List<IEmployee> controls;

        //constructor
        public CompositeEmployee(string name, string dept)
        {
            this.name = name;
            this.dept = dept;
            controls = new List<IEmployee>();
        }


        public void Add(IEmployee e) 
        {
            controls.Add(e);
        }


        public void Remove(IEmployee e) 
        {
            controls.Remove(e);
        }

        public void PrintStructures()
        {
            Console.WriteLine("\t" + this.name + " works in " + this.dept);
            foreach (IEmployee e in controls)
            {
                e.PrintStructures();
            }
        }
    }

    class Employee : IEmployee
    {
        private string name;
        private string dept;

        // constructor
        public Employee(string name, string dept)
        {
            this.name = name;
            this.dept = dept;
        }

        public void PrintStructures() 
        {
            Console.WriteLine("\t\t" + this.name + " works  in " + this.dept);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Composite Pattern Demo ***");
            // Principal of the college
            CompositeEmployee principal = new CompositeEmployee("Dr.S.Som(Principal)", "Planning-Supervising-Managing");

            // The College has 2 head of departments-one from mathematics, one from computer sc.
            CompositeEmployee hodMaths = new CompositeEmployee("Mrs.S.Das(HOD-Maths)", "Maths");
            CompositeEmployee hodCompSc = new CompositeEmployee("Mr. V.Sarcar(HOD-CSE)", "Computer Sc.");

            // 2 other teachers works in Mathematics department
            Employee mathTeacher1 = new Employee("Math Teacher-1", "Maths");
            Employee mathTeacher2 = new Employee("Math Teacher-2", "Maths");

            // 3 other teachers works in Computer Sc. department
            Employee cseTeacher1 = new Employee("CSE Teacher-1", "Computer Sc.");
            Employee cseTeacher2 = new Employee("CSE Teacher-2", "Computer Sc.");
            Employee cseTeacher3 = new Employee("CSE Teacher-3", "Computer Sc.");

            // Teachers of Mathematics directly reports to HOD-Maths
            hodMaths.Add(mathTeacher1);
            hodMaths.Add(mathTeacher2);

            // Teachers of Computer Sc. directly reports to HOD-CSE
            hodCompSc.Add(cseTeacher1);
            hodCompSc.Add(cseTeacher2);
            hodCompSc.Add(cseTeacher3);

            // Principal is on top of college
            // HOD - Maths and Comp. Sc diretly reports to him
            principal.Add(hodMaths);
            principal.Add(hodCompSc);

            Console.WriteLine("\n Testing the structure of a Principal object");
            // Prints the complete structure
            principal.PrintStructures();

            Console.WriteLine("\n Testing the structure of a HOD object:");
            Console.WriteLine("Teachers working at Computer Science department:");
            // Prints the details of Computer Sc, department 
            hodCompSc.PrintStructures();

            // Leaf Node
            Console.WriteLine("\n Testing the structure of a leaf node:");
            mathTeacher1.PrintStructures();

            // Suppose, one computer teacher is leaving now from the organization
            hodCompSc.Remove(cseTeacher2);
            Console.WriteLine("\n After CSE Teacher-2 resigned, the organization has following members:");
            principal.PrintStructures();

            Console.ReadKey();

        }
    }
}
