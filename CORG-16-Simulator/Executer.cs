using CORG_16_Simulator.Hardware;
using CORG_16_Simulator.InstructionFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CORG_16_Simulator
{
    public class Executer
    {
        string _line;
        public Processor _processor;
        List<Register> _registers;
        List<Register> _lohi;
        List<Address> _instructionMemoryAddresses;
        List<Address> _dataMemoryAddresses;
        string src1, src2, dest;
        short val1, val2, val3;
        byte _pc = 0;
        int _dataMemoryCounter = 0;
        int _datamemoryLine = 0;



        public (int, int) ExecuteLineForDataMemory(string line, Processor processor, List<Address> dataMemory, int dataMemoryCounter, int dataMemoryLine)
        {
            _processor = processor;
            _dataMemoryAddresses = dataMemory;
            _dataMemoryCounter = dataMemoryCounter;
            _datamemoryLine = dataMemoryLine;

            if (line.Contains(".data"))
            {
                dataMemoryLine++;
            }
            else if (line.Contains(".word"))
            {
                if (line.Contains(","))
                {

                    string lineData = string.Join(" ", line.Split(' ').Skip(1));
                    lineData = lineData.Replace(".word ", "");
                    string[] data = lineData.Split(',');

                    foreach (var item in data)
                    {
                        _processor.SetDataMemory(dataMemoryCounter * 2, Convert.ToInt16(item), _dataMemoryAddresses);
                        dataMemoryCounter++;
                    }
                    dataMemoryLine++;
                }
                else
                {
                    _processor.SetDataMemory(dataMemoryCounter * 2, Convert.ToInt16(line.Split(' ')[2].Replace(".word ", "")), _dataMemoryAddresses);
                    dataMemoryCounter++;
                    dataMemoryLine++;
                }
            }
            
            return (dataMemoryCounter, dataMemoryLine);
        }

        public byte ExecuteLineByLine(string line, Processor processor, List<Register> registers, List<Address> instructionAddresses, List<Address> addressesDataMemory, byte pc, List<Register> lohi)
        {
            _line = line;
            _processor = processor;
            _registers = registers;
            _instructionMemoryAddresses = instructionAddresses;
            _pc = pc;
            _dataMemoryAddresses = addressesDataMemory;
            _lohi = lohi;
            if (line.Contains(":") && line.Length != 1 && !line.Contains("."))
            {

                pc = _instructionMemoryAddresses.Where(x => x.Label == line.Split(':')[0]).FirstOrDefault().Index;
                if (!line.Contains("Exit:"))
                    pc = DoOperations(line.Split(':')[1].Substring(1), pc);
                else
                    pc++;
            }
            else
            {
                pc = DoOperations(line, pc);
            }
            return pc;
        }


        private byte DoOperations(string line, byte pc)
        {
            try
            {

                int index = line.IndexOf(' ');

                if (index >= 0)
                {
                    string firstPart = line.Substring(0, index + 1);
                    string secondPart = line.Substring(index + 1).Replace(" ", "");

                    line = firstPart + secondPart;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            switch (line.Split(' ')[0])
            {
                case "add":
                    ExecuteLine(line, 1, "+", OpCode.Add, FuncCode.Add);
                    pc++;
                    break;

                case "sub":
                    ExecuteLine(line, 1, "-", OpCode.Sub, FuncCode.Sub);
                    pc++;
                    break;

                case "or":
                    ExecuteLine(line, 1, "|", OpCode.Or, FuncCode.Or);
                    pc++;
                    break;

                case "xor":
                    ExecuteLine(line, 1, "^", OpCode.Xor, FuncCode.Xor);
                    pc++;
                    break;

                case "and":
                    ExecuteLine(line, 1, "&", OpCode.And, FuncCode.And);
                    pc++;
                    break;

                case "mul":
                    ExecuteLine(line, 1, "*", OpCode.Mul, FuncCode.Mul);
                    pc++;
                    break;

                case "jr":
                    pc = (byte)(_processor.GetRegister("ra", _registers) / 2);
                    _processor.SetInstructionMemory(_pc * 2, SetInstructionMemoryForJR(OpCode.Jr, FuncCode.Jr), _instructionMemoryAddresses);
                    break;

                case "slt":
                    ExecuteLine(line, 1, "<", OpCode.Slt, FuncCode.Slt);
                    pc++;
                    break;

                case "lw":
                    ExecuteLoadWord(line);
                    pc++;
                    break;

                case "sw":
                    src1 = line.Split(' ')[1].Split(',')[0].Replace("$", "");
                    val1 = _processor.GetRegister(src1, _registers);
                    short src3 = Convert.ToInt16(line.Split(',')[1].Split('(')[0].Replace(")", ""));
                    val2 = src3;
                    src2 = line.Split(',')[1].Split('(')[1].Replace(")", "").Replace("$", "");
                    val3 = _processor.GetRegister(src2, _registers);
                    try
                    {
                        if (val2 + val3 > 254)
                        {
                            MessageBox.Show("You have gone beyond the boundaries of memory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {
                            var add = _dataMemoryAddresses.Where(x => x.Name == val3 + val2).FirstOrDefault();
                            add.Value = val1;
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("You have gone beyond the boundaries of memory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    _processor.SetInstructionMemory(_pc * 2, SetInstructionMemoryForSw(OpCode.Sw), _instructionMemoryAddresses);
                    pc++;
                    break;

                case "beq":

                    src1 = line.Split(' ')[1].Split(',')[0].Replace("$", "");
                    src2 = line.Split(',')[1].Replace("$", "");
                    dest = line.Split(',')[2].Replace("$", "");
                    val1 = _processor.GetRegister(src1, _registers);
                    val2 = _processor.GetRegister(src2, _registers);

                    if (val1 == val2)
                    {
                        _processor.SetInstructionMemory(pc * 2, SetInstructionMemoryForBranch(OpCode.Beq), _instructionMemoryAddresses);
                        pc = _instructionMemoryAddresses.Where(x => x.Label == dest).FirstOrDefault().Index;

                    }
                    else
                    {
                        _processor.SetInstructionMemory(pc * 2, SetInstructionMemoryForBranch(OpCode.Beq), _instructionMemoryAddresses);
                        pc++;
                    }

                    break;

                case "bne":
                    src1 = line.Split(' ')[1].Split(',')[0].Replace("$", "");
                    src2 = line.Split(',')[1].Replace("$", "");
                    dest = line.Split(',')[2].Replace("$", "");
                    val1 = _processor.GetRegister(src1, _registers);
                    val2 = _processor.GetRegister(src2, _registers);
                    if (val1 != val2)
                    {
                        _processor.SetInstructionMemory(pc * 2, SetInstructionMemoryForBranch(OpCode.Bne), _instructionMemoryAddresses);
                        pc = _instructionMemoryAddresses.Where(x => x.Label == dest).FirstOrDefault().Index;

                    }
                    else
                    {
                        _processor.SetInstructionMemory(pc * 2, SetInstructionMemoryForBranch(OpCode.Bne), _instructionMemoryAddresses);
                        pc++;
                    }

                    break;

                case "addi":
                    ExecuteLine(line, 0, "+", OpCode.Addi, null);
                    pc++;
                    break;

                case "andi":
                    ExecuteLine(line, 0, "&", OpCode.Andi, null);
                    pc++;
                    break;

                case "muli":
                    ExecuteLine(line, 0, "*", OpCode.Muli, null);
                    pc++;
                    break;

                case "srl":
                    ExecuteLine(line, 2, ">>", OpCode.Srl, null);
                    pc++;
                    break;

                case "sll":
                    ExecuteLine(line, 2, "<<", OpCode.Sll, null);
                    pc++;
                    break;

                case "lui":
                    ExecuteLui(line);
                    pc++;
                    break;

                case "slti":
                    ExecuteLine(line, 0, "<", OpCode.Slti, null);
                    pc++;
                    break;

                case "mfhi":
                    dest = line.Split(' ')[1].Replace("$", "");
                    var hi = _processor.GetHi(_lohi);
                    _processor.SetRegister(dest, hi, _registers);
                    _processor.SetInstructionMemory(_pc * 2, SetInstructionMemoryForMfhi(OpCode.Mfhi, OpCode.Mfhi), _instructionMemoryAddresses);
                    pc++;
                    break;

                case "mflo":
                    dest = line.Split(' ')[1].Replace("$", "");
                    var lo = _processor.GetLo(_lohi);
                    _processor.SetRegister(dest, lo, _registers);
                    _processor.SetInstructionMemory(_pc * 2, SetInstructionMemoryForMfhi(OpCode.Mfhi, OpCode.Mflo), _instructionMemoryAddresses);
                    pc++;
                    break;

                case "j":
                    pc = _instructionMemoryAddresses.Where(x => x.Label == line.Split(' ')[1]).FirstOrDefault().Index;
                    _processor.SetInstructionMemory(_pc * 2, SetInstructionMemoryJType(OpCode.J, line), _instructionMemoryAddresses);
                    break;

                case "jal":
                    pc = _instructionMemoryAddresses.Where(x => x.Label == line.Split(' ')[1]).FirstOrDefault().Index;
                    _processor.SetInstructionMemory(_pc * 2, SetInstructionMemoryJType(OpCode.Jal, line), _instructionMemoryAddresses);
                    _processor.SetRegister("ra", (sbyte)((_pc + 1) * 2), _registers);
                    break;


                //case "sra":
                //    ExecuteLine(line, 1, ">>>", OpCode.Sra, FuncCode.Sra);
                //    pc++;
                //    break;


                //case "mult":
                //    src1 = _line.Split(' ')[1].Split(',')[0].Replace("$", "");
                //    src2 = _line.Split(',')[1].Replace("$", "");
                //    val1 = _processor.GetRegister(src1, _registers);
                //    val2 = _processor.GetRegister(src2, _registers);
                //    var result32 = PerformOperation((a, b) => a * b);
                //    _processor.SetLo(result32, _lohi);
                //    string multResult64 = Convert.ToString(Convert.ToInt64(Convert.ToInt64(val1) * Convert.ToInt64(this.val2)), 2);
                //    if (multResult64.Length > 32)
                //    {
                //        string firstValue = multResult64.Substring(0, multResult64.Length - 32);
                //        _processor.SetHi(Convert.ToInt32(firstValue, 2), _lohi);
                //    }
                //    _processor.SetInstructionMemory(pc * 2, SetInstructionMemoryRType(OpCode.Mul, FuncCode.Mul), _instructionMemoryAddresses);
                //    pc++;
                //    break;

                //case "div":
                //    ExecuteLine(line, 1, "/", OpCode.Div, FuncCode.Div);
                //    pc++;
                //    break;
            }

            return pc;
        }

        private void ExecuteLui(string line)
        {
            src1 = line.Split(',')[1];
            dest = line.Split(' ')[1].Split(',')[0].Replace("$", "");
            val1 = Convert.ToInt16(src1, 16);

            _processor.SetRegister(dest, (sbyte)val1, _registers);
            _processor.SetInstructionMemory(_pc * 2, SetInstructionMemoryForLui(OpCode.Lui), _instructionMemoryAddresses);
        }

        private void ExecuteLoadWord(string line)
        {
            src2 = line.Split(',')[1].Split('(')[1].Replace(")", "").Replace("$", "");
            short src3 = Convert.ToInt16(line.Split(',')[1].Split('(')[0].Replace(")", ""));
            val3 = src3;
            dest = line.Split(' ')[1].Split(',')[0].Replace("$", "");
            val2 = _processor.GetRegister(src2, _registers);

            try
            {
                if (val2 + val3 > 254)
                {
                    MessageBox.Show("You have gone beyond the boundaries of memory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                    _processor.SetRegister(dest, (sbyte)_dataMemoryAddresses.Where(x => x.Name == val3 + val2).FirstOrDefault().Value, _registers);

            }
            catch (Exception)
            {

                MessageBox.Show("You have gone beyond the boundaries of memory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _processor.SetInstructionMemory(_pc * 2, SetInstructionMemoryForLw(OpCode.Lw), _instructionMemoryAddresses);
        }

        public void ExecuteLine(string line, int type, string ope, string opCode, string funcCode) //type 0 I, type 1 R
        {
            src1 = line.Split(',')[1].Replace("$", "");
            src2 = line.Split(',')[2].Replace("$", "");
            dest = line.Split(' ')[1].Split(',')[0].Replace("$", "");
            val1 = _processor.GetRegister(src1, _registers);

            if (type == 0)
            {
                try
                {
                    val2 = Convert.ToSByte(src2);

                    if ((val2 & 0xC0) != 0 && Math.Abs(val2) > 63) //6 bitten fazlaysa o sayının son 6 bitini al.
                    {
                        MessageBox.Show("Immediate field cannot exceed 6 bits. Therefore, for larger numbers, the last 6 bits will be taken and the operation will be performed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        val2 = (short)(val2 & 0x3F);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            else
                val2 = _processor.GetRegister(src2, _registers);

            sbyte result = 0;
            if (ope == "+")
                result = (sbyte)PerformOperation((a, b) => a + b);
            else if (ope == "-")
                result = (sbyte)PerformOperation((a, b) => a - b);
            else if (ope == "*")
            {
                result = (sbyte)PerformOperation((a, b) => a * b);
                _processor.SetLo(result, _lohi);
                string val2 = Convert.ToString(Convert.ToInt16(Convert.ToInt16(val1) * Convert.ToInt16(this.val2)), 2);
                if (val2.Length > 8)
                {
                    string valueAfter8 = val2.Substring(0, val2.Length - 8);
                    _processor.SetHi(Convert.ToSByte(valueAfter8, 2), _lohi);
                }

            }

            else if (ope == "<")
                result = (sbyte)(val1 < val2 ? 1 : 0);
            else if (ope == "&")
                result = (sbyte)PerformOperation((a, b) => a & b);
            else if (ope == "|")
                result = (sbyte)PerformOperation((a, b) => a | b);
            else if (ope == "^")
                result = (sbyte)PerformOperation((a, b) => a ^ b);
            else if (ope == "<<")
                result = (sbyte)(val1 << val2);
            else if (ope == ">>")
                result = (sbyte)(val1 >> val2);
            else if (ope == ">>>")
                result = (sbyte)ArithmeticShiftRight(val1, val2);
            else if (ope == "/")

            {
                result = (sbyte)PerformOperation((a, b) => a / b);
                _processor.SetLo((sbyte)(val1 / val2), _lohi);
                _processor.SetHi((sbyte)(val1 % val2), _lohi);
            }

            _processor.SetRegister(dest, result, _registers);
            _processor.SetInstructionMemory(_pc * 2, type == 0 ? SetInstructionMemoryForIType(opCode) : SetInstructionMemoryRType(opCode, funcCode), _instructionMemoryAddresses);
        }

        public delegate int MathOperation(int a, int b);

        public int PerformOperation(MathOperation operation)
        {
            return operation(val1, val2);
        }


        static string DecimalToTwosComplement(short num, int numBits)
        {
            // Check if the number is negative
            bool isNegative = num < 0;

            // Get the absolute value of the number
            int absNum = Math.Abs(num);

            // Convert the absolute value to binary
            string binary = Convert.ToString(absNum, 2).PadLeft(numBits, '0');

            // If the number is negative, take 2's complement
            if (isNegative)
            {
                // Invert all the bits
                char[] invertedBits = binary.Select(bit => bit == '0' ? '1' : '0').ToArray();

                // Add 1 to the inverted number
                bool carry = true;
                for (int i = invertedBits.Length - 1; i >= 0; i--)
                {
                    if (carry)
                    {
                        if (invertedBits[i] == '0')
                        {
                            invertedBits[i] = '1';
                            carry = false;
                        }
                        else
                        {
                            invertedBits[i] = '0';
                        }
                    }
                }

                // Combine the bits to get the 2's complement representation
                binary = new string(invertedBits);
            }

            return binary;
        }


        private short SetInstructionMemoryRType(string opCode, string funcCode)
        {
            string opc = opCode;
            string rs = Convert.ToString(Convert.ToInt16(_registers.Where(x => x.Name == src1).FirstOrDefault().Index.ToString()), 2).PadLeft(3, '0');
            string rt = Convert.ToString(Convert.ToInt16(_registers.Where(x => x.Name == src2).FirstOrDefault().Index.ToString()), 2).PadLeft(3, '0');
            string rd = Convert.ToString(Convert.ToInt16(_registers.Where(x => x.Name == dest).FirstOrDefault().Index.ToString()), 2).PadLeft(3, '0');
            string funct = funcCode;
            string instruction = opc + rs + rt + rd + funct;
            string hex = Convert.ToInt16(instruction, 2).ToString("X");
            return Convert.ToInt16(hex, 16);
        }


        private short SetInstructionMemoryForIType(string opCode)
        {
            try
            {

                string opc = opCode;
                string rs = Convert.ToString(Convert.ToInt16(_registers.Where(x => x.Name == src1).FirstOrDefault().Index.ToString()), 2).PadLeft(3, '0');
                string rt = _registers.Where(x => x.Name == dest).FirstOrDefault().Index.ToString();
                rt = Convert.ToString(Convert.ToInt16(rt), 2).PadLeft(3, '0');
                string im = "";

                if (val2 >= 0)
                {

                    im = Convert.ToString(Convert.ToInt16(val2), 2).PadLeft(6, '0');

                }
                else
                {
                    im = DecimalToTwosComplement(val2, 6);
                }
                string instruction = opc + rs + rt + im;


                string hex = Convert.ToInt16(instruction, 2).ToString("X");
                return Convert.ToInt16(hex, 16);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter a valid number.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            return 0;
        }

        private short SetInstructionMemoryForBranch(string opCode)
        {
            string opc = opCode;
            string rs = Convert.ToString(Convert.ToInt16(_registers.Where(x => x.Name == src1).FirstOrDefault().Index.ToString()), 2).PadLeft(3, '0');
            string rt = Convert.ToString(Convert.ToInt16(_registers.Where(x => x.Name == src2).FirstOrDefault().Index.ToString()), 2).PadLeft(3, '0');

            int index = _instructionMemoryAddresses.Where(x => x.Label == dest).FirstOrDefault().Index;
            int offset = index - (_pc + 1);
            string im = DecimalToTwosComplement((short)offset, 6);



            string instruction = opc + rs + rt + im;


            string hex = Convert.ToInt16(instruction, 2).ToString("X");
            return Convert.ToInt16(hex, 16);
        }

        private short SetInstructionMemoryForLui(string opCode)
        {
            string opc = opCode;
            string rs = "000";
            string rt = _registers.Where(x => x.Name == dest).FirstOrDefault().Index.ToString();
            rt = Convert.ToString(Convert.ToInt16(rt), 2).PadLeft(3, '0');
            string im = Convert.ToString(Convert.ToInt16(val1), 2).PadLeft(6, '0');
            string instruction = opc + rs + rt + im;

            string hex = Convert.ToInt16(instruction, 2).ToString("X");
            return Convert.ToInt16(hex, 16);
        }

        private short SetInstructionMemoryForLw(string opCode)
        {
            string opc = opCode;
            string rs = Convert.ToString(Convert.ToInt16(_registers.Where(x => x.Name == src2).FirstOrDefault().Index.ToString()), 2).PadLeft(3, '0');
            string rt = Convert.ToString(Convert.ToInt16(_registers.Where(x => x.Name == dest).FirstOrDefault().Index.ToString()), 2).PadLeft(3, '0');


            string im = "";
            if (val3 >= 0)
                im = Convert.ToString(Convert.ToInt16(val3), 2).PadLeft(6, '0');
            else
            {
                im = DecimalToTwosComplement(val3, 6);
            }
            string instruction = opc + rs + rt + im;

            string hex = Convert.ToInt16(instruction, 2).ToString("X");
            return Convert.ToInt16(hex, 16);
        }

        private short SetInstructionMemoryForSw(string opCode)
        {
            string opc = opCode;
            string rs = Convert.ToString(Convert.ToInt16(_registers.Where(x => x.Name == src2).FirstOrDefault().Index.ToString()), 2).PadLeft(3, '0');
            string rt = Convert.ToString(Convert.ToInt16(_registers.Where(x => x.Name == src1).FirstOrDefault().Index.ToString()), 2).PadLeft(3, '0');


            string im = "";
            if (val2 >= 0)
                im = Convert.ToString(Convert.ToInt16(val2), 2).PadLeft(6, '0');
            else
            {
                im = DecimalToTwosComplement(val2, 6);
            }
            string instruction = opc + rs + rt + im;

            string hex = Convert.ToInt16(instruction, 2).ToString("X");
            return Convert.ToInt16(hex, 16);
        }

        private short SetInstructionMemoryForJR(string opCode, string funcCode)
        {
            string opc = opCode;
            string rs = "111";
            string rt = "000";
            string rd = "000";
            string funct = funcCode;
            string instruction = opc + rs + rt + rd + funct;
            string hex = Convert.ToInt16(instruction, 2).ToString("X");
            return Convert.ToInt16(hex, 16);
        }

        private short SetInstructionMemoryForMfhi(string opCode, string funcCode)
        {
            string opc = opCode;
            string rs = Convert.ToString(Convert.ToInt16(_registers.Where(x => x.Name == dest).FirstOrDefault().Index.ToString()), 2).PadLeft(3, '0');
            string rt = "000";
            string im = "000000";
            string funct = funcCode;
            string instruction = opc + rs + rt + im;

            string hex = Convert.ToInt16(instruction, 2).ToString("X");
            return Convert.ToInt16(hex, 16);
        }

        private short SetInstructionMemoryJType(string opCode, string line)
        {
            string opc = opCode;
            dest = line.Split(' ')[1];
            string address = Convert.ToString(Convert.ToInt16(_instructionMemoryAddresses.Where(x => x.Label == dest).FirstOrDefault().Index * 2), 2).PadLeft(12, '0');
            string instruction = opc + address;
            string hex = Convert.ToInt16(instruction, 2).ToString("X");
            return Convert.ToInt16(hex, 16);
        }

        static int ArithmeticShiftRight(int value, int shiftAmount)
        {

            bool isNegative = (value & (1 << 15)) != 0;
            int shiftedValue = value >> shiftAmount;

            if (isNegative)
            {
                int mask = (1 << shiftAmount) - 1;
                shiftedValue |= mask << (16 - shiftAmount);

            }

            return shiftedValue;

        }
    }
}
