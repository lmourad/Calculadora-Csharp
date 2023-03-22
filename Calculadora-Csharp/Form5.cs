using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calculadora_Csharp
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private string cpf;
        private string password;
        private string tipoUser;
        private string email;
        private string nome;

        DataTable dt = new DataTable();

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            cpf = textCPF.Text;
            password = textBoxSenha.Text;
            tipoUser = comboBox1Usertype.Text;
            email = textBoxEmail.Text;
            nome = textBoxNome.Text;

            if (cpf != "" && password != "" && tipoUser != "" && email != "" && nome != "")
            {
                User user = new User(cpf, nome, password, tipoUser, email);

                try
                {
                    string sql = "SELECT * FROM userCalc WHERE cpf= '" + cpf + "'";
                    dt = BancoDados.Consulta(sql);

                    if (dt.Rows.Count == 1)
                    {
                        BancoDados.updateUser(user);
                        
                    }
                    else
                    {
                        BancoDados.insertUser(user);
                    }

                    this.Close();
                    Background form1 = new Background();
                    form1.Show();
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro de login!" + erro);
                }


            }
            else
            {
                MessageBox.Show("Todos os campos devem estar preenchidos");
            }           


        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            this.Close();
            Background form1 = new Background();
            form1.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }

}
