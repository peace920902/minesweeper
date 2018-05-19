using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace test_3
{
    class Class2
    {
        char bomb = '\u25CF';
        Random ram = new Random();//呼叫ramdon方法
        public string[,] output;
        public int[,] a;        
        public void addbomb(int len, int wid, int bombnum)//建立一個用來放置地雷的陣列方法
        {
            this.a = new int[len, wid];//陣列宣告
            this.output = new string[len, wid];
            int i, j;
            for (i = 0; i < len; i++)//將陣列值歸零
            {
                for (j = 0; j < wid; j++)
                {
                    a[i, j] = 0;
                    output[i, j] = null;
                }
            }
            //a[1, 1] = 9;


            for (int con = 0; con < bombnum; con++)//隨機放置炸彈
                a[ram.Next(0, len), ram.Next(0, wid)] = 9;

            for (i = 0; i < len; i++)//檢查炸彈旁邊的九宮格
            {
                for (j = 0; j < wid; j++)
                {
                    if (a[i, j] == 9)//遇到炸彈，九宮格加一
                    {
                        for (int k = -1; k <= 1; k++)
                        {
                            for (int m = -1; m <= 1; m++)
                            {
                                if (i + k >= 0 && j + m >= 0 && i + k < len && j + m < wid)
                                {
                                    a[i + k, j + m]++;
                                    if (a[i + k, j + m] == 10)
                                        a[i + k, j + m] = 9;
                                }
                            }
                        }
                    }

                }

            }



            for (i = 0; i < len; i++)
            {
                for (j = 0; j < wid; j++)
                {
                    output[i, j] = Convert.ToString(a[i, j]);
                    if (output[i, j] == "9")
                        output[i, j] = bomb.ToString();                    
                }
                
            }
        }
    }
}
