using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class receipts : Form
    {
        public receipts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintDialog dlg = new PrintDialog();
            dlg.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int ic;
            ic = int.Parse(textBox1.Text);
            string filename = filename = @".\" + ic + ".txt";
            if (File.Exists(filename))
            {
                string[] readText = File.ReadAllLines(filename);
                for (int i = 0; i < readText.Length; i++)
                {
                    listBox1.Items.Add(readText[i]);
                }
            }
            else
            {
                MessageBox.Show("PLEASE FILL IN CORRECT IC");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
