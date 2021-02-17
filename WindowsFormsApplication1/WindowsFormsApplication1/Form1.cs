using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string icnum_pass;
        private string filename;

        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //days
            double days = (dateTimePicker2.Value - dateTimePicker1.Value).TotalDays;

            //roomtype
            double SINGLE, roomprice;
            if (checkBox1.Checked)
            {
                SINGLE = 75;
            }
            else
            {
                SINGLE = 0;
            }

            double DOUBLE;
            if (checkBox2.Checked)
            {
                DOUBLE = 100;
            }
            else
            {
                DOUBLE = 0;
            }

            double TRIPLE;
            if (checkBox3.Checked)
            {
                TRIPLE = 150;
            }
            else
            {
                TRIPLE = 0;
            }

            double QUAD;
            if (checkBox4.Checked)
            {
                QUAD = 175;
            }
            else
            {
                QUAD = 0;
            }

            double QUEEN;
            if (checkBox5.Checked)
            {
                QUEEN = 200;
            }
            else
            {
                QUEEN = 0;
            }

            double KING;
            if (checkBox6.Checked)
            {
                KING = 250;
            }
            else
            {
                KING = 0;
            }
            roomprice = SINGLE + DOUBLE + TRIPLE + QUAD + QUEEN + KING;

            //package
            int counter = 0;
            double package_price = 0;
            foreach (Control package in groupBox2.Controls)
            {
                if (package is CheckBox)
                {
                    if (((CheckBox)package).Checked)
                    {
                        counter++;

                        switch (counter)
                        {
                            case 1:
                                package_price = 200;
                                break;

                            case 2:
                                package_price = 200;
                                break;

                            case 3:
                                package_price = 200;
                                break;

                            case 4:
                                package_price = 200;
                                break;

                            case 5:
                                package_price = 200;
                                break;

                            case 6:
                                package_price = 200;
                                break;

                            default:
                                package_price = 0;
                                break;
                        }
                    }
                }
            }

            //total price
            double total_price = 0;
            total_price = (days * roomprice) + package_price;

            //gst
            double total_tax, total_price_with_tax;

            total_tax = total_price * 6 / 100;
            total_price_with_tax = total_price + total_tax;

            //discount

            double discount, total_grand_price, disc_total;
            if (package_price > 0 && roomprice > 0)
            {
                discount = 10;
            }
            else
            {
                discount = 0;
            }

            disc_total = total_price * (discount / 100);
            total_grand_price = total_price - disc_total;

            //display
            textBox1.Text = total_price.ToString("N2");
            textBox2.Text = total_tax.ToString("N2");
            textBox3.Text = total_price_with_tax.ToString("N2");
            textBox4.Text = disc_total.ToString("N2");
            textBox5.Text = total_grand_price.ToString("N2");
        }

        public int total_grand_price(int total_price, int disc_total)
        {
            int total_grand_price;
            total_grand_price = total_price - disc_total;
            return total_grand_price;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox7.Text))
            {
                MessageBox.Show("Input Name And Ic Number");
            }

            else if (textBox6.Text == null)
            {
                MessageBox.Show("Input Name And Ic Number");
            }

            else if (textBox7.Text == null)
            {
                MessageBox.Show("Input Name And Ic Number");
            }

            else
            {
                string icnum;
                icnum = (textBox7.Text);
                icnum_pass = icnum;
                filename = @".\" + textBox7.Text + ".txt";
                if (File.Exists(filename) || !File.Exists(filename))
                {
                    File.Create(filename).Dispose();

                    File.WriteAllText(filename, "Name : " + textBox6.Text + Environment.NewLine + "Total price Per Night : " + textBox1.Text + Environment.NewLine + "Final Price With Tax: " + textBox3.Text + Environment.NewLine + "Total Grand Price:" + textBox5.Text);
                    this.Hide();

                    var receipts = new receipts();
                    receipts.Closed += (s, args) => this.Close();
                    receipts.Show();
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

