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
    public partial class Form1 : Form
    {
        Class2 add = new Class2();//呼叫類別
        Button[,] btn = new Button[10,10];//動態建立按鈕
        int a, b;
        public Timer tim = new System.Windows.Forms.Timer();
        
        public Form1()
        {
            InitializeComponent();
        }
               
        private void Form1_Load(object sender, EventArgs e)
        {            
            add.addbomb(10, 10, 10);//存入炸彈
          
            //調整按鈕外觀位置
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    btn[i, j] = new Button();
                    btn[i, j].Height = 40;
                    btn[i, j].Width = 40;
                    btn[i, j].Name = add.output[i, j];//將炸彈存入name裡面
                    this.Controls.Add(btn[i,j]);
                    btn[i, j].Location = new Point(50+38*i, 50+38*j);
                                        
                    btn[i, j].Click += new EventHandler(Buttons_Click);
                }
            }            
        }

        void flood_fill(int x, int y)//若按到按鈕為0，翻開九宮格
        {
            if (btn[x, y].Name == "0" && x > 0 && x < 9 && y > 0 && y < 9)
            {
                btn[x, y].Enabled = false;
                btn[x, y].Text = null;
                flood_fill(x - 1, y - 1);
                flood_fill(x - 1, y);
                flood_fill(x - 1, y + 1);
                flood_fill(x, y + 1);
                flood_fill(x, y - 1);
                flood_fill(x + 1, y);
                flood_fill(x + 1, y - 1);
                flood_fill(x + 1, y + 1);
            }
            else
                btn[x, y].Text = btn[x, y].Name;
        }


        void Buttons_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;                        
            int i = 0, j = 0, flag = 0;
            button.Text = button.Name;
            button.Enabled = false;
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                {
                    if (btn[i, j].Text == button.Text)
                    {
                        flag++;
                        break;
                        
                    }
                }
                if (flag == 1)
                    break;
            }                                            
            
            flood_fill(i,j);

        }        
    }
}
