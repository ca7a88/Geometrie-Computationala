using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemaConvexHull
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static float Determinant(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            float det = x1 * (y2 - y3)  +  x2 * (y3 - y1)  +  x3 * (y1 - y2);
            return det;
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
            Pen redPen = new Pen(Color.Red, 1), bluePen = new Pen(Color.Blue, 3);
            Pen randomPen = new Pen(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
            #endregion
            #region Points Generator
            for (int i = 0; i < n; i++)
            {
                Point p = new Point(rnd.Next(10, this.panel1.Width - 10), rnd.Next(10, this.panel1.Height - 10));
                points.Add(p);
                g.DrawEllipse(bluePen, p.X, p.Y, 2, 2);
            }
            #endregion

            bool ok;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    ok = true;
                    for (int k = 0; k < n; k++)
                    {
                        if (Determinant(points[i].X, points[i].Y, points[j].X, points[j].Y, points[k].X, points[k].Y) > 0)
                            ok = false;
                    }

                    if (ok)
                    {
                        g.DrawLine(redPen /*randomPen*/, points[i].X, points[i].Y, points[j].X, points[j].Y);
                        Thread.Sleep(1);
                    }
                }
            }
        }
    }
}
