using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form1 : Form
    {
        private Algorithms draw = new Algorithms();
        public Form1()
        {
            InitializeComponent();
        }
        private void middleBtn_Click(object sender, EventArgs e)
        {
            List<int> input = parseInput();

            int start = 0;

            if (input == null)
            {
                return;
            }

            if (input.Count % 4 != 0 || input.Count < 8)
            {
                MessageBox.Show("Incorrect Format!");
                return;
            }

            List<Point> parsed = parseRectangle(input);
            draw.init(parsed);

            while (start < input.Count - 4)
            {
                draw.medianPoint(input[start],input[start + 1],input[start + 2],input[start + 3]);
                start += 4;
            }

            pictureBox.Image = draw.End();
            pictureBox.Invalidate();
        }

        private void clipBtn_Click(object sender, EventArgs e)
        {
            List<int> input = parseInput();

            int start = 0;
            if (input == null)
            {
                return;
            }

            int n = input[0];
            input.RemoveAt(0);

            if (input.Count % 2 != 0 || input.Count < 10)
            {
                MessageBox.Show("Incorrect Format!");
                return;
            }

            List<Point> parsed = parsePolygon(input, n);
            draw.init(parsed);

            while (start < input.Count - n * 2)
            {
                draw.DrawLinePoly(input[start], input[start + 1], input[start + 2], input[start + 3]);
                start += 4;
            }

            pictureBox.Image = draw.End();
            pictureBox.Invalidate();
        }


        private List<int> parseInput()
        {
            List<int> input = new List<int>();
            string[] splt = inputTb.Text.
                Replace('\n', ' ').
                Replace('\t', ' ').
                Replace('\r', ' ').
                Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (string str in splt)
            {
                int val;
                if (!Int32.TryParse(str, out val))
                {
                    MessageBox.Show("Cannot parse string " + str);
                    return null;
                }

                input.Add(val);
            }

            return input;
        }

        private List<Point> parseRectangle(List<int> input)
        {
            List<Point> points = new List<Point>();

            points.Add(new Point(input[input.Count - 4], input[input.Count - 3]));
            points.Add(new Point(input[input.Count - 2], input[input.Count - 3]));
            points.Add(new Point(input[input.Count - 2], input[input.Count - 1]));
            points.Add(new Point(input[input.Count - 4], input[input.Count - 1]));

            return points;
        }

        private List<Point> parsePolygon(List<int> input, int n)
        {
            List<Point> points = new List<Point>();
            for (int i = n; i >= 1; i--)
            {
                points.Add(new Point(input[input.Count - 2 * i], input[input.Count - 2 * i + 1]));
            }

            return points;
        }
    }
}
