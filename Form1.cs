using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static System.Math;

namespace Quadratic_Solver
{
    public partial class Form1 : Form
    {
        public double numa { get; set; }
        public double numb { get; set; }
        public double numc { get; set; }
        public double numx { get; set; }
        public double numx1 { get; set; }
        public int roundnum { get; set; }
        public double vertx { get; set; }
        public double verty { get; set; }

        public Form1()
        {
            InitializeComponent();
            roundnum = 2;
        }

        private void a_TextChanged(object sender, EventArgs e)
        {
            try
            {
                numa = Convert.ToDouble(a.Text);
                update();
            }
            catch (FormatException)
            {
                output.Text = "a cannot be null";
            }
        }

        private void b_TextChanged(object sender, EventArgs e)
        {
            try
            {
                numb = Convert.ToDouble(b.Text);
                update();
            }
            catch (FormatException)
            {
                output.Text = "b cannot be null";
            }
        }

        private void c_TextChanged(object sender, EventArgs e)
        {
            try
            {
                numc = Convert.ToDouble(c.Text);
                update();
            }
            catch (FormatException)
            {
                output.Text = "c cannot be null";
            }
        }



        private void update()
        {
            numx = -(numb + Sqrt((numb * numb) - (4 * numa * numc))) / (2 * numa);
            numx1 = -(numb - Sqrt((numb * numb) - (4 * numa * numc))) / (2 * numa);

            if(numc == 0)
            {
                numx = 0;
                numx1 = -numb;
            }

            output.Text = "x = " + Round(numx, roundnum).ToString() + ", " + Round(numx1, roundnum).ToString();
            try { output.Text = output.Text + Environment.NewLine + "x = " + new Fraction(Round(numx, roundnum)).ToString(); } catch { output.Text = output.Text + Environment.NewLine + "x = NAN"; }
            try { output.Text = output.Text + ", " + new Fraction(Round(numx1, roundnum)).ToString(); } catch { output.Text = output.Text + ", NAN"; }

            vertx = -numb/(2*numa);
            verty = (numa*Pow(vertx,2)) + (numb*vertx) + numc;

            output.Text = output.Text + Environment.NewLine + "Vertex = (" + Round(vertx, roundnum).ToString() + ", " + Round(verty, roundnum).ToString() + ")";

            if(numa > 0)
            {
                output.Text = output.Text + Environment.NewLine + "Opens Up";
            }
            else if (numa < 0)
            {
                output.Text = output.Text + Environment.NewLine + "Opens Down";
            }

            if(verty < 0)
            {
                verty = -verty;
            }

            if (numx > numx1 && numa != 0)
            {
                int pointCount = ((int)numx + 25) - ((int)numx1 - 25);
                double[] x = ConsecutiveMin(pointCount, min: (int)numx1 - 25);
                double[] quad = Quadratic(x, numa, numb, numc);
                plot.plt.Clear();
                plot.plt.PlotScatter(x, quad, color: Color.Blue, label: "cos", lineWidth: 2.5, markerSize: 1);
                //graph.Image = MakeGraph(graph.ClientSize.Width, graph.ClientSize.Height, (float)numx1 - 3, (float)numx + 3, (float)(verty + ((verty / verty) * 3)), (float)(-verty + ((-verty / verty) * 3)));
            }
            else if (numx < numx1 && numa != 0)
            {
                int pointCount = ((int)numx1 + 25) - ((int)numx - 25);
                double[] x = ConsecutiveMin(pointCount, min: (int)numx - 25);
                double[] quad = Quadratic(x, numa, numb, numc);
                plot.plt.Clear();
                plot.plt.PlotScatter(x, quad, color: Color.Blue, label: "cos", lineWidth: 2.5, markerSize: 1);
                //graph.Image = MakeGraph(graph.ClientSize.Width, graph.ClientSize.Height, (float)numx - 3, (float)numx1 + 3, (float)(verty + ((verty / verty) * 3)), (float)(-verty + ((-verty / verty) * 3)));
            }
        }

        public static double[] ConsecutiveMin(int pointCount, double spacing = 1, int min = 0)
        {
            double[] ys = new double[pointCount];
            for (int i = 0; i < ys.Length; i++)
                ys[i] = (i + min) * spacing;
            return ys;
        }

        public static double[] Quadratic(double[] xs, double a, double b, double c)
        {
            double[] ys = new double[xs.Length];
            for (int i = 0; i < xs.Length; i += 1)
                ys[i] = (a * Pow(xs[i], 2)) + (b * xs[i]) + c;
            return ys;
        }

        private void round_TextChanged(object sender, EventArgs e)
        {
            try
            {
                roundnum = Convert.ToInt32(round.Text);
                update();
            }
            catch (FormatException)
            {
                output.Text = "round cannot be null";
            }
        }

        private float F(float x)
        {
            //return (float)((1 / x + 1 / (x + 1) - 2 * x * x) / 10);
            return (float)((numa * Pow(x, 2)) + (numb * x) + numc);
        }

        private Bitmap MakeGraph(int wid, int hgt, float xmin, float xmax, float ymin, float ymax)
        {
            // The bounds to draw.
            //float xmin = -3;
            //float xmax = 3;
            //float ymin = -3;
            //float ymax = 3;

            // Make the Bitmap.
            //int wid = picGraph.ClientSize.Width;
            //int hgt = picGraph.ClientSize.Height;
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // Transform to map the graph bounds to the Bitmap.
                RectangleF rect = new RectangleF(
                    xmin, ymin, xmax - xmin, ymax - ymin);
                PointF[] pts =
                {
                    new PointF(0, hgt),
                    new PointF(wid, hgt),
                    new PointF(0, 0),
                };
                gr.Transform = new Matrix(rect, pts);

                // Draw the graph.
                using (Pen graph_pen = new Pen(Color.Blue, 0))
                {
                    // Draw the axes.
                    gr.DrawLine(graph_pen, xmin, 0, xmax, 0);
                    gr.DrawLine(graph_pen, 0, ymin, 0, ymax);
                    for (int x = (int)xmin; x <= xmax; x++)
                    {
                        gr.DrawLine(graph_pen, x, -0.1f, x, 0.1f);
                        gr.DrawString(x.ToString(), new Font("Courier New", 0.4f), new SolidBrush(Color.Blue), x-(x.ToString().Length*0.25f), 0.25f, new StringFormat());
                    }
                    for (int y = (int)ymin; y <= ymax; y++)
                    {
                        gr.DrawLine(graph_pen, -0.25f, y, 0.25f, y);
                    }
                    graph_pen.Color = Color.Red;

                    // See how big 1 pixel is horizontally.
                    Matrix inverse = gr.Transform;
                    inverse.Invert();
                    PointF[] pixel_pts =
                    {
                new PointF(0, 0),
                new PointF(1, 0)
            };
                    inverse.TransformPoints(pixel_pts);
                    float dx = pixel_pts[1].X - pixel_pts[0].X;
                    dx /= 2;

                    // Loop over x values to generate points.
                    List<PointF> points = new List<PointF>();
                    for (float x = xmin; x <= xmax; x += dx)
                    {
                        bool valid_point = false;
                        try
                        {
                            // Get the next point.
                            float y = F(x);

                            // If the slope is reasonable,
                            // this is a valid point.
                            if (points.Count == 0) valid_point = true;
                            else
                            {
                                float dy = y - points[points.Count - 1].Y;
                                if (Math.Abs(dy / dx) < 1000)
                                    valid_point = true;
                            }
                            if (valid_point) points.Add(new PointF(x, y));
                        }
                        catch
                        {
                        }

                        // If the new point is invalid, draw
                        // the points in the latest batch.
                        if (!valid_point)
                        {
                            if (points.Count > 1)
                                gr.DrawLines(graph_pen, points.ToArray());
                            points.Clear();
                        }

                    }

                    // Draw the last batch of points.
                    if (points.Count > 1)
                        gr.DrawLines(graph_pen, points.ToArray());
                }
            }

            // Display the result.
            return bm;
        }

        private void plot_Load(object sender, EventArgs e)
        {

        }
    }

    public class Fraction
    {
        /// <summary>
        /// Class attributes/members
        /// </summary>
        long m_iNumerator;
        long m_iDenominator;

        /// <summary>
        /// Constructors
        /// </summary>
        public Fraction()
        {
            Initialize(0, 1);
        }

        public Fraction(long iWholeNumber)
        {
            Initialize(iWholeNumber, 1);
        }

        public Fraction(double dDecimalValue)
        {
            Fraction temp = ToFraction(dDecimalValue);
            Initialize(temp.Numerator, temp.Denominator);
        }

        public Fraction(string strValue)
        {
            Fraction temp = ToFraction(strValue);
            Initialize(temp.Numerator, temp.Denominator);
        }

        public Fraction(long iNumerator, long iDenominator)
        {
            Initialize(iNumerator, iDenominator);
        }

        /// <summary>
        /// Internal function for constructors
        /// </summary>
        private void Initialize(long iNumerator, long iDenominator)
        {
            Numerator = iNumerator;
            Denominator = iDenominator;
            ReduceFraction(this);
        }

        /// <summary>
        /// Properites
        /// </summary>
        public long Denominator
        {
            get
            { return m_iDenominator; }
            set
            {
                if (value != 0)
                    m_iDenominator = value;
                else
                    throw new FractionException("Denominator cannot be assigned a ZERO Value");
            }
        }

        public long Numerator
        {
            get
            { return m_iNumerator; }
            set
            { m_iNumerator = value; }
        }

        public long Value
        {
            set
            {
                m_iNumerator = value;
                m_iDenominator = 1;
            }
        }

        /// <summary>
        /// The function returns the current Fraction object as double
        /// </summary>
        public double ToDouble()
        {
            return ((double)this.Numerator / this.Denominator);
        }

        /// <summary>
        /// The function returns the current Fraction object as a string
        /// </summary>
        public override string ToString()
        {
            string str;
            if (this.Denominator == 1)
                str = this.Numerator.ToString();
            else
                str = this.Numerator + "/" + this.Denominator;
            return str;
        }
        /// <summary>
        /// The function takes an string as an argument and returns its corresponding reduced fraction
        /// the string can be an in the form of and integer, double or fraction.
        /// e.g it can be like "123" or "123.321" or "123/456"
        /// </summary>
        public static Fraction ToFraction(string strValue)
        {
            int i;
            for (i = 0; i < strValue.Length; i++)
                if (strValue[i] == '/')
                    break;

            if (i == strValue.Length)     // if string is not in the form of a fraction
                // then it is double or integer
                return (Convert.ToDouble(strValue));
            //return ( ToFraction( Convert.ToDouble(strValue) ) );

            // else string is in the form of Numerator/Denominator
            long iNumerator = Convert.ToInt64(strValue.Substring(0, i));
            long iDenominator = Convert.ToInt64(strValue.Substring(i + 1));
            return new Fraction(iNumerator, iDenominator);
        }


        /// <summary>
        /// The function takes a floating point number as an argument 
        /// and returns its corresponding reduced fraction
        /// </summary>
        public static Fraction ToFraction(double dValue)
        {
            try
            {
                checked
                {
                    Fraction frac;
                    if (dValue % 1 == 0)    // if whole number
                    {
                        frac = new Fraction((long)dValue);
                    }
                    else
                    {
                        double dTemp = dValue;
                        long iMultiple = 1;
                        string strTemp = dValue.ToString();
                        while (strTemp.IndexOf("E") > 0)    // if in the form like 12E-9
                        {
                            dTemp *= 10;
                            iMultiple *= 10;
                            strTemp = dTemp.ToString();
                        }
                        int i = 0;
                        while (strTemp[i] != '.')
                            i++;
                        int iDigitsAfterDecimal = strTemp.Length - i - 1;
                        while (iDigitsAfterDecimal > 0)
                        {
                            dTemp *= 10;
                            iMultiple *= 10;
                            iDigitsAfterDecimal--;
                        }
                        frac = new Fraction((int)Math.Round(dTemp), iMultiple);
                    }
                    return frac;
                }
            }
            catch (OverflowException)
            {
                throw new FractionException("Conversion not possible due to overflow");
            }
            catch (Exception)
            {
                throw new FractionException("Conversion not possible");
            }
        }

        /// <summary>
        /// The function replicates current Fraction object
        /// </summary>
        public Fraction Duplicate()
        {
            Fraction frac = new Fraction();
            frac.Numerator = Numerator;
            frac.Denominator = Denominator;
            return frac;
        }

        /// <summary>
        /// The function returns the inverse of a Fraction object
        /// </summary>
        public static Fraction Inverse(Fraction frac1)
        {
            if (frac1.Numerator == 0)
                throw new FractionException("Operation not possible (Denominator cannot be assigned a ZERO Value)");

            long iNumerator = frac1.Denominator;
            long iDenominator = frac1.Numerator;
            return (new Fraction(iNumerator, iDenominator));
        }


        /// <summary>
        /// Operators for the Fraction object
        /// includes -(unary), and binary opertors such as +,-,*,/
        /// also includes relational and logical operators such as ==,!=,<,>,<=,>=
        /// </summary>
        public static Fraction operator -(Fraction frac1)
        { return (Negate(frac1)); }

        public static Fraction operator +(Fraction frac1, Fraction frac2)
        { return (Add(frac1, frac2)); }

        public static Fraction operator +(int iNo, Fraction frac1)
        { return (Add(frac1, new Fraction(iNo))); }

        public static Fraction operator +(Fraction frac1, int iNo)
        { return (Add(frac1, new Fraction(iNo))); }

        public static Fraction operator +(double dbl, Fraction frac1)
        { return (Add(frac1, Fraction.ToFraction(dbl))); }

        public static Fraction operator +(Fraction frac1, double dbl)
        { return (Add(frac1, Fraction.ToFraction(dbl))); }

        public static Fraction operator -(Fraction frac1, Fraction frac2)
        { return (Add(frac1, -frac2)); }

        public static Fraction operator -(int iNo, Fraction frac1)
        { return (Add(-frac1, new Fraction(iNo))); }

        public static Fraction operator -(Fraction frac1, int iNo)
        { return (Add(frac1, -(new Fraction(iNo)))); }

        public static Fraction operator -(double dbl, Fraction frac1)
        { return (Add(-frac1, Fraction.ToFraction(dbl))); }

        public static Fraction operator -(Fraction frac1, double dbl)
        { return (Add(frac1, -Fraction.ToFraction(dbl))); }

        public static Fraction operator *(Fraction frac1, Fraction frac2)
        { return (Multiply(frac1, frac2)); }

        public static Fraction operator *(int iNo, Fraction frac1)
        { return (Multiply(frac1, new Fraction(iNo))); }

        public static Fraction operator *(Fraction frac1, int iNo)
        { return (Multiply(frac1, new Fraction(iNo))); }

        public static Fraction operator *(double dbl, Fraction frac1)
        { return (Multiply(frac1, Fraction.ToFraction(dbl))); }

        public static Fraction operator *(Fraction frac1, double dbl)
        { return (Multiply(frac1, Fraction.ToFraction(dbl))); }

        public static Fraction operator /(Fraction frac1, Fraction frac2)
        { return (Multiply(frac1, Inverse(frac2))); }

        public static Fraction operator /(int iNo, Fraction frac1)
        { return (Multiply(Inverse(frac1), new Fraction(iNo))); }

        public static Fraction operator /(Fraction frac1, int iNo)
        { return (Multiply(frac1, Inverse(new Fraction(iNo)))); }

        public static Fraction operator /(double dbl, Fraction frac1)
        { return (Multiply(Inverse(frac1), Fraction.ToFraction(dbl))); }

        public static Fraction operator /(Fraction frac1, double dbl)
        { return (Multiply(frac1, Fraction.Inverse(Fraction.ToFraction(dbl)))); }

        public static bool operator ==(Fraction frac1, Fraction frac2)
        { return frac1.Equals(frac2); }

        public static bool operator !=(Fraction frac1, Fraction frac2)
        { return (!frac1.Equals(frac2)); }

        public static bool operator ==(Fraction frac1, int iNo)
        { return frac1.Equals(new Fraction(iNo)); }

        public static bool operator !=(Fraction frac1, int iNo)
        { return (!frac1.Equals(new Fraction(iNo))); }

        public static bool operator ==(Fraction frac1, double dbl)
        { return frac1.Equals(new Fraction(dbl)); }

        public static bool operator !=(Fraction frac1, double dbl)
        { return (!frac1.Equals(new Fraction(dbl))); }

        public static bool operator <(Fraction frac1, Fraction frac2)
        { return frac1.Numerator * frac2.Denominator < frac2.Numerator * frac1.Denominator; }

        public static bool operator >(Fraction frac1, Fraction frac2)
        { return frac1.Numerator * frac2.Denominator > frac2.Numerator * frac1.Denominator; }

        public static bool operator <=(Fraction frac1, Fraction frac2)
        { return frac1.Numerator * frac2.Denominator <= frac2.Numerator * frac1.Denominator; }

        public static bool operator >=(Fraction frac1, Fraction frac2)
        { return frac1.Numerator * frac2.Denominator >= frac2.Numerator * frac1.Denominator; }


        /// <summary>
        /// overloaed user defined conversions: from numeric data types to Fractions
        /// </summary>
        public static implicit operator Fraction(long lNo)
        { return new Fraction(lNo); }
        public static implicit operator Fraction(double dNo)
        { return new Fraction(dNo); }
        public static implicit operator Fraction(string strNo)
        { return new Fraction(strNo); }

        /// <summary>
        /// overloaed user defined conversions: from fractions to double and string
        /// </summary>
        public static explicit operator double(Fraction frac)
        { return frac.ToDouble(); }

        public static implicit operator string(Fraction frac)
        { return frac.ToString(); }

        /// <summary>
        /// checks whether two fractions are equal
        /// </summary>
        public override bool Equals(object obj)
        {
            Fraction frac = (Fraction)obj;
            return (Numerator == frac.Numerator && Denominator == frac.Denominator);
        }

        /// <summary>
        /// returns a hash code for this fraction
        /// </summary>
        public override int GetHashCode()
        {
            return (Convert.ToInt32((Numerator ^ Denominator) & 0xFFFFFFFF));
        }

        /// <summary>
        /// internal function for negation
        /// </summary>
        private static Fraction Negate(Fraction frac1)
        {
            long iNumerator = -frac1.Numerator;
            long iDenominator = frac1.Denominator;
            return (new Fraction(iNumerator, iDenominator));

        }

        /// <summary>
        /// internal functions for binary operations
        /// </summary>
        private static Fraction Add(Fraction frac1, Fraction frac2)
        {
            try
            {
                checked
                {
                    long iNumerator = frac1.Numerator * frac2.Denominator + frac2.Numerator * frac1.Denominator;
                    long iDenominator = frac1.Denominator * frac2.Denominator;
                    return (new Fraction(iNumerator, iDenominator));
                }
            }
            catch (OverflowException)
            {
                throw new FractionException("Overflow occurred while performing arithemetic operation");
            }
            catch (Exception)
            {
                throw new FractionException("An error occurred while performing arithemetic operation");
            }
        }

        private static Fraction Multiply(Fraction frac1, Fraction frac2)
        {
            try
            {
                checked
                {
                    long iNumerator = frac1.Numerator * frac2.Numerator;
                    long iDenominator = frac1.Denominator * frac2.Denominator;
                    return (new Fraction(iNumerator, iDenominator));
                }
            }
            catch (OverflowException)
            {
                throw new FractionException("Overflow occurred while performing arithemetic operation");
            }
            catch (Exception)
            {
                throw new FractionException("An error occurred while performing arithemetic operation");
            }
        }

        /// <summary>
        /// The function returns GCD of two numbers (used for reducing a Fraction)
        /// </summary>
        private static long GCD(long iNo1, long iNo2)
        {
            // take absolute values
            if (iNo1 < 0) iNo1 = -iNo1;
            if (iNo2 < 0) iNo2 = -iNo2;

            do
            {
                if (iNo1 < iNo2)
                {
                    long tmp = iNo1;  // swap the two operands
                    iNo1 = iNo2;
                    iNo2 = tmp;
                }
                iNo1 = iNo1 % iNo2;
            } while (iNo1 != 0);
            return iNo2;
        }

        /// <summary>
        /// The function reduces(simplifies) a Fraction object by dividing both its numerator 
        /// and denominator by their GCD
        /// </summary>
        public static void ReduceFraction(Fraction frac)
        {
            try
            {
                if (frac.Numerator == 0)
                {
                    frac.Denominator = 1;
                    return;
                }

                long iGCD = GCD(frac.Numerator, frac.Denominator);
                frac.Numerator /= iGCD;
                frac.Denominator /= iGCD;

                if (frac.Denominator < 0)   // if -ve sign in denominator
                {
                    //pass -ve sign to numerator
                    frac.Numerator *= -1;
                    frac.Denominator *= -1;
                }
            } // end try
            catch (Exception exp)
            {
                throw new FractionException("Cannot reduce Fraction: " + exp.Message);
            }
        }

    }

    public class FractionException : Exception
    {
        public FractionException() : base()
        { }

        public FractionException(string Message) : base(Message)
        { }

        public FractionException(string Message, Exception InnerException) : base(Message, InnerException)
        { }
    }
}
