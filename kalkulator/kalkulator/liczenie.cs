using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kalkulator
{


    public class liczenie
    {
        public double licz(double a, double b, char operacja)
        {
            if (operacja == '+') //dodawanie
                return a + b;
            if (operacja == '-') //odejmowanie
                return a - b;
            if (operacja == '*') //mnożenie
                return a * b;
            if (operacja == '/') // dzielenie
                if (b == 0)
                {
                    MessageBox.Show("Pamiętaj cholero, nie dziel przez 0!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);//komunikat o błędzie, ale tylko, jeśli pole nie jest puste
                }
                else
                {
                    return a / b;
                }               
            if (operacja == '^') // potęgowanie
                return Math.Pow(a, b);
            else
                return 0;
        }
    }
}

