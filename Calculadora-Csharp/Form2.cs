using MySqlConnector;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Calculadora_Csharp
{
    public partial class Form2 : Form
    {
        private int X { get; set; }
        private int Y { get; set; }

        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
        }

        public Form2(string cpf, string nome, string password, string tipoUser, string email)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
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

        public void SetXY(int x, int y)
        {
            X = x;
            Y = y;
            this.Location = new Point(X, Y);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form_2_Load(object sender, EventArgs e)
        {
            int i = 0;
            DataTable dt = new DataTable();
            string selectconsulta = "";

            try
            {
                selectconsulta = "SELECT * FROM historico;";
                dt = BancoDados.Consulta(selectconsulta);

                if (dt.Rows.Count == 1)
                {
                    if (tipoUser.Equals("Admin"))
                    {
                        selectconsulta = @"SELECT id AS 'ID', cpfUser AS 'CPF_USER', historico AS 'HISTORICO' FROM historico ORDER BY id ASC;";

                        dgv_Historico.DataSource = BancoDados.Consulta(selectconsulta);
                        dgv_Historico.Columns[0].Width = 40;
                        dgv_Historico.Columns[1].Width = 110;
                        dgv_Historico.Columns[2].Width = 200;

                        dgv_Historico.Sort(dgv_Historico.Columns[i], ListSortDirection.Ascending);
                    }
                    else
                    {
                        selectconsulta = @"SELECT id AS 'ID', cpfUser AS 'CPF_USER', historico AS 'HISTORICO' FROM historico WHERE cpfUser = '" + cpf + "'ORDER BY id ASC;";

                        dgv_Historico.DataSource = BancoDados.Consulta(selectconsulta);
                        dgv_Historico.Columns[0].Width = 40;
                        dgv_Historico.Columns[1].Width = 110;
                        dgv_Historico.Columns[2].Width = 200;

                        dgv_Historico.Sort(dgv_Historico.Columns[i], ListSortDirection.Ascending);
                    }
                }
                else
                {

                    MessageBox.Show("Histórico vazio!");
                    this.Close();

                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Histórico!" + erro);
            }

           
        }
    }
}