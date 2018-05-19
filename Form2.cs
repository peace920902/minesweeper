using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_3
{
    public partial class Form2 : Form
    {               
                             
        public Form2()
        {
            InitializeComponent();
        }
          
        Class2 addbomb = new Class2();

        private void button1_Click(object sender, EventArgs e)//初級
        {
            Form1 F1 = new Form1();
            F1.A = 9;
            F1.B = 9;
            F1.C = 10;
            this.Hide();
            F1.ShowDialog();           
            this.Close();
        }
        
        private void button2_Click(object sender, EventArgs e)//中級
        {            
            Form1 F1 = new Form1();
            F1.A = 16;
            F1.B = 16;
            F1.C = 40;
            this.Hide();
            F1.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)//高級
        {
            Form1 F1 = new Form1();
            F1.A = 30;
            F1.B = 16;
            F1.C = 99;
            this.Hide();
            F1.ShowDialog();
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)//自訂
        {
            Form1 F1 = new Form1();
            try
            {
                if (textBox1.Text == "")
                    MessageBox.Show("請輸入長度");
                if (textBox2.Text == "")
                    MessageBox.Show("請輸入寬度");
                if (textBox3.Text == "")
                    MessageBox.Show("請輸入炸彈數量");
                if (textBox1.Text != "0" && textBox2.Text != "0" && textBox3.Text != "0" &&
                    textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    F1.A = int.Parse(textBox1.Text);
                    F1.B = int.Parse(textBox2.Text);
                    F1.C = int.Parse(textBox3.Text);

                    if (int.Parse(textBox1.Text) < 9)//若長寬過高或過低
                        F1.A = 9;
                    if (int.Parse(textBox1.Text) > 30)
                        F1.A = 30;
                    if (int.Parse(textBox2.Text) < 9)
                        F1.B = 9;
                    if (int.Parse(textBox2.Text) > 30)
                        F1.B = 30;
                    if (int.Parse(textBox3.Text) < 9)
                        F1.C = 10;

                    if (int.Parse(textBox1.Text) * int.Parse(textBox2.Text) - int.Parse(textBox3.Text) < 0)//輸入之炸彈數大於總格子數
                    {
                        MessageBox.Show("炸彈數太多，請重新輸入");
                        textBox1.Text = null;
                        textBox2.Text = null;
                        textBox3.Text = null;
                    }
                    else
                    {
                        this.Hide();
                        F1.ShowDialog();
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("請輸入有效數字");               
            }
            catch (FormatException)
            {
                MessageBox.Show("請輸入有效數字");
            }
        }
    }
}
