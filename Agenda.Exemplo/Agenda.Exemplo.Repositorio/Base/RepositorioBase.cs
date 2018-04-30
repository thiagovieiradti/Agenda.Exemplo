using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Agenda.Exemplo.Repositorio.Base
{
    public class RepositorioBase
    {
        protected IDbConnection AbrirConexao()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["connAgenda"].ConnectionString);
        }

        public void Executar(string sql)
        {
            using (var conexao = AbrirConexao())
            {
                conexao.Execute(sql);
            }
        }

    }
}
