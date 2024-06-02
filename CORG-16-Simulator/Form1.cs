using CORG_16_Simulator.Hardware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Array = CORG_16_Simulator.Hardware.Array;

namespace CORG_16_Simulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //*** KULLANILACAK LİSTELER VE DEĞİŞKENLER TANIMLANDI
        List<Register> _registers = new List<Register>();
        List<Address> _instructionMemoryAddresses = new List<Address>();
        List<Address> _dataMemoryAddresses = new List<Address>();
        List<Array> _listArrayDataMemory = new List<Array>();
        Executer executer = new Executer();
        bool IsDecimal = true;
        List<Register> _lohi = new List<Register>();
        string[] code;
        byte pc = 0;
        int dataMemoryCounter = 0;
        int datamemoryLine = 0;
        int buttonClickCount = 0;


        //*** MEMORY STEP STEP ÇALIŞTIRMA FUNC
        public void StepDataMemory(int index)
        {
            code = richTextBox1.Lines;
            var exec = executer.ExecuteLineForDataMemory(code[index], new Processor(), _dataMemoryAddresses, dataMemoryCounter, datamemoryLine);
            dataMemoryCounter = exec.Item1;
            datamemoryLine = exec.Item2;
            UpdateDataMemoryListView();  // ADRES LİSTESİ GÜNCELLENDİ
        }


        //*** INSTRUCTION MEMORY STEP STEP ÇALIŞTIRMA FUNC
        public void Step(int index)
        {
            var richtextInstruction = richTextBox1.Lines.Where(x => !x.Contains(".")).ToArray();

            code = richtextInstruction;
            pc = executer.ExecuteLineByLine(code[_instructionMemoryAddresses.Where(x => x.Index == index).FirstOrDefault().Index], new Processor(), _registers, _instructionMemoryAddresses, _dataMemoryAddresses, pc, _lohi);
            UpdateRegisterListView();
            UpdateInstructionMemoryListView();
            UpdateDataMemoryListView();
            label1.Text = "PC: " + (pc * 4).ToString();
            label2.Text = "LO: " + executer._processor.GetLo(_lohi);
            label3.Text = "HI: " + executer._processor.GetHi(_lohi);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddRegisterAtStartUp();
            AddAddressAtStartUp();
        }

        private void AddAddressAtStartUp()
        {
            for (int i = 0; i < 256; i = i + 4)
            {
                _instructionMemoryAddresses.Add(new Address() { Name = i, Value = 0, Index = 0 });
                _dataMemoryAddresses.Add(new Address() { Name = i, Value = 0, Index = 0 });
            }

            _instructionMemoryAddresses.ForEach(_addresses =>
            {
                string[] rows = { _addresses.Name.ToString(), _addresses.Value.ToString() };
                listView2.Items.Add(new ListViewItem(rows));
            });
            _dataMemoryAddresses.ForEach(_addresses =>
            {
                string[] rows = { _addresses.Name.ToString(), _addresses.Value.ToString() };
                listView3.Items.Add(new ListViewItem(rows));
            });

        }


        private void AddRegisterAtStartUp()
        {
            listView1.Items.Clear();
            _registers.Add(new Register("zero", 0, 0));
            _registers.Add(new Register("r0", 0, 1));
            _registers.Add(new Register("r1", 0, 2));
            _registers.Add(new Register("r2", 0, 3));
            _registers.Add(new Register("r3", 0, 4));
            _registers.Add(new Register("r4", 0, 5));
            _registers.Add(new Register("sp", 0, 6));
            _registers.Add(new Register("ra", 0, 7));

            _lohi.Add(new Register("lo", 0, 8));
            _lohi.Add(new Register("hi", 0, 9));

            _registers.ForEach(x =>
            {
                string[] rows = { x.Index.ToString(), x.Name, x.Value.ToString() };
                listView1.Items.Add(new ListViewItem(rows));
            });

        }

        private void UpdateRegisterListView()
        {
            listView1.Items.Clear();
            _registers.ForEach(x =>
            {
                string[] rows = { x.Index.ToString(), x.Name, x.Value.ToString() };
                listView1.Items.Add(new ListViewItem(rows));
            });
        }

        private void UpdateInstructionMemoryListView()
        {
            listView2.Items.Clear();
            _instructionMemoryAddresses.ForEach(x =>
            {
                string[] rows = { x.Name.ToString(), x.Value.ToString() };
                listView2.Items.Add(new ListViewItem(rows));
            });

        }

        private void UpdateDataMemoryListView()
        {
            listView3.Items.Clear();
            _dataMemoryAddresses.ForEach(x =>
            {
                string[] rows = { x.Name.ToString(), x.Value.ToString() };
                listView3.Items.Add(new ListViewItem(rows));
            });
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView2.Visible = true;
            listView3.Visible = false;
        }

        private void dm_btn_Click(object sender, EventArgs e)
        {
            listView2.Visible = false;
            listView3.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //*** RUN BUTTON
        private void button3_Click_1(object sender, EventArgs e)
        {
            var richtextInstruction = richTextBox1.Lines.Where(x => !x.Contains(".")).ToList();

            if (!richtextInstruction.Any())
            {
                MessageBox.Show("Please enter some text.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Restart();


            for (int i = 0; i < richtextInstruction.Count; i++)
            {

                if (!richtextInstruction[i].Contains("."))
                {

                    _instructionMemoryAddresses[i].Index = (byte)i;

                    _instructionMemoryAddresses[i].Label = richtextInstruction[i].Split(' ')[0].Replace(":", "");

                    _instructionMemoryAddresses[i].Value = 0;
                    string[] rows = { _instructionMemoryAddresses[i].Index.ToString() };

                    listView4.Items.Add(new ListViewItem(rows));

                }

            }

            for (int i = 0; i < richTextBox1.Lines.Length; i++)
            {

                if (richTextBox1.Lines[i].Contains("."))

                    StepDataMemory(datamemoryLine);

            }

            do
            {

                if (!richtextInstruction[_instructionMemoryAddresses.Where(y => y.Name == pc * 4).FirstOrDefault().Index].Contains("."))

                    Step(pc);

            } while (_instructionMemoryAddresses.Where(x => x.Name == pc * 4).FirstOrDefault().Label != null);





            var richtextDataMemory = richTextBox1.Lines.Where(x => x.Contains(".word")).ToList();

            for (int i = 0; i < richtextDataMemory.Count; i++)
            {

                if (!richtextDataMemory[i].Contains(","))
                {

                    _listArrayDataMemory.Add(new Array
                    {

                        Name = richtextDataMemory[i].Split(':')[0],

                        Values = new int[] { Convert.ToInt32(richtextDataMemory[i].Split(' ')[2].Replace(".word ", "")) }

                    });

                }

                else
                {

                    string lineData = string.Join(" ", richtextDataMemory[i].Split(' ').Skip(1));

                    lineData = lineData.Replace(".word ", "");

                    string[] data = lineData.Split(',');

                    _listArrayDataMemory.Add(new Array
                    {

                        Name = richtextDataMemory[i].Split(':')[0],

                        Values = data.Select(x => Convert.ToInt32(x)).ToArray()

                    });

                }

            }

        }

        //*** STEP BUTTON
        private void button2_Click_1(object sender, EventArgs e)
        {

            List<string> richtextInstruction = new List<string>();

            richtextInstruction = richTextBox1.Lines.Where(x => !x.Contains(".")).ToList();

            if (!richtextInstruction.Any())
            {
                MessageBox.Show("Please enter some text.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            buttonClickCount++;

            if (buttonClickCount == 1)
            {
                Restart();

            }


            if (pc == 0)
            {

                _registers.ForEach(x => x.Value = 0);
                _dataMemoryAddresses.ForEach(x => x.Value = 0);
                _listArrayDataMemory.Clear();
                _instructionMemoryAddresses.ForEach(x => x.Value = 0);


                UpdateRegisterListView();
                UpdateInstructionMemoryListView();
                UpdateDataMemoryListView();

                for (int i = 0; i < richtextInstruction.Count; i++)
                {
                    if (!richtextInstruction[i].Contains("."))
                    {
                        _instructionMemoryAddresses[i].Index = (byte)i;
                        _instructionMemoryAddresses[i].Label = richtextInstruction[i].Split(' ')[0].Replace(":", "");
                        _instructionMemoryAddresses[i].Value = 0;

                        // Eğer butona ilk kez basıldıysa listView4'ü güncelle
                        if (buttonClickCount == 1)
                        {
                            string[] rows = { _instructionMemoryAddresses[i].Index.ToString() };
                            listView4.Items.Add(new ListViewItem(rows));
                        }
                    }
                }



                for (int i = 0; i < richTextBox1.Lines.Length; i++)
                {

                    if (richTextBox1.Lines[i].Contains("."))

                        StepDataMemory(datamemoryLine);

                }

            }



            if (!richtextInstruction[_instructionMemoryAddresses.Where(y => y.Name == pc * 4).FirstOrDefault().Index].Contains("."))
            {
                Step(pc);
            }

            if (_instructionMemoryAddresses.Where(x => x.Name == (pc) * 4).FirstOrDefault().Label == null)// son satıra geldiğinde step butonu pasif hale getir
            {
                button2.Enabled = false;
            }

            string valueToFind = (_instructionMemoryAddresses.Where(y => y.Name == (pc) * 4).FirstOrDefault().Name).ToString();

            string valueToFind2 = (_instructionMemoryAddresses.Where(y => y.Name == (pc) * 4).FirstOrDefault().Index).ToString();



            foreach (ListViewItem item in listView4.Items)
            {

                if (item.SubItems[0].Text == (Convert.ToInt32(valueToFind) / 4).ToString())
                {

                    item.BackColor = Color.Red;

                }
                else
                {

                    item.BackColor = Color.White;

                }

            }

            foreach (ListViewItem item in listView2.Items)
            {

                if (item.SubItems[0].Text == valueToFind)
                {

                    item.BackColor = Color.Red;

                    break;

                }

            }
            //comboBox1.Text = "Decimal";
        }

        private void button4_Click(object sender, EventArgs e) //Restart button
        {
            Restart();

            buttonClickCount = 0;

            button2.Enabled = true;

            listView3.Visible = true;
            listView2.Visible = true;

            richTextBox1.Clear();
        }

        private void Restart()
        {
            pc = 0;
            dataMemoryCounter = 0;
            datamemoryLine = 0;
            _registers.ForEach(x => x.Value = 0);
            _dataMemoryAddresses.ForEach(x => x.Value = 0);
            _listArrayDataMemory.Clear();
            _instructionMemoryAddresses.ForEach(x => { x.Value = 0; x.Label = null; });
            _lohi.ForEach(x => x.Value = 0);
            listView4.Items.Clear();


            UpdateRegisterListView();
            UpdateInstructionMemoryListView();
            UpdateDataMemoryListView();

            label1.Text = "PC: 0";
            label2.Text = "LO: 0";
            label3.Text = "HI: 0";
        }


        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedBase = comboBox1.SelectedItem.ToString();

            if (selectedBase == "Hexadecimal")
            {
                // Convert Decimal or Binary to Hexadecimal
                foreach (ListViewItem item in listView1.Items)
                {
                    string text = item.SubItems[2].Text;
                    sbyte decimalNumber;

                    if (text.StartsWith("0x"))
                    {
                        // Already in Hexadecimal, no conversion needed
                        continue;
                    }
                    else if (text.All(c => c == '0' || c == '1') && (text.Length == 8))
                    {
                        // Binary to Decimal
                        decimalNumber = Convert.ToSByte(text, 2);
                    }
                    else
                    {
                        // Decimal
                        decimalNumber = Convert.ToSByte(text);
                    }

                    string hexadecimalNumber = decimalNumber.ToString("X2");
                    item.SubItems[2].Text = "0x" + hexadecimalNumber.PadLeft(2, '0');
                }
                foreach (ListViewItem item in listView2.Items)
                {
                    string text = item.SubItems[1].Text;
                    short decimalNumber;

                    if (text.StartsWith("0x"))
                    {
                        // Already in Hexadecimal, no conversion needed
                        continue;
                    }
                    else if (text.All(c => c == '0' || c == '1') && (text.Length == 16))
                    {
                        // Binary to Decimal
                        decimalNumber = Convert.ToInt16(text, 2);
                    }
                    else
                    {
                        // Decimal
                        decimalNumber = Convert.ToInt16(text);
                    }

                    string hexadecimalNumber = decimalNumber.ToString("X4");
                    item.SubItems[1].Text = "0x" + hexadecimalNumber.PadLeft(4, '0');
                }
                foreach (ListViewItem item in listView3.Items)
                {
                    string text = item.SubItems[1].Text;
                    short decimalNumber;

                    if (text.StartsWith("0x"))
                    {
                        // Already in Hexadecimal, no conversion needed
                        continue;
                    }
                    else if (text.All(c => c == '0' || c == '1') && (text.Length == 16))
                    {
                        // Binary to Decimal
                        decimalNumber = Convert.ToInt16(text, 2);
                    }
                    else
                    {
                        // Decimal
                        decimalNumber = Convert.ToInt16(text);
                    }

                    string hexadecimalNumber = decimalNumber.ToString("X4");
                    item.SubItems[1].Text = "0x" + hexadecimalNumber.PadLeft(4, '0');
                }
            }
            else if (selectedBase == "Binary")
            {
                // Convert Decimal or Hexadecimal to Binary
                foreach (ListViewItem item in listView1.Items)
                {
                    string text = item.SubItems[2].Text;
                    sbyte decimalNumber;

                    if (text.StartsWith("0x"))
                    {
                        // Hexadecimal to Decimal
                        decimalNumber = Convert.ToSByte(text.Substring(2), 16);
                    }
                    else if (text.All(c => c == '0' || c == '1') && (text.Length == 8))
                    {
                        // Already in Binary, no conversion needed
                        continue;
                    }
                    else
                    {
                        // Decimal
                        decimalNumber = Convert.ToSByte(text);
                    }

                    string binaryNumber = Convert.ToString((byte)decimalNumber, 2).PadLeft(8, '0');
                    item.SubItems[2].Text = binaryNumber;
                }
                foreach (ListViewItem item in listView2.Items)
                {
                    string text = item.SubItems[1].Text;
                    short decimalNumber;

                    if (text.StartsWith("0x"))
                    {
                        // Hexadecimal to Decimal
                        decimalNumber = Convert.ToInt16(text.Substring(2), 16);
                    }
                    else if (text.All(c => c == '0' || c == '1') && (text.Length == 16))
                    {
                        // Already in Binary, no conversion needed
                        continue;
                    }
                    else
                    {
                        // Decimal
                        decimalNumber = Convert.ToInt16(text);
                    }

                    string binaryNumber = Convert.ToString(decimalNumber & 0xFFFF, 2).PadLeft(16, '0');
                    item.SubItems[1].Text = binaryNumber;
                }
                foreach (ListViewItem item in listView3.Items)
                {
                    string text = item.SubItems[1].Text;
                    short decimalNumber;

                    if (text.StartsWith("0x"))
                    {
                        // Hexadecimal to Decimal
                        decimalNumber = Convert.ToInt16(text.Substring(2), 16);
                    }
                    else if (text.All(c => c == '0' || c == '1') && (text.Length == 16))
                    {
                        // Already in Binary, no conversion needed
                        continue;
                    }
                    else
                    {
                        // Decimal
                        decimalNumber = Convert.ToInt16(text);
                    }

                    string binaryNumber = Convert.ToString(decimalNumber & 0xFFFF, 2).PadLeft(16, '0');
                    item.SubItems[1].Text = binaryNumber;
                }
            }
            else if (selectedBase == "Decimal")
            {
                // Convert Binary or Hexadecimal to Decimal
                foreach (ListViewItem item in listView1.Items)
                {
                    string text = item.SubItems[2].Text;
                    sbyte decimalNumber;

                    if (text.StartsWith("0x"))
                    {
                        decimalNumber = Convert.ToSByte(text.Substring(2), 16);
                    }
                    else if (text.All(c => c == '0' || c == '1') && (text.Length == 8))
                    {
                        decimalNumber = Convert.ToSByte(text, 2);
                    }
                    else
                    {
                        continue;
                    }

                    item.SubItems[2].Text = decimalNumber.ToString();
                }
                foreach (ListViewItem item in listView2.Items)
                {
                    string text = item.SubItems[1].Text;
                    short decimalNumber;

                    if (text.StartsWith("0x"))
                    {
                        decimalNumber = Convert.ToInt16(text.Substring(2), 16);
                    }
                    else if (text.All(c => c == '0' || c == '1') && (text.Length == 16))
                    {
                        decimalNumber = Convert.ToInt16(text, 2);
                    }
                    else
                    {
                        continue;
                    }

                    item.SubItems[1].Text = decimalNumber.ToString();
                }
                foreach (ListViewItem item in listView3.Items)
                {
                    string text = item.SubItems[1].Text;
                    short decimalNumber;

                    if (text.StartsWith("0x"))
                    {
                        decimalNumber = Convert.ToInt16(text.Substring(2), 16);
                    }
                    else if (text.All(c => c == '0' || c == '1') && (text.Length == 16))
                    {
                        decimalNumber = Convert.ToInt16(text, 2);
                    }
                    else
                    {
                        continue;
                    }

                    item.SubItems[1].Text = decimalNumber.ToString();
                }

            }
        }

    }
}
