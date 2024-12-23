using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace desenare_poligon
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen bluePen;
        Pen redPen;
        List<PointF> Points = new List<PointF>();

        public Form1()
        { 
            bluePen = new Pen(Color.Blue, 2);
            redPen = new Pen(Color.Red, 2);
            InitializeComponent();
            g = CreateGraphics();
        }

        int contor = 1;

        private void Form1_Click(object sender, EventArgs e)
        {
            PointF aux = PointToClient(new Point(MousePosition.X, MousePosition.Y));
            g.DrawString(contor.ToString(), new Font(FontFamily.GenericSansSerif, 10), new SolidBrush(Color.Black), aux.X - 20, aux.Y - 20);
            contor++;
            g.DrawEllipse(bluePen, aux.X - 2, aux.Y - 2, 4, 4);
            Points.Add(aux);

            if (Points.Count > 1)
            {
                g.DrawLine(redPen, Points[Points.Count - 2], Points[Points.Count - 1]);
            }
        }

        private void btnInchide_Click(object sender, EventArgs e)
        {
            g.DrawLine(redPen, Points[Points.Count - 1], Points[0]);
        }

        //determina valoarea determinantului de ordin 3 cu coordonatele punctelor date si 1 pe ultima coloana
        private float Determinant(PointF a, PointF b, PointF c)
        {
            return a.X * b.Y  +  b.X * c.Y  +  c.X * a.Y  -  c.X * b.Y  -  b.X * a.Y  -  a.X * c.Y;
        }

        private bool IntoarcereSpreStanga(int p1, int p2, int p3)
        {
            if (Determinant(Points[p1], Points[p2], Points[p3]) < 0)
                return true;
            return false;
        }
        private bool IntoarcereSpreDreapta(int p1, int p2, int p3)
        {
            if (Determinant(Points[p1], Points[p2], Points[p3]) > 0)
                return true;
            return false;
        }

        private bool EsteVarfConvex(int p)
        {
            int p_ant = (p > 0) ? p - 1 : Points.Count - 1;
            int p_urm = (p < Points.Count - 1) ? p + 1 : 0;
            return IntoarcereSpreDreapta(p_ant, p, p_urm);
        }
        private bool EsteVarfReflex(int p)
        {
            int p_ant = (p > 0) ? p - 1 : Points.Count - 1;
            int p_urm = (p < Points.Count - 1) ? p + 1 : 0;
            return IntoarcereSpreStanga(p_ant, p, p_urm);
        }

        //verifica daca doua segmente se intersecteaza
        private bool SeIntersecteaza(PointF s1, PointF s2, PointF p1, PointF p2)
        {
            if (Determinant(p2, p1, s1) * Determinant(p2, p1, s2) <= 0
                && Determinant(s2, s1, p1) * Determinant(s2, s1, p2) <= 0)
                return true;
            return false;
        }

        //verifica daca segmentul pi pj se afla in interiorul poligonului
        private bool InInteriorPoligon(int pi, int pj)
        {
            int pi_ant = (pi > 0) ? pi - 1 : Points.Count - 1;
            int pi_urm = (pi < Points.Count - 1) ? pi + 1 : 0;
            if ((EsteVarfConvex(pi) && IntoarcereSpreStanga(pi, pj, pi_urm) && IntoarcereSpreStanga(pi, pi_ant, pj)) ||
                (EsteVarfReflex(pi) && !(IntoarcereSpreDreapta(pi, pj, pi_urm) && IntoarcereSpreDreapta(pi, pi_ant, pj))))
                return true;
            return false;
        }

        //triangularea poligonului folosind diagonalele
        private void btnTrianguleaza_Click(object sender, EventArgs e)
        {
            int nrDiagonale = 0;
            Tuple<int, int>[] diagonale = new Tuple<int, int>[Points.Count - 3];
            for (int i = 0; i < Points.Count - 2; i++)
                for (int j = i + 2; j < Points.Count; j++)
                {
                    if (i == 0 && j == Points.Count - 1)
                        break; // exclud ultima latura
                    bool intersectie = false;
                    //daca p_i p_j nu intersecteaza nicio latura neincidenta a poligonului
                    for (int k = 0; k < Points.Count - 1; k++)
                        if (i != k && i != (k + 1) && j != k && j != (k + 1)
                            && SeIntersecteaza(Points[i], Points[j], Points[k], Points[k + 1]))
                        {
                            intersectie = true;
                            break;
                        }
                    //verif si pt ultima latura a poligonului
                    if (i != Points.Count - 1 && i != 0 && j != Points.Count - 1 && j != 0
                            && SeIntersecteaza(Points[i], Points[j], Points[Points.Count - 1], Points[0]))
                    {
                        intersectie = true;
                    }
                    if (!intersectie)
                    {
                        //si daca p_i p_j nu intersecteaza niciuna din diagonalele alese anterior
                        for (int k = 0; k < nrDiagonale; k++)
                            if (i != diagonale[k].Item1 && i != diagonale[k].Item2 && j != diagonale[k].Item1 && j != diagonale[k].Item2 && SeIntersecteaza(Points[i], Points[j], Points[diagonale[k].Item1], Points[diagonale[k].Item2]))
                            {
                                intersectie = true;
                                break;
                            }
                        if (!intersectie)
                        {
                            //si daca p_i p_j se afla in interiorul poligonului
                            if (InInteriorPoligon(i, j))
                            {
                                //se retine diagonala p_i p_j
                                Thread.Sleep(100);
                                g.DrawLine(redPen, Points[i], Points[j]);
                                diagonale[nrDiagonale] = new Tuple<int, int>(i, j);
                                nrDiagonale++;
                            }
                        }
                    }
                    if (nrDiagonale == Points.Count - 3)
                        return;
                }
        }
    }
}
