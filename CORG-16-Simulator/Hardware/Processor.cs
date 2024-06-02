using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORG_16_Simulator.Hardware
{
    public class Processor
    {
        public sbyte lo, hi;
        public void SetRegister(string reg, sbyte num, List<Register> registers)
        {

            if (reg == "zero")
            {
                var register = registers.Where(x => x.Name == "r0").FirstOrDefault();
                register.Value = 0;

            }
            else
            {
                var register = registers.Where(x => x.Name == reg).FirstOrDefault();
                register.Value = num;

            }
        }

        public sbyte GetRegister(string reg, List<Register> registers)
        {
            if (reg == "zero," || reg == "zero")
                return 0;
            return registers.Where(x => x.Name == reg).FirstOrDefault().Value;
        }

        public void SetInstructionMemory(int address, short num, List<Address> addresses)
        {
            var addressObj = addresses.Where(x => x.Name == address).FirstOrDefault();
            addressObj.Value = num;
        }

        public void SetDataMemory(int address, short num, List<Address> memoryAddresses)
        {
            var addressObj = memoryAddresses.Where(x => x.Name == address).FirstOrDefault();
            addressObj.Value = num;
        }

        public void SetLo(sbyte num, List<Register> lohi)
        {
            var lo = lohi.Where(x => x.Name == "lo").FirstOrDefault();
            lo.Value = num;

        }

        public void SetHi(sbyte num, List<Register> lohi)
        {
            var hi = lohi.Where(x => x.Name == "hi").FirstOrDefault();
            hi.Value = num;
        }

        public sbyte GetLo(List<Register> lohi)
        {

            return lohi.Where(x => x.Name == "lo").FirstOrDefault().Value;
        }

        public sbyte GetHi(List<Register> lohi)
        {

            return lohi.Where(x => x.Name == "hi").FirstOrDefault().Value;
        }
    }
}
