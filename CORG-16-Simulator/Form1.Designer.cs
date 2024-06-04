using System.Windows.Forms;

namespace CORG_16_Simulator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel5 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView3 = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memory_lbl = new System.Windows.Forms.Label();
            this.stck_lbl = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dm_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lineNumberRTB1 = new CORG_16_Simulator.LineNumberRTB();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Controls.Add(this.listView1);
            this.panel5.Location = new System.Drawing.Point(984, 67);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(409, 678);
            this.panel5.TabIndex = 3;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.Silver;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(409, 678);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Index";
            this.columnHeader5.Width = 54;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 57;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 400;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.listView2);
            this.panel1.Location = new System.Drawing.Point(12, 472);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 273);
            this.panel1.TabIndex = 0;
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.Color.Silver;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(335, 273);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Address";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Value";
            this.columnHeader4.Width = 265;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.listView3);
            this.panel2.Location = new System.Drawing.Point(374, 472);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(336, 273);
            this.panel2.TabIndex = 1;
            // 
            // listView3
            // 
            this.listView3.BackColor = System.Drawing.Color.Silver;
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
            this.listView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView3.FullRowSelect = true;
            this.listView3.GridLines = true;
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(0, 0);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(336, 273);
            this.listView3.TabIndex = 0;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Address";
            this.columnHeader6.Width = 70;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Value";
            this.columnHeader7.Width = 265;
            // 
            // memory_lbl
            // 
            this.memory_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.memory_lbl.AutoSize = true;
            this.memory_lbl.BackColor = System.Drawing.Color.GhostWhite;
            this.memory_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memory_lbl.Location = new System.Drawing.Point(14, 443);
            this.memory_lbl.Name = "memory_lbl";
            this.memory_lbl.Size = new System.Drawing.Size(144, 20);
            this.memory_lbl.TabIndex = 2;
            this.memory_lbl.Text = "Instruction Memory";
            this.memory_lbl.Click += new System.EventHandler(this.label1_Click);
            // 
            // stck_lbl
            // 
            this.stck_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stck_lbl.AutoSize = true;
            this.stck_lbl.BackColor = System.Drawing.Color.GhostWhite;
            this.stck_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stck_lbl.Location = new System.Drawing.Point(375, 443);
            this.stck_lbl.Name = "stck_lbl";
            this.stck_lbl.Size = new System.Drawing.Size(104, 20);
            this.stck_lbl.TabIndex = 2;
            this.stck_lbl.Text = "Data Memory";
            this.stck_lbl.Click += new System.EventHandler(this.label1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Ivory;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Location = new System.Drawing.Point(12, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 51);
            this.button3.TabIndex = 4;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Ivory;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Location = new System.Drawing.Point(86, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 51);
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.GhostWhite;
            this.button1.Location = new System.Drawing.Point(762, 515);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 62);
            this.button1.TabIndex = 5;
            this.button1.Text = "IM";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dm_btn
            // 
            this.dm_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dm_btn.BackColor = System.Drawing.Color.GhostWhite;
            this.dm_btn.Location = new System.Drawing.Point(863, 515);
            this.dm_btn.Name = "dm_btn";
            this.dm_btn.Size = new System.Drawing.Size(63, 62);
            this.dm_btn.TabIndex = 5;
            this.dm_btn.Text = "DM";
            this.dm_btn.UseVisualStyleBackColor = false;
            this.dm_btn.Click += new System.EventHandler(this.dm_btn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(737, 604);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "PC: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(737, 658);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "HI: ";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(737, 711);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "LO: ";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Ivory;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Location = new System.Drawing.Point(163, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 51);
            this.button4.TabIndex = 7;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(831, 529);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 37);
            this.label4.TabIndex = 6;
            this.label4.Text = "/";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.BackColor = System.Drawing.Color.GhostWhite;
            this.comboBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Decimal",
            "Hexadecimal",
            "Binary"});
            this.comboBox1.Location = new System.Drawing.Point(762, 472);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(164, 23);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.Text = "Decimal";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.lineNumberRTB1);
            this.panel3.Location = new System.Drawing.Point(12, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(945, 361);
            this.panel3.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.GhostWhite;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1154, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Register";
            // 
            // lineNumberRTB1
            // 
            this.lineNumberRTB1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineNumberRTB1.BackColor = System.Drawing.SystemColors.Window;
            this.lineNumberRTB1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lineNumberRTB1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineNumberRTB1.Location = new System.Drawing.Point(0, 0);
            this.lineNumberRTB1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.lineNumberRTB1.Name = "lineNumberRTB1";
            this.lineNumberRTB1.Size = new System.Drawing.Size(945, 361);
            this.lineNumberRTB1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(146)))), ((int)(((byte)(160)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1424, 771);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.stck_lbl);
            this.Controls.Add(this.dm_btn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.memory_lbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assembly IDE";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label memory_lbl;
        private System.Windows.Forms.Label stck_lbl;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button dm_btn;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListView listView1;
        public LineNumberRTB lineNumberRTB1;
        private Panel panel3;
        private Label label5;
    }
}

