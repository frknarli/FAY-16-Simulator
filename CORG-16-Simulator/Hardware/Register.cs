using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORG_16_Simulator.Hardware
{
    public class Register
    {
        public Register(string name, sbyte value, int index)
        {
            Name = name;
            Value = value;
            Index = index;
        }

        public string Name { get; set; }
        public sbyte Value { get; set; }
        public int Index { get; set; }

    }
}
