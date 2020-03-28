using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlottingFunctions
{
    public partial class Form1 : Form
    {
        float[,] QuadY = new float[202, 2];
        float mx;
        float my;
        string mousex;
        string mousey;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Create array of two points.
            Point[] points = { new Point(-10, -6), new Point(10, 6) };


            // Set world transformation of Graphics object to translate.

            e.Graphics.ScaleTransform(80, -70);

            e.Graphics.TranslateTransform(10, -6);


            float thick = float.Parse(numericUpDown1.Value.ToString());
            float over = float.Parse(numericUpDown2.Value.ToString());
            float updown = float.Parse(numericUpDown3.Value.ToString());
            Pen mypen = new Pen(Color.Black, thick);
            mypen.DashStyle = DashStyle.Dash;



            e.Graphics.DrawLine(mypen, -10, 0, 10, 0);
            e.Graphics.DrawLine(mypen, 0, 6, 0, -6);



            //var array = PlotPoints();
            var array = PlotSin();

            Pen pens = new Pen(Color.DarkBlue, thick);
            pens.DashStyle = DashStyle.Dot;
            PointF[] pointF = new PointF[210];

            for (int i = 0; i <= 200; i++)
            {

                pointF[i].X = array[i, 0];
                pointF[i].Y = array[i, 1];

            }

            var array2 = PlotPoints();

            Pen pens2 = new Pen(Color.Red, thick);
            Pen pen = new Pen(Color.DarkOrange, thick);
            pens.DashStyle = DashStyle.Solid;
            PointF[] pointF2s = new PointF[210];

            for (int i = 0; i <= 200; i++)
            {

                pointF2s[i].X = array2[i, 0];
                pointF2s[i].Y = array2[i, 1];

            }


            pens2.Color = Color.DeepPink;
            e.Graphics.DrawEllipse(pens2, new RectangleF(over, updown, 1, 1));




            for (int i = 0; i <= 199; i++)
            {
                e.Graphics.DrawLine(pens, pointF[i], pointF[i + 1]);
            }

            for (int f = 0; f <= 199; f++)
            {
                e.Graphics.DrawLine(pens2, pointF2s[f], pointF2s[f + 1]);
            }
        }

        private float[,] PlotPoints()
        {
            float i = -10;
            int count = 0;


            for (i = -10; i <= 10; i += 0.1f)
            {

                QuadY[count, 0] = i;
                QuadY[count, 1] = -(float)Math.Pow(i, 2);
                count += 1;

            }
            return QuadY;

        }

        private float[,] PlotSin()
        {
            double i = -10;
            int count = 0;
            int ans = 0;
            int index1 = 0;
            float ee = 0;
            double mydouble = new double();
            for (float e = -10; e <= 10; e += 0.1f)
            {
                ee += 1;
            }

            
            for (i = -10; i <= 10; i += 0.1)
            {

                index1 = (int)(i);

                ans = index1 % 10;

                QuadY[count, 0] = float.Parse(i.ToString());
           


                mydouble = Math.Sin(i / 2d);
                mydouble = float.Parse(mydouble.ToString());

                QuadY[count, 1] = (float)mydouble * 3;
                count += 1;

            }
            //QuadY[199, 0] = 10;
            //QuadY[199, 1] = 10;
            //QuadY[200, 0] = 10;
            //QuadY[200, 1] = 10;
            return QuadY;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            float myx = (1600 * 0.50f);
            float myy = (830 * 0.50f);
            mousex = (e.Location.X).ToString();
            mousey = (e.Location.Y).ToString();

            mx = float.Parse(mousex);
            my = float.Parse(mousey);


            mx = mx - myx;
            my = my - myy;

            mx = mx * 0.013f;
            my = my * 0.016f;

            if (my <= -1)
            {
                my = (my * -1);
            }
            else
            {
                my = -my;
            }





            label1.Text = mx.ToString();
            label2.Text = my.ToString();



            //Form1.ActiveForm.Refresh();
        }
    }
}
