using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    public class Nano : BasicCar
    {
        public Nano(string m)
        {
            ModelName = m;
        }
        public override BasicCar Clone()
        {
            return (Nano)this.MemberwiseClone(); //shadow Clone
        }
    }
}
