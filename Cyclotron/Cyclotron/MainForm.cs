/* Cyclotron Shapes */
/* Author Jacob Psimos 4/19/2017 10:51 PM */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cyclotron
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Pen inner = Pens.LightGreen;    //for drawing graphics
        private double innerRad = 1.0;          //degree interval where lines are drawn
        private Random r = new Random();

        private double centerX = 0.0;
        private double centerY = 0.0;
        private double radius = 0.0;    //not used
        private double a = 0.0;         //x-radius
        private double b = 0.0;         //y-radius

        const double padding = -333.0;  //makes ellipse full screen

        private void recalculateCoords()
        {
            centerX = Convert.ToDouble(panelCyclotron.ClientSize.Width) / 2.0;
            centerY = Convert.ToDouble(panelCyclotron.ClientSize.Height) / 2.0;

            a = centerX - padding;
            b = centerY - padding;
        }

        private double deg2rad(double deg)
        {
            return deg * (Math.PI / 180.0);
        }

        private void randomizePens()
        {

            int red = r.Next(0xFF);
            int green = r.Next(0xFF);
            int blue = r.Next(0xFF);
            int alpha = 0xFF;
            //float width = (float)r.Next(1, 3);

            Color color1 = Color.FromArgb(alpha, red, green, blue);
            
            inner = new Pen(color1, 1.0f);
            innerRad = r.Next(1, 5);
        }

        private void panelCyclotron_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //g.Clear(Color.Black);
            drawTickMarks(g);
        }

        private void drawTickMarks(Graphics g)
        {
            List<PointF> linesInner = new List<PointF>();

            for (double i = 0.0; i <= 360.0; i += innerRad)
            {
                double theta = deg2rad(i);

                double edgeX = centerX + (Math.Cos(theta) * a);
                double edgeY = centerY - (Math.Sin(theta) * b);

                PointF a1 = new PointF((float)centerX, (float)centerY);
                PointF a2 = new PointF((float)edgeX, (float)edgeY);

                linesInner.Add(a1);
                linesInner.Add(a2);
                //g.DrawLine(inner, (float)centerX, (float)centerY, (float)edgeX, (float)edgeY);
            }

            PointF[] inners = linesInner.ToArray();
            g.DrawLines(inner, inners); //faster than drawing lines individually
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R)
            {
                randomizePens();
                panelCyclotron.Invalidate();
            }
            else if (e.KeyCode == Keys.F)
            {
                if (this.FormBorderStyle != FormBorderStyle.None)
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                    panelCyclotron.BorderStyle = BorderStyle.None;
                    Cursor.Hide();
                }
                else
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    panelCyclotron.BorderStyle = BorderStyle.Fixed3D;
                    this.WindowState = FormWindowState.Normal;
                    Cursor.Show();
                }
                //FormBorderStyle = (this.FormBorderStyle == FormBorderStyle.None) ? FormBorderStyle.Sizable : FormBorderStyle.None;
            }
            else if (e.KeyCode == Keys.Q)
            {
                Application.Exit();
            }
        }

        private void panelCyclotron_Resize(object sender, EventArgs e)
        {
            recalculateCoords();
            panelCyclotron.Invalidate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Hotkeys\nF = toggle full screen\nR = randomize and redraw\nQ = exit");
        }

    }
}
