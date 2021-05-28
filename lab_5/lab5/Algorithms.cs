using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Algorithms
    {
        private Bitmap b;
        private Graphics gr;
        private List<Point> clippingPoly;
        private Rectangle clippingRect;
        private Rectangle imRect;

        private static int cellSize = 10;
        private static Font font = new Font("Century Gothic", 12);
        private static Brush brush = new SolidBrush(Color.White);
        private static Brush textBrush = new SolidBrush(Color.FromArgb(50, 50, 50));

        private static Pen cellPen = new Pen(Color.Gray);
        private static Pen windowPen = new Pen(Color.CornflowerBlue, 3);
        private static Pen initClipPen = new Pen(Color.DeepPink, 5);
        private static Pen clipPen = new Pen(Color.LightGreen, 5);

        public void init(List<Point> clippingRect)
        {
            int minX = int.MaxValue, minY = int.MaxValue, maxX = int.MinValue, maxY = int.MinValue;

            foreach (Point p in clippingRect)
            {
                if (p.X <= minX)
                {
                    minX = p.X;
                }
                if (p.X >= maxX)
                {
                    maxX = p.X;
                }
                if (p.Y <= minY)
                {
                    minY = p.Y;
                }
                if (p.Y >= maxY)
                {
                    maxY = p.Y;
                }

            }

            clippingPoly = clippingRect;
            this.clippingRect = new Rectangle(minX,  minY, maxX - minX, maxY - minY);

            imRect = new Rectangle(minX - (maxX - minX) / 2, minY - (maxY - minY) / 2,
                (maxX - minX) * 2, (maxY - minY) * 2);

            b = new Bitmap(imRect.Width, imRect.Height);
            gr = Graphics.FromImage(b);


            gr.FillRectangle(brush, new Rectangle(
                0,
                0,
                imRect.Width,
                imRect.Height));

            int gridXStep = imRect.Width / cellSize;
            int gridYStep = imRect.Height / cellSize;

            for (int i = 0; i < imRect.Width; i += gridXStep)
            {
                gr.DrawLine(cellPen, i, 0, i, imRect.Height);
                if (i != 0)
                {
                    gr.DrawString(String.Format("{0}", i + imRect.X), font, textBrush, i, 0);

                }
            }

            for (int i = 0; i < imRect.Height; i += gridYStep)
            {
                gr.DrawLine(cellPen, 0, i, imRect.Width, i);
                if (i != 0)
                {
                    gr.DrawString(String.Format("{0}", i + imRect.Y), font, textBrush, 0, i);
                }
            }

            List<Point> points = new List<Point>();

            foreach (Point p in clippingRect)
            {
                points.Add(new Point(p.X - imRect.X, p.Y - imRect.Y));
            }

            gr.DrawPolygon(windowPen, points.ToArray());

        }

        private void ClipLine(float x0, float y0, float x1, float y1)
        {
            float[] t = new float[4];
            float[] S = new float[4];
            float[] Q = new float[4];
            t[0] = (float)(clippingRect.Y - y0) / (y1 - y0);
            t[1] = (float)(clippingRect.X - x0) / (x1 - y0);
            t[2] = (float)(clippingRect.Y + clippingRect.Height - y0) / (y1 - y0);
            t[3] = (float)(clippingRect.X + clippingRect.Width - x0) / (x1 - x0);
            S[0] = y0 - y1;
            S[1] = x0 - x1;
            S[2] = -S[0];
            S[3] = -S[1];
            Q[0] = y0 - clippingRect.Y;
            Q[1] = x0 - clippingRect.X;
            Q[2] = clippingRect.Y + clippingRect.Height - y0;
            Q[3] = clippingRect.X + clippingRect.Width - x0;

            bool clipped = true;

            float tEn = 0, tEx = 1;

            for (int i = 0; i < 4; i++)
            {
                if (Double.IsNaN(t[i]) || (t[i] >= 0 || t[i] <= 1))
                {
                    if (S[i] > 0)
                    {
                        tEx = Math.Min(Q[i] / S[i], tEx);
                    }
                    else if (S[i] < 0)
                    {
                        tEn = Math.Max(Q[i] / S[i], tEn);
                    }
                    else if (S[i] == 0)
                    {
                        if (Q[i] < 0)
                        {
                            clipped = false;
                            break;
                        }
                        if (Q[i] >= 0) // <=
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    clipped = false;
                }
            }

            if (tEn >= tEx)
            {
                clipped = false;

            }

            if (clipped)
                gr.DrawLine(clipPen, x0 + tEn * (x1 - x0) - imRect.X,
                    y0 + tEn * (y1 - y0) - imRect.Y,
                    x0 + tEx * (x1 - x0) - imRect.X,
                    y0 + tEx * (y1 - y0) - imRect.Y);

        }

        public void medianPoint(int x0, int y0, int x1, int y1)
        {
            gr.DrawLine(initClipPen,
                x0 - imRect.X,
                y0 - imRect.Y,
                x1 - imRect.X,
                y1 - imRect.Y);
            ClipLine(x0, y0, x1, y1);
        }

        public void DrawLinePoly(int x0, int y0, int x1, int y1)
        {
            gr.DrawLine(initClipPen,
                x0 - imRect.X,
                y0 - imRect.Y,
                x1 - imRect.X,
                y1 - imRect.Y);
            ClipLinePoly(x0, y0, x1, y1);
        }


        private void ClipLinePoly(float x0, float y0, float x1, float y1)
        {
            List<float> tEn = new List<float>();
            List<float> tEx = new List<float>();

            int n = clippingPoly.Count;
            bool lines_intersect;
            bool segments_intersect;
            Point intersection;
            float t1, t2;
            float x_0, x_1, y_0, y_1, a, b, S, n_x, n_y;

            for (int i = 0; i < n - 1; i++)
            {
                FindIntersection(new Point((int)x0, (int)y0),
                    new Point((int)x1, (int)y1),
                    clippingPoly.ElementAt(i),
                    clippingPoly.ElementAt(i + 1),
                    out lines_intersect,
                    out segments_intersect,
                    out intersection,
                    out t1,
                    out t2);

                x_0 = clippingPoly.ElementAt(i).X;
                y_0 = clippingPoly.ElementAt(i).Y;
                x_1 = clippingPoly.ElementAt(i + 1).X;
                y_1 = clippingPoly.ElementAt(i + 1).Y;

                n_x = (y_1 - y_0);
                n_y = -(x_1 - x_0);
                S = (x1 - x0) * n_x + (y1 - y0) * n_y;

                if (t1 >= 0 && t1 <= 1)
                {
                    if (belongs(intersection, x_0, y_0, x_1, y_1))
                    {

                        if (S > 0)
                        {
                            tEn.Add(t1);
                        }
                        else if (S < 0)
                        {
                            tEx.Add(t1);
                        }
                    }
                }
            }

            FindIntersection(new Point((int)x0, (int)y0),
                   new Point((int)x1, (int)y1),
                   clippingPoly.ElementAt(n - 1),
                   clippingPoly.ElementAt(0),
                   out lines_intersect,
                   out segments_intersect,
                   out intersection,
                   out t1,
                   out t2);
            x_0 = clippingPoly.ElementAt(n - 1).X;
            y_0 = clippingPoly.ElementAt(n - 1).Y;
            x_1 = clippingPoly.ElementAt(0).X;
            y_1 = clippingPoly.ElementAt(0).Y;

            n_x = (y_1 - y_0);
            n_y = -(x_1 - x_0);
            S = (x1 - x0) * n_x + (y1 - y0) * n_y;

            if (t1 >= 0 && t1 <= 1)
            {
                if (belongs(intersection, x_0, y_0, x_1, y_1))
                {

                    if (S > 0)
                    {
                        tEn.Add(t1);
                    }
                    else if (S < 0)
                    {
                        tEx.Add(t1);
                    }
                }
            }

            if (tEn.Count == 0 && tEx.Count == 0)
            {
                return;
            }

            if (tEn.Count == 0)
            {
                gr.DrawLine(clipPen,
                    x0 + (int)tEx.ElementAt(0) * (x1 - x0) - imRect.X,
                    y0 + (int)tEx.ElementAt(0) * (y1 - y0) - imRect.Y,
                    x1 - imRect.X, y1 - imRect.Y);
                return;
            }

            if (tEx.Count == 0)
            {
                gr.DrawLine(clipPen,
                    x0 + (int)tEn.ElementAt(0) * (x1 - x0) - imRect.X - imRect.X, intersection.Y - imRect.Y,
                    y0 + (int)tEn.ElementAt(0) * (y1 - y0) - imRect.Y - imRect.X, y0 - imRect.Y);
                return;
            }

            float t_max = tEn.Max(), t_min = tEx.Min();


            gr.DrawLine(clipPen, x0 + (int)(t_max * (x1 - x0)) - imRect.X,
                y0 + (int)(t_max * (y1 - y0)) - imRect.Y,
                x0 + (int)(t_min * (x1 - x0)) - imRect.X,
                y0 + (int)(t_min * (y1 - y0)) - imRect.Y);

        }

        private bool belongs(Point p, float x0, float y0, float x1, float y1)
        {
            if (p.Y > y0 && p.Y > y1 ||
                p.Y < y0 && p.Y < y1 ||
                p.X > x0 && p.X > x1 ||
                p.X < x0 && p.X < x1)
            {
                return false;
            }
            return true;
        }

        public Bitmap End()
        {
            gr.Dispose();
            return b;
        }

        private void FindIntersection(Point p1, Point p2, Point p3, Point p4,
            out bool lines_intersect, out bool segments_intersect, out Point intersection, out float t1, out float t2)
        {
            float dx12 = p2.X - p1.X;
            float dy12 = p2.Y - p1.Y;
            float dx34 = p4.X - p3.X;
            float dy34 = p4.Y - p3.Y;

            float denominator = (dy12 * dx34 - dx12 * dy34);

            t1 = ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34) / denominator;
            if (float.IsInfinity(t1))
            {
                lines_intersect = false;
                segments_intersect = false;
                intersection = new Point(int.MaxValue, int.MaxValue);
                t1 = int.MaxValue;
                t2 = int.MaxValue;
                return;
            }
            lines_intersect = true;

            t2 = ((p3.X - p1.X) * dy12 + (p1.Y - p3.Y) * dx12)/ -denominator;

            intersection = new Point(p1.X + (int)(dx12 * t1), p1.Y + (int)(dy12 * t1));

            segments_intersect =
                ((t1 >= 0) && (t1 <= 1) &&
                 (t2 >= 0) && (t2 <= 1));


            if (t1 < 0)
            {
                t1 = 0;
            }
            else if (t1 > 1)
            {
                t1 = 1;
            }

            if (t2 < 0)
            {
                t2 = 0;
            }
            else if (t2 > 1)
            {
                t2 = 1;
            }

        }
    }
}
