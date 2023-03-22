using Operadores;
using System;
using System.Globalization;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Calculadora_Csharp
{
    public partial class Background : Form
    {
        public double primeiro { get; set; }
        public double segundo { get; set; }
        public string operador { get; set; }
        private Form2 telaHistorico;
        

        public Background()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
           
        }

        public Background(string cpf, string nome, string password, string tipoUser, string email)
        {
            InitializeComponent();
            this.cpf = cpf;
            this.nome = nome;
            this.password = password;
            this.tipoUser = tipoUser;
            this.email = email;
            
        }
        private string cpf;
        private string nome;
        private string password;
        private string tipoUser;
        private string email;


        private Soma soma = new Soma();
        private Divisao div = new Divisao();
        private Multiplicacao mul = new Multiplicacao();
        private Subtracao sub = new Subtracao();
        private User user;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3(this);
            form3.Show();
        }

        private void bttnN0_Click(object sender, EventArgs e)
        {
            if (result.Text.Length <= 7)
            {
                result.Text = result.Text + "0";
            }
        }

        private void bttnN0_Click(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.D0)
            {
                bttnN0.PerformClick();
                e.Handled = true;
            }
        }

        private void bttnN1_Click(object sender, EventArgs e)
        {
            if (result.Text.Length <= 7)
            {
                result.Text = result.Text + "1";
            }
        }

        private void bttnN1_Click(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.D1)
            {
                bttnN1.PerformClick();
                e.Handled = true;
            }
        }

        private void bttnN2_Click(object sender, EventArgs e)
        {
            if (result.Text.Length <= 7)
            {
                result.Text = result.Text + "2";
            }
        }

        private void bttnN2_Click(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.D2)
            {
                bttnN2.PerformClick();
                e.Handled = true;
            }
        }

        private void bttnN3_Click(object sender, EventArgs e)
        {
            if (result.Text.Length <= 7)
            {
                result.Text = result.Text + "3";
            }
        }

        private void bttnN3_Click(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.D3)
            {
                bttnN3.PerformClick();
                e.Handled = true;
            }
        }

        private void bttnN4_Click(object sender, EventArgs e)
        {
            if (result.Text.Length <= 7)
            {
                result.Text = result.Text + "4";
            }
        }

        private void bttnN4_Click(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.D4)
            {
                bttnN4.PerformClick();
                e.Handled = true;
            }
        }

        private void bttnN5_Click(object sender, EventArgs e)
        {
            if (result.Text.Length <= 7)
            {
                result.Text = result.Text + "5";
            }
        }

        private void bttnN5_Click(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.D5)
            {
                bttnN5.PerformClick();
                e.Handled = true;
            }
        }

        private void bttnN6_Click(object sender, EventArgs e)
        {
            if (result.Text.Length <= 7)
            {
                result.Text = result.Text + "6";
            }
        }

        private void bttnN6_Click(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.D6)
            {
                bttnN6.PerformClick();
                e.Handled = true;
            }
        }

        private void bttnN7_Click(object sender, EventArgs e)
        {
            if (result.Text.Length <= 7)
            {
                result.Text = result.Text + "7";
            }
        }

        private void bttnN7_Click(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.D7)
            {
                bttnN7.PerformClick();
                e.Handled = true;
            }
        }

        private void bttnN8_Click(object sender, EventArgs e)
        {
            if (result.Text.Length <= 7)
            {
                result.Text = result.Text + "8";
            }
        }

        private void bttnN8_Click(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.D8)
            {
                bttnN8.PerformClick();
                e.Handled = true;
            }
        }

        private void bttnN9_Click(object sender, EventArgs e)
        {
            if (result.Text.Length <= 7)
            {
                result.Text = result.Text + "9";
            }
        }

        private void bttnN9_Click(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.D9)
            {
                bttnN9.PerformClick();
                e.Handled = true;
            }
        }

        private void bttnIgual_Click(object sender, EventArgs e)
        {
            if (result.Text.Length > 0)
            {
                segundo = double.Parse(result.Text);
                switch (operador)
                {
                    case "+":
                        result.Text = soma.RealizarSoma(primeiro, segundo).ToString("F1", CultureInfo.CurrentCulture);
                        break;

                    case "-":
                        result.Text = sub.RealizaSub(primeiro, segundo).ToString("F1", CultureInfo.CurrentCulture);
                        break;

                    case "X":
                        result.Text = mul.RealizaMulti(primeiro, segundo).ToString("F2", CultureInfo.CurrentCulture);
                        break;

                    case "/":
                        result.Text = div.RealizaDiv(primeiro, segundo).ToString("F2", CultureInfo.CurrentCulture);
                        break;
                }
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"{primeiro} {operador} {segundo} = {result.Text}\n");
                HistoricoCalc historico = new HistoricoCalc(0,cpf,sb);
                BancoDados.insertHistorico(historico);
                
            }
        }

        private void bttnMais_Click(object sender, EventArgs e)
        {
            if (result.Text.Length > 0)
            {
                operador = "+";
                primeiro = double.Parse(result.Text);
                result.Clear();
            }
        }

        private void bttnMenos_Click(object sender, EventArgs e)
        {
            if (result.Text.Length > 0)
            {
                operador = "-";
                primeiro = double.Parse(result.Text);
                result.Clear();
            }
        }

        private void bttnMultiplicacao_Click(object sender, EventArgs e)
        {
            if (result.Text.Length > 0)
            {
                operador = "X";
                primeiro = double.Parse(result.Text);
                result.Clear();
            }
        }

        private void bttnDivisao_Click(object sender, EventArgs e)
        {
            if (result.Text.Length > 0)
            {
                operador = "/";
                primeiro = double.Parse(result.Text);
                result.Clear();
            }
        }

        private void bttnBack_Click(object sender, EventArgs e)
        {
            string aux = result.Text;
            if (aux.Length > 0)
            {
                aux = aux.Remove(aux.Length - 1);
                result.Text = aux;
            }
        }

        private void bttnClear_Click(object sender, EventArgs e)
        {
            primeiro = 0;
            segundo = 0;
            result.Clear();
        }

        private void bttnPonto_Click(object sender, EventArgs e)
        {
            result.Text = result.Text + ",";
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            telaHistorico = new Form2(cpf, nome, password, tipoUser, email);

            bool open = true;
            if (open)
            {
                int x = this.Location.X;
                int y = this.Location.Y;
                int X1 = x + 300;
                telaHistorico.SetXY(X1, y);
                telaHistorico.Show();
            }
            primeiro = 0;
            segundo = 0;
            operador = null;
        }

        private void buttonChangePass_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form4 form4 = new Form4(cpf);
            form4.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tipoUser.Equals("Admin"))
            {
                this.Hide();
                Form5 form5 = new Form5();
                form5.Show();
            }
            else
            {
                MessageBox.Show("Usuário não possui permissão para efetuar cadastros.");
            }            
            
        }
    }
}