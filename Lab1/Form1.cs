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
            errorLabel.Text = "";
            bool isNesovmest = false;
            double propabilityA = 0;
            double propabilityB = 0;
            double propabilityC = 0;
            double countTest = 0;

            try
            {
                isNesovmest = radioButton1.Checked;
                propabilityA = double.Parse(textBox1.Text);
                propabilityB = double.Parse(textBox2.Text);
                propabilityC = double.Parse(textBox3.Text);
                countTest = double.Parse(textBox4.Text);

                if (isNesovmest == true)
                {
                    if (propabilityA + propabilityB + propabilityC > 1) throw new Exception("Сумма вероятностей больше 1");
                    Nesovmest(propabilityA, propabilityB, propabilityC, countTest);
                }
                else 
                {
                    if (propabilityA > 1 || propabilityB > 1 || propabilityC > 1) throw new Exception("Одна из вероятностей больше 1");
                    Nezavis(propabilityA, propabilityB, propabilityC, countTest);
                }
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
            }
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
            label8.Text = (A + B + C).ToString();
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
                double value = rnd.NextDouble()*A;
                double value1 = rnd.NextDouble()*B;
                double value2 = rnd.NextDouble()*C;
                if (value <= A && value <=B && value <= C) a = true;
                if (value1 <= A && value1 <= B && value1 <= C) b = true;
                if (value2 <= A && value2 <= B && value2 <= C) c = true;
                if (a && b && c) counter++;
            }

            label7.Text = (counter / countTests).ToString();
            label8.Text = (A * B * C).ToString();
        }
    }
}