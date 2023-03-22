using System;

namespace Calculadora_Csharp
{
    internal class User
    {
        private string cpf;
        private string nome;
        private string senha;
        private string tipoUser;
        private string email;

        public User(string cpf, string nome , string senha, string tipoUser, string email)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.senha = senha;
            this.tipoUser = tipoUser;
            this.email = email;
        }

        public String getCpf()
        {
            return cpf;
        }

        public void setCpf(String cpf)
        {
            this.cpf = cpf;
        }

        public String getNome()
        {
            return nome;
        }

        public void setNome(String nome)
        {
            this.nome = nome;
        }

        public String getEmail()
        {
            return email;
        }

        public void setEmail(String email)
        {
            this.email = email;
        }

        public String getSenha()
        {
            return senha;
        }

        public void setSenha(String senha)
        {
            this.senha = senha;
        }

        public String getTipoUser()
        {
            return tipoUser;
        }

        public void setTipoUser(String tipoUser)
        {
            this.tipoUser = tipoUser;
        }
    }
}