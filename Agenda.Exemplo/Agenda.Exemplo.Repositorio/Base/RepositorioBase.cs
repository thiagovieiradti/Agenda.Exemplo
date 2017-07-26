using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Agenda.Exemplo.Repositorio.Base
{
    public class RepositorioBase
    {
        protected IDbConnection Conexao;

        public RepositorioBase()
        {
            Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["connAgenda"].ConnectionString);
        }

        public void Executar(string sql)
        {
            Conexao.Execute(sql);
        }

    }
}
