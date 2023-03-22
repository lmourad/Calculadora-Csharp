using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace Calculadora_Csharp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

        }

        public Form3(Background form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private Background form1;

        private string cpf;
        private string password;
        private string tipoUser;
        private string email;
        private string nome;


        DataTable dt = new DataTable();
        

        private void buttonAccess_Click_1(object sender, EventArgs e)
        {
            cpf = textBox1.Text;
            password = textBox2.Text;

            if (cpf == "" || password == "")
            {
                MessageBox.Show("Usuário ou Senha inválidos!\nVerifique os dados e tente novamente.");
                textBox1.Focus();
                return;
            }
            else
            {
                try
                {
                    string sql = "SELECT * FROM userCalc WHERE cpf= '" + cpf + "' AND senha= '" + password + "'";
                    dt = BancoDados.Consulta(sql);

                    if (dt.Rows.Count == 1)
                    {
                        using (MySqlConnection conn = BancoDados.conexaoBanco())
                        {
                           
                            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    tipoUser = reader.GetString(2);
                                    email = reader.GetString(3);
                                    nome = reader.GetString(4);
                                }

                            }
                        }

                        this.Hide();
                        Background form1 = new Background(cpf, nome, password, tipoUser, email);
                        form1.Show();
                    }
                    else
                    {

                        MessageBox.Show("Usuário ou Senha inválidos!\nVerifique os dados e tente novamente.");
                        textBox1.Focus();
                        return;

                    }

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro de login!" + erro);
                }
            }
        }

    }
    
}
