using System;
using System.Text;

namespace Calculadora_Csharp
{
    public class HistoricoCalc
    {
        private int id;
        private string cpfUser;
        private StringBuilder historico;

        public HistoricoCalc(int id, string cpfUser, StringBuilder historico)
        {
            this.id = id;
            this.cpfUser = cpfUser;
            this.historico = historico;
        }

        public int getId()
        { return id; }

        public string getCpfUser()
        { return cpfUser; }

        public StringBuilder getHistorico()
        { return historico; }

        public void setId(int id)
        {
            this.id = id;
        }

        public void setCpfUser(String cpfUser)
        {
            this.cpfUser = cpfUser;
        }

        public void setHistorico(StringBuilder historico)
        {
            this.historico = historico;
        }
    }
}