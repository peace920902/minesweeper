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
        Form2 F2 = new Form2();
        Button[,] btn;//動態建立按鈕
        int a, b, c , flag = 0 ,count = 0;
        public Timer tim = new System.Windows.Forms.Timer();//計時器        

        //從form2取值(A = 長，B = 寬，C = 炸彈數)
        public int A
        {
            set
            {
                a = value;
            }
        }

        public int B
        {
            set
            {
                b = value;
            }
        }
        public int C
        {
            set
            {
                c = value;
            }
        }
        

        public Form1()
        {
            InitializeComponent();
            tim.Interval = 1000;//一秒            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Form1 F1 = new Form1();
            
            tim.Tick += new EventHandler(tim_Tick);
            tim.Enabled = false;
            btn = new Button[a, b];//建立按鈕
            add.addbomb(a, b, c);//存入炸彈
                        
            //調整按鈕外觀位置
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    btn[i, j] = new Button();
                    btn[i, j].Height = 40;
                    btn[i, j].Width = 40;
                    btn[i, j].Name = add.output[i, j];//將炸彈存入name裡面                    
                    btn[i, j].Location = new Point(38 * i, 100 + 38 * j);
                    btn[i, j].Click += new EventHandler(Buttons_Click);
                    btn[i, j].MouseDown += new MouseEventHandler(Button_MouseDown);
                    btn[i, j].TabStop = false;
                    this.Controls.Add(btn[i, j]);
                }
            }
            label5.Size = new Size(a * 38, 2);//分隔線
        }

        private void tim_Tick(object sender, EventArgs e)
        {
            count++;
            label2.Text = count.ToString();            
        }

        void flood_fill(int x, int y)//若按到按鈕為0，翻開九宮格
        {

            //0的位置不在4邊也不在4角
            if (btn[x, y].Name == "0" && x > 0 && x < a - 1 && y > 0 && y < b - 1)
            {
                btn[x, y].Enabled = false;
                btn[x, y].Text = null;
                btn[x, y].Name = null;
                flood_fill(x - 1, y - 1);
                flood_fill(x - 1, y);
                flood_fill(x - 1, y + 1);
                flood_fill(x, y + 1);
                flood_fill(x, y - 1);
                flood_fill(x + 1, y);
                flood_fill(x + 1, y - 1);
                flood_fill(x + 1, y + 1);
            }

            //0的位置在4個角落時
            else if (btn[x, y].Name == "0" && x == 0 && y == 0)
            {
                btn[x, y].Enabled = false;
                btn[x, y].Text = null;
                btn[x, y].Name = null;
                flood_fill(x, y + 1);
                flood_fill(x + 1, y);
                flood_fill(x + 1, y + 1);
            }
            else if (btn[x, y].Name == "0" && x == 0 && y == b - 1)
            {
                btn[x, y].Enabled = false;
                btn[x, y].Text = null;
                btn[x, y].Name = null;
                flood_fill(x, y - 1);
                flood_fill(x + 1, y);
                flood_fill(x + 1, y - 1);
            }
            else if (btn[x, y].Name == "0" && x == a - 1 && y == 0)
            {
                btn[x, y].Enabled = false;
                btn[x, y].Text = null;
                btn[x, y].Name = null;
                flood_fill(x - 1, y);
                flood_fill(x, y + 1);
                flood_fill(x - 1, y + 1);
            }
            else if (btn[x, y].Name == "0" && x == a - 1 && y == b - 1)
            {
                btn[x, y].Enabled = false;
                btn[x, y].Text = null;
                btn[x, y].Name = null;
                flood_fill(x - 1, y);
                flood_fill(x - 1, y - 1);
                flood_fill(x, y - 1);
            }

            //0的位置在4邊時
            else if (btn[x, y].Name == "0" && x == 0 && y > 0 && y < b - 1)
            {
                btn[x, y].Enabled = false;
                btn[x, y].Text = null;
                btn[x, y].Name = null;
                flood_fill(x, y - 1);
                flood_fill(x, y + 1);
                flood_fill(x + 1, y - 1);
                flood_fill(x + 1, y);
                flood_fill(x + 1, y + 1);
            }
            else if (btn[x, y].Name == "0" && x == a - 1 && y > 0 && y < b - 1)
            {
                btn[x, y].Enabled = false;
                btn[x, y].Text = null;
                btn[x, y].Name = null;
                flood_fill(x, y - 1);
                flood_fill(x, y + 1);
                flood_fill(x - 1, y - 1);
                flood_fill(x - 1, y);
                flood_fill(x - 1, y + 1);
            }
            else if (btn[x, y].Name == "0" && x > 0 && x < a - 1 && y == 0)
            {
                btn[x, y].Enabled = false;
                btn[x, y].Text = null;
                btn[x, y].Name = null;
                flood_fill(x - 1, y);
                flood_fill(x + 1, y);
                flood_fill(x - 1, y + 1);
                flood_fill(x, y + 1);
                flood_fill(x + 1, y + 1);
            }
            else if (btn[x, y].Name == "0" && x > 0 && x < a - 1 && y == b - 1)
            {
                btn[x, y].Enabled = false;
                btn[x, y].Text = null;
                btn[x, y].Name = null;
                flood_fill(x - 1, y);
                flood_fill(x + 1, y);
                flood_fill(x - 1, y - 1);
                flood_fill(x, y - 1);
                flood_fill(x + 1, y - 1);
            }

            //若該格非零，翻開該格
            else
            {
                btn[x, y].Text = btn[x, y].Name;
                btn[x, y].Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {           
            Form2 F2 = new Form2();
            this.Hide();
            F2.ShowDialog(this);           
            this.Close();
        }      

        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)//玩法說明
        {
            try
            {
                VisitLink();
            }
            catch (Exception)
            {
                MessageBox.Show("404 Not found");
            }
        }
        private void VisitLink()
        {          
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://zh.wikipedia.org/wiki/%E8%B8%A9%E5%9C%B0%E9%9B%B7");
        }


        void clear()//清除版面，重新開始
        {
            add.addbomb(a, b, c);//重新載入炸彈
            //將所有值歸0
            for (int i = 0; i < a; i++)
                for (int j = 0; j < b; j++)
                {
                    btn[i, j].Text = null;
                    btn[i, j].Enabled = true;

                    btn[i, j].Name = add.output[i, j];
                }
            label1.Text = null;
            flag = 0;
            count = 0;
            label2.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)//點擊後重新開始
        {
            clear();
        }

        void Button_MouseDown(object sender, MouseEventArgs e)//按右鍵插旗子
        {
            Button button = (Button)sender;
            if (e.Button == MouseButtons.Right)
            {
                if (button.Text == '\u22BF'.ToString())//若有旗子，將旗子消除
                {
                    button.Text = null;                   
                    flag--;
                }
                else//沒有旗子則插旗
                {
                    button.Text = '\u22BF'.ToString();                    
                    flag++;
                }             
            }
            label1.Text = (c - flag).ToString();//顯示剩餘炸彈數-旗子數
        }

        void Buttons_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            tim.Enabled = true;
            int i = 0, j = 0, flag = 0, count = 0;
            button.Text = button.Name;
            button.Enabled = false;

            if (button.Name == '\u25CF'.ToString())//失敗條件判定>>踩到地雷
            {
                for (i = 0; i < a; i++)
                    for (j = 0; j < b; j++)
                    {
                        btn[i, j].Text = add.output[i, j];
                        if (btn[i, j].Text == "0")
                            btn[i, j].Text = null;
                        btn[i, j].Enabled = false;
                    }
                tim.Stop();//時間停止
                MessageBox.Show("你已經死了");
                
            }
            
            for (i = 0; i < a; i++)//取得按的是哪一個按鈕
            {
                for (j = 0; j < b; j++)
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

            flood_fill(i, j);//觸發事件

            for (i = 0; i < a; i++)//掃描版面，判定翻開的格子數
            {
                for (j = 0; j < b; j++)
                {
                    if (btn[i, j].Enabled == false)
                        count++;
                }
            }
            if (count == a * b - c)//勝利條件判定
            {
                tim.Stop();//時間停止
                
                MessageBox.Show("恭喜你獲勝");
            }            
        }
    }
}
