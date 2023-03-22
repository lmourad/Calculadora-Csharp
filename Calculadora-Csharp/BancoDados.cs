using MySqlConnector;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Calculadora_Csharp

{
    internal class BancoDados
    {
        private MySqlDataAdapter data_adapter;
        private MySqlConnection conexao;

        public static MySqlConnection conexaoBanco()
        {
            string connString = @"server=127.0.0.1;uid=root; password=WP$22; database=calculadora;ConnectionTimeout=2";
            MySqlConnection conexao = new MySqlConnection(connString);
            conexao.Open();
            return conexao;
        }

        public static DataTable Consulta(string consultaSQL)
        {
            MySqlDataAdapter data_adapter = null;
            DataTable data_table = new DataTable();

            try
            {
                using (var cmd = conexaoBanco().CreateCommand())
                {
                    cmd.CommandText = consultaSQL;
                    data_adapter = new MySqlDataAdapter(cmd.CommandText, conexaoBanco());
                    data_adapter.Fill(data_table);
                    return data_table;
                }
            }
            catch (MySqlException erro)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(erro.GetType().ToString());
                sb.AppendLine(erro.Message);
                sb.Append(erro.SqlState);
                sb.AppendLine("\n");
                sb.AppendLine(erro.StackTrace);
                MessageBox.Show(sb.ToString());
                throw erro;
            }
            catch (Exception erro)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(erro.GetType().ToString());
                sb.AppendLine(erro.Message);
                sb.AppendLine("\n");
                sb.AppendLine(erro.StackTrace);
                MessageBox.Show(sb.ToString());
                throw erro;
            }
        }

        public static void insertHistorico(HistoricoCalc historico)
        {
            try
            {
                using (var connect = conexaoBanco())
                using (var cmd = connect.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO historico (id, cpfUser, historico)" +
                                      "VALUES( @id, @cpfUser, @historico)";
                    cmd.Parameters.AddWithValue("@id", historico.getId());
                    cmd.Parameters.AddWithValue("@cpfUser", historico.getCpfUser());
                    cmd.Parameters.AddWithValue("@historico", historico.getHistorico());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Calculo incluído no histórico com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar histórico \n" + ex.Message);
            }
        }

        public static void insertUser(User user)
        {
            try
            {
                using (var connect = conexaoBanco())
                using (var cmd = connect.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO userCalc (cpf, senha, tipoUser, email, nome)" +
                                      "VALUES( @cpf, @senha, @tipoUser, @email, @nome)";
                    cmd.Parameters.AddWithValue("@cpf", user.getCpf());
                    cmd.Parameters.AddWithValue("@senha", user.getSenha());
                    cmd.Parameters.AddWithValue("@tipoUser", user.getTipoUser());
                    cmd.Parameters.AddWithValue("@email", user.getEmail());
                    cmd.Parameters.AddWithValue("@nome", user.getNome());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Usuário incluído com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar usuário \n" + ex.Message);
            }
        }

        public static void updateUser(User user)
        {
            try
            {
                using (var connect = conexaoBanco())
                using (var cmd = connect.CreateCommand())
                {
                    cmd.CommandText = "UPDATE userCalc SET senha = ?, tipoUser = ?, email = ?, nome = ? WHERE cpf = ?";
                    cmd.Parameters.Add("@senha", MySqlDbType.VarChar, 45).Value = user.getSenha();
                    cmd.Parameters.Add("@tipoUser", MySqlDbType.VarChar, 45).Value = user.getTipoUser();
                    cmd.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = user.getEmail();
                    cmd.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = user.getNome();
                    cmd.Parameters.Add("cpf", MySqlDbType.VarChar, 14).Value = user.getCpf();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Usuário atualizado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar usuário \n" + ex.Message);
            }
        }

        public static void updatePassword(String cpf, String newPassword)
        {
            try
            {
                using (var connect = conexaoBanco())
                using (var cmd = connect.CreateCommand())
                {
                    cmd.CommandText = "UPDATE userCalc SET senha = ? WHERE cpf = ?";
                    cmd.Parameters.Add("@senha", MySqlDbType.VarChar, 45).Value = newPassword;
                    cmd.Parameters.Add("cpf", MySqlDbType.VarChar, 14).Value = cpf;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Password atualizado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar password \n" + ex.Message);
            }
        }

    }
}