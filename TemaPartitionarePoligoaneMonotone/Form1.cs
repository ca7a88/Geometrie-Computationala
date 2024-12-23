using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemaPartitionarePoligoaneMonotone
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

        private int UnVarfDeasupraVarfului(int i)
        {
            int minIndex = -1;
            for (int index = 0; index < Points.Count; index++)
            {
                if (este_deasupra(i, index) && IsDiagonal(Points, i, index))
                {
                    if (minIndex == -1)
                    {
                        minIndex = index;
                    }
                    else
                    {
                        if (Points[index].Y > Points[minIndex].Y)
                        {
                            minIndex = index;
                        }
                    }
                }
            }
            return minIndex;
        }

        private int UnVarfSubVarful(int i)
        {
            int maxIndex = -1;
            for (int index = 0; index < Points.Count; index++)
            {
                if (este_sub(i, index) && IsDiagonal(Points, i, index))
                {
                    if (maxIndex == -1)
                    {
                        maxIndex = index;
                    }
                    else
                    {
                        if (Points[index].Y < Points[maxIndex].Y)
                        {
                            maxIndex = index;
                        }
                    }
                }
            }
            return maxIndex;
        }

        private bool este_sub(int i, int j)
        {
            if (Points[j].Y > Points[i].Y || (Points[j].Y == Points[i].Y && Points[j].X < Points[i].X))
            {
                return true;
            }
            return false;
        }

        private bool este_deasupra(int i, int j)
        {
            if (Points[j].Y < Points[i].Y || (Points[j].Y == Points[i].Y && Points[j].X < Points[i].X))
            {
                return true;
            }
            return false;
        }



        private bool IsDiagonal(List<PointF> puncte, int i, int j)
        {
            bool intersectie = false;
            
            for (int k = 0; k < puncte.Count - 1; k++)
            {
                if (i != k && i != (k + 1) && j != k && j != (k + 1) && se_intersecteaza(puncte[i], puncte[j], puncte[k], puncte[k + 1]))
                {
                    intersectie = true;
                    break;
                }
            }
            
            if (i != puncte.Count - 1 && i != 0 && j != puncte.Count - 1 && j != 0 && se_intersecteaza(puncte[i], puncte[j], puncte[puncte.Count - 1], puncte[0]))
            {
                intersectie = true;
            }
            
            if (!intersectie && se_afla_in_interiorul_poligonului(puncte, i, j))
            {
                return true;
            }
            return false;
        }

        private float Determinant(PointF a, PointF b, PointF c)
        {
            return a.X * b.Y + b.X * c.Y + c.X * a.Y - c.X * b.Y - b.X * a.Y - a.X * c.Y;
        }

        private bool se_afla_in_interiorul_poligonului(List<PointF> puncte, int pi, int pj)
        {
            int pi_ant = (pi > 0) ? pi - 1 : puncte.Count - 1;
            int pi_urm = (pi < puncte.Count - 1) ? pi + 1 : 0;
            if ((este_varf_convex(puncte, pi) && intoarcere_spre_stanga(puncte, pi, pj, pi_urm) && intoarcere_spre_stanga(puncte, pi, pi_ant, pj)) || (este_varf_reflex(puncte, pi) && !(intoarcere_spre_dreapta(puncte, pi, pj, pi_urm) && intoarcere_spre_dreapta(puncte, pi, pi_ant, pj))))
            {
                return true;
            }
            return false;
        }

        private bool intoarcere_spre_dreapta(List<PointF> puncte, int p1, int p2, int p3)
        {
            if (Determinant(puncte[p1], puncte[p2], puncte[p3]) > 0)
            {
                return true;
            }
            return false;
        }

        private bool intoarcere_spre_stanga(List<PointF> puncte, int p1, int p2, int p3)
        {
            if (Determinant(puncte[p1], puncte[p2], puncte[p3]) < 0)
            {
                return true;
            }
            return false;
        }

        private bool este_varf_reflex(List<PointF> puncte, int p)
        {
            int p_ant = (p > 0) ? p - 1 : puncte.Count - 1;
            int p_urm = (p < puncte.Count - 1) ? p + 1 : 0;
            return intoarcere_spre_stanga(puncte, p_ant, p, p_urm);
        }

        private bool este_varf_convex(List<PointF> puncte, int p)
        {
            int p_ant = (p > 0) ? p - 1 : puncte.Count - 1;
            int p_urm = (p < puncte.Count - 1) ? p + 1 : 0;
            return intoarcere_spre_dreapta(puncte, p_ant, p, p_urm);
        }

        private bool se_intersecteaza(PointF s1, PointF s2, PointF p1, PointF p2)
        {
            if (Determinant(p2, p1, s1) * Determinant(p2, p1, s2) <= 0 && Determinant(s2, s1, p1) * Determinant(s2, s1, p2) <= 0)
            {
                return true;
            }
            return false;
        }

        private void btnPartitioneaza_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Pen penPart = new Pen(Color.DarkViolet, 2);
            float[] dashValues = { 3, 2, 3, 2 };
            penPart.DashPattern = dashValues;
            for (int i = 0; i < Points.Count - 1; i++)
            {
                if (este_varf_reflex(Points, i))
                {
                    if (i == 0)
                    {
                        if (este_sub(i, (Points.Count - 1)) && este_sub(i, (i + 1)))
                        {
                            int index = UnVarfDeasupraVarfului(i);
                            g.DrawLine(penPart, Points[i], Points[index]);
                        }
                        if (este_deasupra(i, (Points.Count - 1)) && este_deasupra(i, (i + 1)))
                        {
                            int index = UnVarfSubVarful(i);
                            g.DrawLine(penPart, Points[i], Points[index]);
                        }
                    }
                    else if (i == Points.Count - 1)
                    {
                        if (este_sub(i, (i - 1)) && este_sub(i, 0))
                        {
                            int index = UnVarfDeasupraVarfului(i);
                            g.DrawLine(penPart, Points[i], Points[index]);
                        }
                        if (este_deasupra(i, (i - 1)) && este_deasupra(i, 0))
                        {
                            int index = UnVarfSubVarful(i);
                            g.DrawLine(penPart, Points[i], Points[index]);
                        }
                    }
                    else
                    {
                        if (este_sub(i, (i - 1)) && este_sub(i, (i + 1)))
                        {
                            int index = UnVarfDeasupraVarfului(i);
                                                                   
                            g.DrawLine(penPart, Points[i], Points[index]);
                        }
                        if (este_deasupra(i, (i - 1)) && este_deasupra(i, (i + 1)))
                        {
                            
                            int index = UnVarfSubVarful(i); 
                                                            
                            g.DrawLine(penPart, Points[i], Points[index]);
                        }
                    }
                }
            }
        }
    }
}
