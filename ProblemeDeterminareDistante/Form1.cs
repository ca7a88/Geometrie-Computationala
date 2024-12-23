using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProblemeDeterminareDistante
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            //Pen p = new Pen(Color.Green, 3), p2 = new Pen(Color.Blue, 3);
            //Random rnd = new Random();
            //int n = rnd.Next(100);
            //float d = rnd.Next(1, Math.Min(panel1.Width, panel1.Height) - 10);
            //float raza = 1;
            //float qx = rnd.Next(50, panel1.Width - 50);
            //float qy = rnd.Next(50, panel1.Height - 50);
            //g.DrawEllipse(p, qx - raza, qy - raza, raza * 2, raza * 2);
            //p = new Pen(Color.Black, 3);
            //for (int i = 0; i < n; i++)
            //{
            //    float x = rnd.Next(10, panel1.Width);
            //    float y = rnd.Next(10, panel1.Height);
            //    float dist = (float)Math.Sqrt(Math.Pow(qx - x, 2) + Math.Pow(qy - y, 2));
            //    if (dist < d)
            //        g.DrawEllipse(p2, x - raza, y - raza, raza * 2, raza * 2);
            //    else
            //        g.DrawEllipse(p, x - raza, y - raza, raza * 2, raza * 2);
            //}




            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Green, 3), p2 = new Pen(Color.Blue, 3);
            Random rnd = new Random();
            int n1 = rnd.Next(100), n2 = rnd.Next(100);
            float raza1 = 1, raza2 = 2;
            PointF[] m1 = new PointF[n1];
            PointF[] m2 = new PointF[n2];
            for (int i = 0; i < n1; i++)
            {
                m1[i].X = rnd.Next(10, panel1.Width - 10);
                m1[i].Y = rnd.Next(10, panel1.Height - 10);
                g.DrawEllipse(p, m1[i].X - raza1, m1[i].Y - raza1, raza1 * 2, raza1 * 2);
            }
            for (int i = 0; i < n2; i++)
            {
                m2[i].X = rnd.Next(10, panel1.Width - 10);
                m2[i].Y = rnd.Next(10, panel1.Height - 10);
                g.DrawEllipse(p2, m2[i].X - raza2, m2[i].Y - raza2, raza2 * 2, raza2 * 2);
            }
            float dist, x = 0, y = 0;
            for (int i = 0; i < n1; i++)
            {
                float dist_min = float.MaxValue;

                for (int j = 0; j < n2; j++)
                {
                    dist = (float)Math.Sqrt(Math.Pow(m1[i].X - m2[j].X, 2) + Math.Pow(m1[i].Y - m2[j].Y, 2));
                    if (dist_min > dist)
                    {
                        dist_min = dist;
                        x = m2[j].X;
                        y = m2[j].Y;
                    }
                }
                Pen p3 = new Pen(Color.Black, 1);
                g.DrawLine(p3, m1[i].X, m1[i].Y, x, y);
            }




            /*float [] x_coordinate = new float[n];
            float [] y_coordinate = new float[n];
            for (int i = 0; i < n; i++)
            {
                float x = rnd.Next(panel1.Height - 100, panel1.Width - 200);
                float y = rnd.Next(100, panel1.Height - 100);
                g.DrawEllipse(p, x - raza, y - raza, raza * 2, raza * 2);
                x_coordinate[i] = x;
                y_coordinate[i] = y;
            }*/
            // sortam punctele. grupam in perechi de 3 pct in ordinea sortata.
            // determinam aria triunghiului cu formula determinantului
            // tehnica 3-sum

            // TEMA 3 Se da o multime de pct in plan. Determinati cercul de arie minima
            // care sa contina toate punctele in interior
            // DIAMETRUL!!!!!!!!!!!!!!!!!!!!!
            // de cautat online: minimal enclosing circle

            // TEMA OPTIONAL: sweep line (cu animatii, morti, raniti...)

            // structuri de date pt cautare binara: ThreeNode, SortedList
        }
    }
}
