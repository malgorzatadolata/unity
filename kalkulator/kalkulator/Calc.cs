using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace kalkulator
{
    public partial class Calc : Form
    {
        kalkulator.liczenie licz = new liczenie();
        //bool gdzieWpisac = true;
        //bool czyCzyscicPasekWyniku = false;

        public Calc()
        {
            InitializeComponent();
        }

        private void liczba_Click(object sender, EventArgs e)
        {
            //if (czyCzyscicPasekWyniku)
            pasekWyniku.Text += (sender as Button).Text;
            //else
            //    pasekWyniku.Text += (sender as Button).Text;
            //czyCzyscicPasekWyniku = false;
        }
        private void przecinek_Click(object sender, EventArgs e)
        {
            if (pasekWyniku.Text.LastOrDefault().ToString().IndexOfAny("1234567890".ToCharArray()) == -1)
                pasekWyniku.Text += "0,";
            else
                pasekWyniku.Text += ",";
            //czyCzyscicPasekWyniku = false;
        }
        private void działanie_Click(object sender, EventArgs e)
        {
            string rownanie = pasekWyniku.Text;
            string[] podzial = rownanie.Split(new Char[] { '+', '-', '/', '*', '^', '!' });
            if (podzial.Length > 2)
            {
                MessageBox.Show("Nie wpisano prawidłowo operacji na 2 liczbach dodatnich", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);//komunikat o błędzie, ale tylko, jeśli pole nie jest puste                
            }
            else
            {
                //MessageBox.Show(podzial[0], "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);//komunikat o błędzie, ale tylko, jeśli pole nie jest puste
                //MessageBox.Show(podzial[1], "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);//komunikat o błędzie, ale tylko, jeśli pole nie jest puste
                try
                {
                    double a = double.Parse(podzial[0]);
                    double b = double.Parse(podzial[1]);
                    char operacja = Convert.ToChar(rownanie.Substring(podzial[0].Length, 1));
                    pasekWyniku.Text = licz.licz(a, b, operacja).ToString();
                }
                catch
                {
                    MessageBox.Show("Nie wpisano prawidłowo operacji na 2 liczbach dodatnich", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);//komunikat o błędzie, ale tylko, jeśli pole nie jest puste
                }
            }
            //MessageBox.Show(operacja.ToString(), "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);//komunikat o błędzie, ale tylko, jeśli pole nie jest puste            
            //czyCzyscicPasekWyniku = true;//czyścimy pasek tekstowy
            //gdzieWpisac = false;
        }

        private void czyszczenie_Click(object sender, EventArgs e)
        {
            //licz.a = licz.b = 0;
            //licz.dzialanie = ' ';
            pasekWyniku.Text = "";
            //czyCzyscicPasekWyniku = false;
            //gdzieWpisac = true;
        }
        private void systemBinarny_Click(object sender, EventArgs e)
        {
            try
            {
                pasekWyniku.Text = Convert.ToString(int.Parse(pasekWyniku.Text),2);
            }
            catch
            {
                MessageBox.Show("Nieprawidłowy operand dla konwersji do systemu binarnego", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);//komunikat o błędzie, ale tylko, jeśli pole nie jest puste
            }
        }
        private void silnia_Click(object sender, EventArgs e)
        {
            try
            {
                long s = 1;
                for (int i = 1; i <= Double.Parse(pasekWyniku.Text); ++i)
                    s *= i;
                pasekWyniku.Text = Convert.ToString((double)s);
            }
            catch
            {
                MessageBox.Show("Nieprawidłowy operand dla operacji silni", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);//komunikat o błędzie, ale tylko, jeśli pole nie jest puste
            }
        }
    }
}
