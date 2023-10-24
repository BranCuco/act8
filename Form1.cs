using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace act8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Stack<int> SumarStack(string num1, string num2)
        {
            Stack<int> Num1 = new Stack<int>();
            Stack<int> Num2 = new Stack<int>();
            Stack<int> resultado = new Stack<int>();

            foreach (char digito in num1)
            {
                Num1.Push(int.Parse(digito.ToString()));
            }

            foreach (char digito in num2)
            {
                Num2.Push(int.Parse(digito.ToString()));
            }

            int acarreo = 0;
            int digito1 = 0;
            int digito2 = 0;
            while (Num1.Count > 0 || Num2.Count > 0)
            {
                if (Num1.Count == 0)
                {
                    digito1 = 0;
                }
                else
                {
                    digito1 = Num1.Pop();
                }

                if (Num2.Count == 0)
                {
                    digito2 = 0;
                }
                else
                {
                    digito2 = Num2.Pop();
                }

                int res = digito1 + digito2 + acarreo;

                if (res >= 10)
                {
                    acarreo = res / 10;
                    res %= 10;
                }
                else
                {
                    acarreo = 0;
                }

                resultado.Push(res);

                if (Num1.Count == 0 && Num2.Count == 0 && acarreo != 0)
                {
                    resultado.Push(acarreo);
                }
            }
            return resultado;
        }

        private void buttonSumar_Click(object sender, EventArgs e)
        {
            string num1 = textBoxNum1.Text;
            string num2 = textBoxNum2.Text;

            Stack<int> resultado = SumarStack(num1, num2);

            textBoxResultado.Text = string.Join("", resultado);

            // Limpiar las listas antes de mostrar el resultado
            listBoxPilaNum1.Items.Clear();
            listBoxPilaNum2.Items.Clear();
            listBoxPilaResultado.Items.Clear();

            // Llenar las listas con los valores de las pilas
            foreach (char digito in num1)
            {
                listBoxPilaNum1.Items.Insert(0, int.Parse(digito.ToString()));
            }

            foreach (char digito in num2)
            {
                listBoxPilaNum2.Items.Insert(0, int.Parse(digito.ToString()));
            }

            while (resultado.Count > 0)
            {
                listBoxPilaResultado.Items.Insert(0, resultado.Pop());
            }
        }
    }
}
