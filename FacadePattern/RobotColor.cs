using System;
using System.Collections.Generic;
using System.Text;

namespace Structure.FacadePattern.RobotParts
{
    public class RobotColor
    {
        public void SetDefaultColor()
        {
            Console.WriteLine("This is steel color robot.");
        }


        public void SetGreenColor() 
        {
            Console.WriteLine("This is green color robot.");
        }
    }
}
