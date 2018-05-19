using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_3
{
    class Class1
    {
        string bomb = "B";
        string non = "N";
        string hid = "H";
        string flag = "F";


        Random ram = new Random();

        public void addbomb(int len, int wid)
        {

            int[,] a = new int[len, wid];
            string[,] output = new string[len, wid];

            //a[1, 1] = 9;
            int i, j;

            for (i = 0; i < len; i++)
            {
                for (j = 0; j < wid; j++)
                {
                    a[i, j] = 0;
                    output[i, j] = null;
                }
            }

            for (i = 0; i < 10; i++)
            {
                a[ram.Next(0, len), ram.Next(0, wid)] = 9;
            }

            for (i = 0; i < len; i++)
            {
                for (j = 0; j < wid; j++)
                {
                    if (a[i, j] == 9)
                    {
                        for (int k = -1; k < 2; k++)
                        {
                            for (int m = -1; m < 2; m++)
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

            int count = 0;
            for (i = 0; i < len; i++)
            {
                for (j = 0; j < wid; j++)
                {
                    output[i, j] = Convert.ToString(a[i, j]);
                    if (output[i, j] == "9")
                        output[i, j] = bomb;

                    /*if (output[i, j] == "B")
                        count++;*/
                    Console.Write(output[i, j] + "\t");
                }

            }

        }
    }
}
