using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemaCercArieMinima
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen albastru = new Pen(Color.Blue, 3), rosu = new Pen(Color.Red, 1);
            Random rnd = new Random();

            int n = 100; //rnd.Next(2, 5);
            float raza = 1;
            
            float[] x_coordinate = new float[n];
            float[] y_coordinate = new float[n];

            for (int i = 0; i < n; i++)
            {
                float X = rnd.Next(200, panel1.Width - 200);
                float Y = rnd.Next(100, panel1.Height - 100);
                g.DrawEllipse(albastru, X - raza, Y - raza, raza * 2, raza * 2);
                x_coordinate[i] = X;
                y_coordinate[i] = Y;
            }

            double distMax = 0, dist;
            double x_mid = 0, y_mid = 0;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    dist = Math.Sqrt(Math.Pow((x_coordinate[j] - x_coordinate[i]), 2)
                        + Math.Pow((y_coordinate[j] - y_coordinate[i]), 2));

                    if (dist > distMax)
                    {
                        distMax = dist;
                        x_mid = (x_coordinate[j] + x_coordinate[i]) / 2;
                        y_mid = (y_coordinate[j] + y_coordinate[i]) / 2;
                    }
                }
            }

            int x = (int)x_mid;
            int y = (int)y_mid;
            int Dist = (int)distMax / 2;

            //float x = (float)x_mid;
            //float y = (float)y_mid;
            //float Dist = (float)distMax / 2;

            // e.Graphics.DrawEllipse(rosu, x - Dist, y - Dist, Dist * 2, Dist * 2);
            e.Graphics.DrawEllipse(rosu, x - Dist, y - Dist, Dist * 2, Dist * 2);
        }
    }
}
