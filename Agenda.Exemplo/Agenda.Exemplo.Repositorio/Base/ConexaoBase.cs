using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Agenda.Exemplo.Repositorio.Base
{
    public class ConexaoBase
    {
        protected IDbConnection Conexao;

        public ConexaoBase()
        {
            Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["dti_crud"].ConnectionString);
        }
    }
}
