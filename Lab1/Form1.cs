using System.Diagnostics.Metrics;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isNesovmest = radioButton1.Checked;
            double propabilityA = double.Parse(textBox1.Text) / 100;
            double propabilityB = double.Parse(textBox2.Text) / 100;
            double propabilityC = double.Parse(textBox3.Text) / 100;
            double countTest = double.Parse(textBox4.Text);

            if (isNesovmest == true) Nesovmest(propabilityA, propabilityB, propabilityC, countTest);
            else Nezavis(propabilityA, propabilityB, propabilityC, countTest);
        }

        void Nesovmest(double A, double B = 0, double C = 0, double countTests = 0)
        {
            int counter = 0;
            bool a = false;
            bool b = false;
            bool c = false;

            for (int i = 0; i < countTests; i++)
            {
                a = b = c = false;
                Random rnd = new Random();
                double value = rnd.NextDouble();
                if (value <= A) a = true;
                if (A < value && value <= A + B) b = true;
                if (A + B < value && value <= A + B + C) c = true;
                if (a || b || c) counter++;
            }

            label7.Text = (counter / countTests).ToString();
            label8.Text = (A+B+C).ToString();
        }

        void Nezavis(double A, double B = 0, double C = 0, double countTests = 0)
        {
            int counter = 0;
            bool a = false;
            bool b = false;
            bool c = false;

            for (int i = 0; i < countTests; i++)
            {
                a = b = c = false;
                Random rnd = new Random();
                double value = rnd.NextDouble();
                if (value <= A) a = true;
                if (value <= B) b = true;
                if (value <= C) c = true;
                if (a && b && c) counter++;
            }

            label7.Text = (counter / countTests).ToString();
            label8.Text = (1-(1-A)*(1-B)*(1-C)).ToString();
        }
    }
}