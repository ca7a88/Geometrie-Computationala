using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemaDreptunghiArieMinima2
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
            Pen bluePen = new Pen(Color.Blue, 3), redPen = new Pen(Color.Red, 2);
            Random rnd = new Random();
            int n = 5;//rnd.Next(3, 20); 

            for (int i = 0; i < n; i++)
            {
                Point p = new Point(rnd.Next(100, this.panel1.Width - 100), rnd.Next(100, this.panel1.Height - 100));
                points.Add(p);
                g.DrawEllipse(bluePen, p.X, p.Y, 2, 2);
            }


        }
    }
}
