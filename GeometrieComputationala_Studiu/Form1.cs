using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeometrieComputationala_Studiu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Se dă o mulțime de n puncte în plan. 
        /// Să se scrie un program care să determine dreptunghiul de arie minimă
        /// care să conțină toate punctele date.
        /// </summary>
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen redpen = new Pen(Color.Red, 3), bluepen = new Pen(Color.Blue, 2);
            Random rnd = new Random();

            int n = rnd.Next(2, 20);
            float raza = 1;
            float[] x_coordinate = new float[n];
            float[] y_coordinate = new float[n];

            

            for (int i = 0; i < n; i++)
            {
                float x = rnd.Next(50, panel1.Width - 50);
                float y = rnd.Next(50, panel1.Height - 50);
                g.DrawEllipse(redpen, x - raza, y - raza, raza * 2, raza * 2);
                x_coordinate[i] = x;
                y_coordinate[i] = y;
            }
            float minx = x_coordinate.Min();
            float maxx = x_coordinate.Max();
            float miny = y_coordinate.Min();
            float maxy = y_coordinate.Max();

            g.DrawLine(bluepen, minx, miny, maxx, miny);
            g.DrawLine(bluepen, maxx, miny, maxx, maxy);
            g.DrawLine(bluepen, maxx, maxy, minx, maxy);
            g.DrawLine(bluepen, minx, maxy, minx, miny);
        }
    }
}
