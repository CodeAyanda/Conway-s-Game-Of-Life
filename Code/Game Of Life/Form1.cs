using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Of_Life
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        int[,] grid = new int[numOfCells, numOfCells];
        int[,] next = new int[numOfCells, numOfCells];
        static int numOfCells = 200;
        int size = 4;

        Pen white = new Pen(Color.White);
        SolidBrush whiteFill = new SolidBrush(Color.White);
        public Form1()
        {
            int count = 0;
            InitializeComponent();
            for (int i = 0; i < numOfCells; i++)
            {
                for (int j = 0; j < numOfCells; j++)
                {
                    grid[i, j] = rnd.Next(0, 2);
                    if (grid[i, j] ==1)
                    {
                        count++;
                    }
                }

            }
            label2.Text = "Starting Population : " + count.ToString();

        }

        private void Draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            InitializeNext();
            DrawGrid(g, next);

            label1.Text = "Current Population : " + CountPop(grid).ToString();
            label3.Text = "Frame Count : " + frameCount.ToString();
        }

        public void DrawGrid(Graphics g, int[,] array)
        {
            for (int i = 0; i < numOfCells; i++)
            {
                for (int j = 0; j < numOfCells; j++)
                {
                    if (array[i, j] == 1)
                    {
                        g.FillRectangle(whiteFill, i * size, j * size, size - 1, size - 1);
                    }

                }
            }


        }

        public int CountPop(int[,] array)
        {
            int count = 0;
            for (int i = 0; i < numOfCells; i++)
            {
                for (int j = 0; j < numOfCells; j++)
                {
                    if(array[i, j] == 1)
                    {
                        count++;
                    }

                }

            }
            return count;


        }

        public void InitializeNext()
        {
            //Compute next gen
            for (int i = 0; i < numOfCells; i++)
            {
                for (int j = 0; j < numOfCells; j++)
                {
                    if (grid[i, j] == 0 && Neighbours(i, j) == 3)
                    {
                        next[i, j] = 1;
                    }
                    else if (grid[i, j] == 1 && (Neighbours(i, j) == 2 || Neighbours(i, j) == 3))
                    {
                        next[i, j] = 1;
                    }
                    else
                    {
                        next[i, j] = 0;
                    }

                }

            }
            //grid == next
            for (int i = 0; i < numOfCells; i++)
            {
                for (int j = 0; j < numOfCells; j++)
                {
                    grid[i, j] = next[i, j];
                }
            }


        }

        public int Neighbours(int a, int b)
        {
            int sum = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if(a == 0 || b == 0  || b == numOfCells-1 || a == numOfCells-1 || (i == 0 && j == 0))
                    {
                    }
                    else
                    {
                        sum = sum + grid[a + i, b + j];

                    }
                }

            }

            return sum;


        }

        int frameCount = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
            frameCount++;
        }
    }
}
