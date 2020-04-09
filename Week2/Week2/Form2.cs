using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week2
{
    public partial class Form2 : Form
    {
        public static int customerNumber;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && textBox1.Text != "")
            {
                customerNumber = Int32.Parse(textBox1.Text);
                Form1 form1 = new Form1();
                form1.Show();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
