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

namespace TemaTriangulareaPrinOtectomie
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen bluePen;
        Pen redPen;
        List<PointF> Points = new List<PointF>();
        List<Tuple<int, int, int>> triangles = new List<Tuple<int, int, int>>(); //lista de triunghiuri

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

        private bool IsDiagonal(List<PointF> puncte, int i, int j)
        {
            bool intersectie = false;
            //nu intersecteaza laturi neinciente
            for (int k = 0; k < puncte.Count - 1; k++)
            {
                if (i != k && i != (k + 1) && j != k && j != (k + 1) && se_intersecteaza(puncte[i], puncte[j], puncte[k], puncte[k + 1]))
                {
                    intersectie = true;
                    break;
                }
            }
            //vf pt ultima latura
            if (i != puncte.Count - 1 && i != 0 && j != puncte.Count - 1 && j != 0 && se_intersecteaza(puncte[i], puncte[j], puncte[puncte.Count - 1], puncte[0]))
            {
                intersectie = true;
            }
            //se afla in interiorul P
            if (!intersectie && se_afla_in_interiorul_poligonului(puncte, i, j))
            {
                return true;
            }
            return false;
        }

        // Pune intr-un label triunghiurile triangulate
        private void IdentificareTriunghi(int labelY, List<PointF> puncteTriangulare, int i)
        {
            Label labelTriangle = new Label();
            //labelTriangle.Parent = panel1;
            labelTriangle.Location = new Point(label1.Location.X, labelY);
            labelTriangle.Text = "";
            labelTriangle.AutoSize = true;
            this.Controls.Add(labelTriangle);
            int triangleV1 = 0, triangleV2 = 0, triangleV3 = 0;
            for (int j = 0; j < Points.Count; j++)
            {
                if (Points[j].X == puncteTriangulare[i].X && Points[j].Y == puncteTriangulare[i].Y)
                {
                    labelTriangle.Text = labelTriangle.Text + (j).ToString() + ", "; //primul vf al triunghiului
                    triangleV1 = j;
                    break;
                }
            }
            for (int j = 0; j < Points.Count; j++)
            {
                if (Points[j].X == puncteTriangulare[i + 1].X && Points[j].Y == puncteTriangulare[i + 1].Y)
                {
                    labelTriangle.Text = labelTriangle.Text + (j).ToString() + ", "; //al doilea vf al triunghiului
                    triangleV2 = j;
                    break;
                }
            }
            for (int j = 0; j < Points.Count; j++)
            {
                if (Points[j].X == puncteTriangulare[i + 2].X && Points[j].Y == puncteTriangulare[i + 2].Y)
                {
                    labelTriangle.Text = labelTriangle.Text + (j).ToString(); //si al treilea vf
                    triangleV3 = j;
                    break;
                }
            }
            triangles.Add(new Tuple<int, int, int>(triangleV1, triangleV2, triangleV3));
        }

        private float ValoareDeterminant(PointF a, PointF b, PointF c)
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
            if (ValoareDeterminant(puncte[p1], puncte[p2], puncte[p3]) > 0)
            {
                return true;
            }
            return false;
        }

        private bool intoarcere_spre_stanga(List<PointF> puncte, int p1, int p2, int p3)
        {
            if (ValoareDeterminant(puncte[p1], puncte[p2], puncte[p3]) < 0)
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
            if (ValoareDeterminant(p2, p1, s1) * ValoareDeterminant(p2, p1, s2) <= 0 && ValoareDeterminant(s2, s1, p1) * ValoareDeterminant(s2, s1, p2) <= 0)
            {
                return true;
            }
            return false;
        }

        private void btnTrianguleaza_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Pen penTR = new Pen(Color.Black, 2);
            List<PointF> puncteTriangulare = new List<PointF>(Points); //clona listei points
            int n = puncteTriangulare.Count;
            int newLabelY = label1.Location.Y + 20;
            while (n > 3)
            {
                for (int i = 0; i < n - 2; i++)
                {
                    if (IsDiagonal(puncteTriangulare, i, i + 2))
                    {
                        Thread.Sleep(100);
                        IdentificareTriunghi(newLabelY, puncteTriangulare, i); //scrie in label triunghiul
                        newLabelY += 20;
                        g.DrawLine(penTR, puncteTriangulare[i], puncteTriangulare[i + 2]); //deseneaza diagonala
                        puncteTriangulare.RemoveAt(i + 1); //sterge varful urechii
                        n--;
                        break;
                    }
                }
            }
            IdentificareTriunghi(newLabelY, puncteTriangulare, 0); //scrie ultimul triunghi

            buttonThreeColor.Enabled = true;
            btnArie.Enabled = true;
        }


        private int IsAlreadyMarked(int punct, List<Tuple<int, int>> varfuriMarcate) //verifica daca e marcat si returneaza culoarea
        {
            for (int i = 0; i < varfuriMarcate.Count; i++)
            {
                if (varfuriMarcate[i].Item1 == punct)
                {
                    return varfuriMarcate[i].Item2;
                }
            }
            return -1;
        }

        private int MissingColor(int a, int b) //returneaza a treia culoare
        {
            if ((a == 0 && b == 1) || (a == 1 && b == 0))
            {
                return 2;
            }
            if ((a == 0 && b == 2) || (a == 2 && b == 0))
            {
                return 1;
            }
            if ((a == 1 && b == 2) || (a == 2 && b == 1))
            {
                return 0;
            }
            return -1;
        }
        private void buttonThreeColor_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Pen[] pens = new Pen[] { new Pen(Color.Blue, 3), new Pen(Color.Green, 3), new Pen(Color.Red, 3) };
            List<Tuple<int, int>> varfuriMarcate = new List<Tuple<int, int>>();
            for (int i = triangles.Count - 1; i >= 0; i--)
            {
                int colored1 = IsAlreadyMarked(triangles[i].Item1, varfuriMarcate);
                int colored2 = IsAlreadyMarked(triangles[i].Item2, varfuriMarcate);
                int colored3 = IsAlreadyMarked(triangles[i].Item3, varfuriMarcate);
                if (colored1 == -1 && colored2 == -1 && colored3 == -1) //primul caz
                {
                    varfuriMarcate.Add(new Tuple<int, int>(triangles[i].Item1, 0));
                    g.DrawEllipse(pens[0], Points[triangles[i].Item1].X - 8, Points[triangles[i].Item1].Y - 8, 16, 16);
                    varfuriMarcate.Add(new Tuple<int, int>(triangles[i].Item2, 1));
                    g.DrawEllipse(pens[1], Points[triangles[i].Item2].X - 8, Points[triangles[i].Item2].Y - 8, 16, 16);
                    varfuriMarcate.Add(new Tuple<int, int>(triangles[i].Item3, 2));
                    g.DrawEllipse(pens[2], Points[triangles[i].Item3].X - 8, Points[triangles[i].Item3].Y - 8, 16, 16);
                }
                else if (colored1 == -1)
                {
                    varfuriMarcate.Add(new Tuple<int, int>(triangles[i].Item1, MissingColor(colored2, colored3)));
                    g.DrawEllipse(pens[MissingColor(colored2, colored3)], Points[triangles[i].Item1].X - 8, Points[triangles[i].Item1].Y - 8, 16, 16);
                }
                else if (colored2 == -1)
                {
                    varfuriMarcate.Add(new Tuple<int, int>(triangles[i].Item2, MissingColor(colored1, colored3)));
                    g.DrawEllipse(pens[MissingColor(colored1, colored3)], Points[triangles[i].Item2].X - 8, Points[triangles[i].Item2].Y - 8, 16, 16);
                }
                else if (colored3 == -1)
                {
                    varfuriMarcate.Add(new Tuple<int, int>(triangles[i].Item3, MissingColor(colored1, colored2)));
                    g.DrawEllipse(pens[MissingColor(colored1, colored2)], Points[triangles[i].Item3].X - 8, Points[triangles[i].Item3].Y - 8, 16, 16);
                }
            }
        }
        private void btnArie_Click(object sender, EventArgs e) //calculeaza suma ariilor triunghiurilor
        {
            double arieTotala = 0;
            for (int i = 0; i < triangles.Count; i++)
            {
                arieTotala += ArieTriunghi(Points[triangles[i].Item1].X, Points[triangles[i].Item1].Y, Points[triangles[i].Item2].X, Points[triangles[i].Item2].Y, Points[triangles[i].Item3].X, Points[triangles[i].Item3].Y);
            }

            //for (int i = 0; i < Points.Count - 1; i++)
            //{
            //    Points[i]
            //}

            labelArie.Text = arieTotala.ToString();
        }

        private double ArieTriunghi(float x1, float y1, float x2, float y2, float x3, float y3) //formula cu determinant
        {
            return 0.5 * Math.Abs(x1 * y2 + x2 * y3 + x3 * y1 - x3 * y2 - x1 * y3 - x2 * y1);
        }
    }
}
