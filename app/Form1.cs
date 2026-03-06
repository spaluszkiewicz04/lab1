using System;
using System.Drawing;
using System.Windows.Forms;
using MatLib;

namespace App
{
    public partial class Form1 : Form
    {

        private TextBox number1;
        private TextBox number2;
        private Button add, substract, multiply, divide;
        private Label result;

        private Calc calc;

        public Form1()
        {
            
            calc = new Calc();

            this.Text = "Kalkulator";
            this.Size = new Size(300, 200);

            number1 = new TextBox() { Location = new Point(20, 20), Width = 110 };
            number2 = new TextBox() { Location = new Point(140, 20), Width = 110 };

            add = new Button() { Text = "+", Location = new Point(20, 60), Width = 50 };
            substract = new Button() { Text = "-", Location = new Point(80, 60), Width = 50 };
            multiply = new Button() { Text = "*", Location = new Point(140, 60), Width = 50 };
            divide = new Button() { Text = "/", Location = new Point(200, 60), Width = 50 };

            result = new Label() { Text = ":)", Location = new Point(20, 110), AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };

            add.Click += (sender, e) => Oblicz("dodawanie");
            substract.Click += (sender, e) => Oblicz("odejmowanie");
            multiply.Click += (sender, e) => Oblicz("mnożenie");
            divide.Click += (sender, e) => Oblicz("dzielenie");

            this.Controls.Add(number1);
            this.Controls.Add(number2);
            this.Controls.Add(add);
            this.Controls.Add(substract);
            this.Controls.Add(multiply);
            this.Controls.Add(divide);
            this.Controls.Add(result);
        }

        private void Oblicz(string operacja)
        {
            if (!double.TryParse(number1.Text, out double a) || !double.TryParse(number2.Text, out double b))
            {
                MessageBox.Show("Błąd danych");
                return;
            }

            try
            {
                double wynik = 0;
                switch (operacja)
                {
                    case "dodawanie": wynik = calc.Add(a, b); break;
                    case "odejmowanie": wynik = calc.Subtract(a, b); break;
                    case "mnożenie": wynik = calc.Multiply(a, b); break;
                    case "dzielenie": wynik = calc.Divide(a, b); break;
                }
                result.Text = wynik.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd");
            }
        }
    }
}