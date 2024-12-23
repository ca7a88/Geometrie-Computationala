using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriangularePoligoaneMonotone
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

        List<Tuple<int, int>> diagonals = new List<Tuple<int, int>>();
        int contor = 0;
        List<List<int>> polygons = new List<List<int>>();

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

        private void btnPartitioneaza_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Pen penPart = new Pen(Color.DarkViolet, 2);
            float[] dashValues = { 3, 2, 3, 2 };
            penPart.DashPattern = dashValues;
            //fara sortare vf dupa ordonata
            for (int i = 0; i < Points.Count - 1; i++)
            {
                if (este_varf_reflex(Points, i))
                {
                    //cazul cand i == 0 (i - 1 <=> points.Count - 1)
                    if (i == 0)
                    {
                        if (este_sub(i, (Points.Count - 1)) && este_sub(i, (i + 1)))
                        {
                            int index = UnVarfDeasupraVarfului(i);
                            g.DrawLine(penPart, Points[i], Points[index]);
                            diagonals.Add(new Tuple<int, int>(i, index));
                        }
                        if (este_deasupra(i, (Points.Count - 1)) && este_deasupra(i, (i + 1)))
                        {
                            int index = UnVarfSubVarful(i);
                            g.DrawLine(penPart, Points[i], Points[index]);
                            diagonals.Add(new Tuple<int, int>(i, index));
                        }
                    }
                    // cazul cand i == n - 1 (i + 1 <=> 0)
                    else if (i == Points.Count - 1)
                    {
                        if (este_sub(i, (i - 1)) && este_sub(i, 0))
                        {
                            int index = UnVarfDeasupraVarfului(i);
                            g.DrawLine(penPart, Points[i], Points[index]);
                            diagonals.Add(new Tuple<int, int>(i, index));
                        }
                        if (este_deasupra(i, (i - 1)) && este_deasupra(i, 0))
                        {
                            int index = UnVarfSubVarful(i);
                            g.DrawLine(penPart, Points[i], Points[index]);
                            diagonals.Add(new Tuple<int, int>(i, index));
                        }
                    }
                    else
                    {
                        if (este_sub(i, (i - 1)) && este_sub(i, (i + 1)))//p(i-1) si p(i+1) se afla sub p(i)
                        {
                            //unim p(i) cu un vf aflat deasupra lui
                            int index = UnVarfDeasupraVarfului(i); //cel mai de jos  care e deasupra
                                                                   //p[i] vf de separare
                            g.DrawLine(penPart, Points[i], Points[index]);
                            diagonals.Add(new Tuple<int, int>(i, index));
                        }
                        if (este_deasupra(i, (i - 1)) && este_deasupra(i, (i + 1)))//p(i-1) si p(i+1) se afla deasupra p(i)
                        {
                            //unim cu un vf sub el
                            int index = UnVarfSubVarful(i); //cel mai de sus care e sub
                                                            //p[i] vf de unire
                            g.DrawLine(penPart, Points[i], Points[index]);
                            diagonals.Add(new Tuple<int, int>(i, index));
                        }
                    }
                }
            }
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

        private void btnSavePolygon_Click(object sender, EventArgs e)
        {
            int[] determinantPoligoane = new int[Points.Count]; //am marcat cu 0 poligoanele care sunt sterse
            for (int i = 0; i < Points.Count; i++)
            {
                determinantPoligoane[i] = 1;
            }
            for (int i = 0; i < diagonals.Count - 1; i++)//-1 daca se dubleaza
            {
                if (diagonals[i].Item1 < diagonals[i].Item2) //diag de forma [2, 9]
                {
                    List<int> poligon = new List<int>();
                    poligon.Add(diagonals[i].Item2);
                    for (int j = diagonals[i].Item2 + 1; j < Points.Count; j++)
                    {
                        if (determinantPoligoane[j] == 1)
                        {
                            determinantPoligoane[j] = 0;
                            poligon.Add(j);
                        }
                    }
                    for (int j = 0; j < diagonals[i].Item1; j++)
                    {
                        if (determinantPoligoane[j] == 1)
                        {
                            determinantPoligoane[j] = 0;
                            poligon.Add(j);
                        }
                    }
                    poligon.Add(diagonals[i].Item1);
                    polygons.Add(poligon);
                }
                else //diag de forma [4, 2]
                {
                    List<int> poligon = new List<int>();
                    poligon.Add(diagonals[i].Item1);
                    poligon.Add(diagonals[i].Item2);
                    for (int j = diagonals[i].Item2 + 1; j < diagonals[i].Item1; j++)
                    {
                        if (determinantPoligoane[j] == 1)
                        {
                            determinantPoligoane[j] = 0;
                            poligon.Add(j);
                        }
                    }
                    polygons.Add(poligon);
                }
            }
            List<int> poligonFinal = new List<int>();
            for (int j = 0; j < Points.Count; j++)
            {
                if (determinantPoligoane[j] == 1)
                {
                    determinantPoligoane[j] = 0;
                    poligonFinal.Add(j);
                }
            }
            polygons.Add(poligonFinal);
            //afisare coordonate poligoane
            for (int i = 0; i < polygons.Count; i++)
            {
                string result = "";
                for (int j = 0; j < polygons[i].Count; j++)
                {
                    result += polygons[i][j] + " ";
                }
                listBoxPoligoane.Items.Add(result);
            }
        }

        private bool intersecteazaAlteDiagonale(List<PointF> punctePoligonCurent, List<Tuple<int, int>> diagonale, int i, int j)
        {
            bool intersectie = false;
            for (int k = 0; k < diagonale.Count; k++)
            {
                if (i != diagonale[k].Item1 && i != diagonale[k].Item2 && j != diagonale[k].Item1 && j != diagonale[k].Item2 && se_intersecteaza(punctePoligonCurent[i], punctePoligonCurent[j], punctePoligonCurent[diagonale[k].Item1], punctePoligonCurent[diagonale[k].Item2]))
                {
                    intersectie = true;
                    break;
                }
            }
            return intersectie;
        }

        private void btnTrianguleaza_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Pen penTriang = new Pen(Color.Red, 2);
            
            for (int i = 0; i < polygons.Count; i++) //parcurg listele de poligoane
            {
                List<int> varfuriPoligonCurent = new List<int>();
                for (int j = 0; j < polygons[i].Count; j++) //parcurg elem. dintr-o lista, adica dintr-un poligon
                {
                    varfuriPoligonCurent.Add(polygons[i][j]);
                }
                List<PointF> punctePoligonCurent = new List<PointF>();
                for (int k = 0; k < varfuriPoligonCurent.Count; k++)
                {
                    punctePoligonCurent.Add(Points[varfuriPoligonCurent[k]]);
                }                
                List<Tuple<int, int>> diagonale = new List<Tuple<int, int>>();
                if (punctePoligonCurent.Count < 3)
                {
                    return;
                }
                



                List<int> lantA = new List<int>();
                List<int> lantOrdonat = OrdonareLexicografica(punctePoligonCurent);
                List<int> lantOrdonatOriginale = new List<int>();
                for (int k = 0; k < lantOrdonat.Count; k++)
                {
                    lantOrdonatOriginale.Add(varfuriPoligonCurent[lantOrdonat[k]]);
                }
                List<int> lantB = new List<int>();
                for (int f = 0; f < lantOrdonat.Count; f++)
                {
                    lantB.Add(lantOrdonat[f]);
                }
                lantA.Add(lantB[0]);
                int p = lantB[0];
                p++;
                //lantB.RemoveAt(0);
                int ultimulPunct = lantB[lantB.Count - 1];
                while (p != ultimulPunct)
                {
                    if (p == lantOrdonat.Count)
                        p = 0;
                    lantA.Add(p);
                    lantB.Remove(p);
                    p++;
                }
                lantA.Add(ultimulPunct);
                /////////////////

                List<int> stivaVf = new List<int>();

                stivaVf.Add(lantOrdonat[0]);
                stivaVf.Add(lantOrdonat[1]);


                int ultimulVarfSters = 0;
                for (int l = 2; l < lantOrdonat.Count - 1; l++)//posibil lantOrdonat.Count-1
                {
                    if (lantA.Contains(lantOrdonat[l]) && lantB.Contains(lantOrdonat[stivaVf.Count - 1])
                        || lantB.Contains(lantOrdonat[l]) && lantA.Contains(lantOrdonat[stivaVf.Count - 1]))
                    {
                        for (int n = 0; n < stivaVf.Count; n++)
                        {
                            if (IsDiagonal(punctePoligonCurent, lantOrdonat[l], lantOrdonat[n]) && !intersecteazaAlteDiagonale(punctePoligonCurent, diagonale, lantOrdonat[l], lantOrdonat[n]))
                            {
                                g.DrawLine(penTriang, punctePoligonCurent[lantOrdonat[l]], punctePoligonCurent[lantOrdonat[n]]);
                                diagonale.Add(new Tuple<int, int>(lantOrdonat[l], lantOrdonat[n]));
                            }
                        }
                        stivaVf.Clear();
                        stivaVf.Add(lantOrdonat[l]);
                        stivaVf.Add(lantOrdonat[l - 1]);
                    }
                    else
                    {
                        ultimulVarfSters = stivaVf[stivaVf.Count - 1];
                        stivaVf.RemoveAt(stivaVf.Count - 1);
                        List<int> toRemove = new List<int>();
                        for (int n = 0; n < stivaVf.Count; n++)
                        {
                            if (IsDiagonal(punctePoligonCurent, lantOrdonat[l], lantOrdonat[n]) && !intersecteazaAlteDiagonale(punctePoligonCurent, diagonale, lantOrdonat[l], lantOrdonat[n]))
                            {
                                g.DrawLine(penTriang, punctePoligonCurent[lantOrdonat[l]], punctePoligonCurent[lantOrdonat[n]]);
                                diagonale.Add(new Tuple<int, int>(lantOrdonat[l], lantOrdonat[n]));
                                ultimulVarfSters = stivaVf[n];
                                toRemove.Add(lantOrdonat[n]);
                            }
                        }
                        for (int n = 0; n < toRemove.Count; n++)
                        {
                            stivaVf.Remove(toRemove[n]);
                        }
                        stivaVf.Add(ultimulVarfSters);
                        stivaVf.Add(lantOrdonat[l]);
                    }
                }
                while (stivaVf.Count > 1)
                {
                    if (IsDiagonal(punctePoligonCurent, lantOrdonat[lantOrdonat.Count - 1], lantOrdonat[stivaVf.Count - 1]) && !intersecteazaAlteDiagonale(punctePoligonCurent, diagonale, lantOrdonat[lantOrdonat.Count - 1], lantOrdonat[stivaVf.Count - 1]))
                    {
                        g.DrawLine(penTriang, punctePoligonCurent[lantOrdonat[lantOrdonat.Count - 1]], punctePoligonCurent[lantOrdonat[stivaVf.Count - 1]]);
                        diagonale.Add(new Tuple<int, int>(lantOrdonat[lantOrdonat.Count - 1], lantOrdonat[stivaVf.Count - 1]));
                    }
                    stivaVf.RemoveAt(stivaVf.Count - 1);
                }
            }
        }

        public List<int> OrdonareLexicografica(List<PointF> laturi)
        {
            List<int> ordonat = new List<int>(); ;
            for (int i = 0; i < laturi.Count; i++)
            {
                ordonat.Add(i);
            }
            for (int i = 0; i < laturi.Count - 1; i++)
                for (int j = i + 1; j < laturi.Count; j++)
                {
                    if (laturi[ordonat[i]].Y > laturi[ordonat[j]].Y)
                    {
                        int aux = ordonat[i];
                        ordonat[i] = ordonat[j];
                        ordonat[j] = aux;
                    }
                    else
                        if (laturi[ordonat[i]].Y == laturi[ordonat[j]].Y)
                        if (laturi[ordonat[i]].X > laturi[ordonat[j]].X)
                        {
                            int aux = ordonat[i];
                            ordonat[i] = ordonat[j];
                            ordonat[j] = aux;
                        }
                }

            return ordonat;
        }
    }
}

