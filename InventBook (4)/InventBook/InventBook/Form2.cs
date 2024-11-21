using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventBook
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 ventana = new Form3();
            ventana.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 ventana = new Form4();
            ventana.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 ventana = new Form6();
            ventana.Visible = true;
        }
    }
}
