using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calculadora_Csharp
{
    public partial class Form4 : Form
    {
        public Form4(string cpf)
        {
            InitializeComponent();
            this.cpf = cpf;
        }

        private string cpf;
             

        private Background form1;
        DataTable dt = new DataTable();


        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string oldPassword = textBoxOld.Text;
            string newPassword = textBoxNewPass.Text;

            if (oldPassword == "" || newPassword == "")
            {
                MessageBox.Show("Usuário ou Senha inválidos!\nVerifique os dados e tente novamente.");
                textBoxOld.Focus();
                return;
            }
            else
            {
                try
                {
                    string sql = "SELECT senha FROM userCalc WHERE cpf = '" + cpf + "' AND senha= '" + oldPassword + "'";
                    dt = BancoDados.Consulta(sql);

                    if (dt.Rows.Count == 1)
                    {
                        
                        BancoDados.updatePassword(cpf, newPassword);                       

                        this.Hide();
                        Form3 form3 = new Form3();
                        form3.Show();
                    }
                    else
                    {

                        MessageBox.Show("Não foi possível atualizar a senha.");
                        textBoxOld.Focus();
                        return;

                    }

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro de login!" + erro);
                }
            }
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            this.Close();
            Background form1 = new Background();
            form1.Show();
        }
    }
}
