using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORG_16_Simulator.InstructionFields
{
    public class OpCode
    {
        //R-Types
        public static string Add = "0000";
        public static string Sub = "0000";
        public static string Or = "0000";
        public static string Xor = "0000";
        public static string And = "0000";
        public static string Mul = "0000";
        public static string Jr = "0000";
        public static string Slt = "0000";

        //I/R-Types
        public static string Lw = "0001";
        public static string Sw = "0010";
        public static string Beq = "0011";
        public static string Bne = "0100";
        public static string Addi = "0101";
        public static string Andi = "0110";
        public static string Muli = "0111";
        public static string Srl = "1000";
        public static string Sll = "1001";
        public static string Lui = "1010";
        public static string Slti = "1011";
        public static string Mflo = "1100";
        public static string Mfhi = "1101";

        //J-Types
        public static string J = "1110";
        public static string Jal = "1111";










        //public static string Sra = "000000";
        //public static string Div = "000000";
    }
}
