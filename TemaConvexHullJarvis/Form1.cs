using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace TemaConvexHullJarvis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Point> points = new List<Point>();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            #region Random
            Random rnd = new Random();
            int n = rnd.Next(50);
            #endregion
            #region Pen
            Pen redPen = new Pen(Color.Red, 3), bluePen = new Pen(Color.Blue, 1);
            Pen randomPen = new Pen(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
            #endregion
            #region Points Generator
            for (int i = 0; i < n; i++)
            {
                Point p = new Point(rnd.Next(10, this.panel1.Width - 10), rnd.Next(10, this.panel1.Height - 10));
                points.Add(p);
                g.DrawEllipse(redPen, p.X, p.Y, 2, 2);
            }
            #endregion

            List<int> hull = new List<int>();

            int min = 0;
            for (int i = 0; i < n; i++)
            {
                if (points[i].Y < points[min].Y)
                {
                    min = i;
                }
            }
            hull.Add(min);

            bool ok;
            do
            {
                ok = true;
                int random = (hull[hull.Count - 1] + 1) % n;
                for (int i = 0; i < n; i++)
                {
                    if (DetTrigo(points[hull[hull.Count - 1]].X, points[hull[hull.Count - 1]].Y, 
                        points[i].X, points[i].Y, points[random].X, points[random].Y) > 0)
                    {
                        random = i;
                    }
                }
                hull.Add(random);
                if (random == min)
                {
                    ok = false;
                }
            } while (ok);

            for (int i = 0; i < hull.Count - 1; i++)
            {
                g.DrawLine(bluePen, points[hull[i]].X, points[hull[i]].Y, points[hull[i + 1]].X, points[hull[i + 1]].Y);
                Thread.Sleep(300);
            }
        }
        
        private double DetTrigo(double pX, double pY, double qX, double qY, double rX, double rY)
        {
            return pX * qY + qX * rY + rX * pY - rX * qY - pX * rY - qX * pY;
        }
    }
}
