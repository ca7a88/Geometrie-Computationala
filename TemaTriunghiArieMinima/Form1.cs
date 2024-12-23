using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemaTriunghiArieMinima
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Point> puncte = new List<Point>();
        public static float ArieTriunghi(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            float arie = Math.Abs(x1 * y2 + x2 * y3 + x3 * y1 - x3 * y2 - x1 * y3 - x2 * y1) / 2;
            return arie;
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen bluePen = new Pen(Color.Blue, 3), redPen = new Pen(Color.Red, 1);
            Random rnd = new Random();

            int n = 4;//rnd.Next(100);

            for (int i = 0; i < n; i++)
            {
                Point punct = new Point(rnd.Next(10, this.panel1.Width - 10), rnd.Next(10, this.panel1.Height - 10));
                puncte.Add(punct);
                g.DrawEllipse(bluePen, punct.X, punct.Y, 2, 2);
            }

            float arieMin = float.MaxValue;
            int indexAmin = 0, indexBmin = 0, indexCmin = 0;

            for (int i = 0; i < puncte.Count - 2; i++)
            {
                for (int j = i; j < puncte.Count - 1; j++)
                {
                    for (int k = j; k < puncte.Count; k++)
                    {
                        float arie = ArieTriunghi(puncte[i].X, puncte[i].Y, puncte[j].X, puncte[j].Y, puncte[k].X, puncte[k].Y);
                        if (arie > 0 && arie < arieMin)
                        {
                            arieMin = arie;
                            indexAmin = i;
                            indexBmin = j;
                            indexCmin = k;
                        }
                    }
                }
            }
            Point[] vertex = { puncte[indexAmin], puncte[indexBmin], puncte[indexCmin] };
            g.DrawPolygon(redPen, vertex);
        }
    }
}