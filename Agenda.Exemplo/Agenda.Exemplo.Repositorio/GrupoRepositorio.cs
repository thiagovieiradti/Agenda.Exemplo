using Agenda.Exemplo.Dominio.Entidade;
using Agenda.Exemplo.Dominio.Repositorio;
using Agenda.Exemplo.Repositorio.Base;
using Dapper;
using System;
using System.Collections.Generic;

namespace Agenda.Exemplo.Repositorio
{
    public class GrupoRepositorio : ConexaoBase, IGrupoRepositorio
    {
        public GrupoRepositorio() : base()
        {

        }

        public void EditarGrupo(Grupo grupo)
        {
            throw new NotImplementedException();
        }

        public int InserirGrupo(Grupo grupo)
        {
            throw new NotImplementedException();
        }

        public Grupo ObterGrupo(int id)
        {
            var sql = "SELECT Id, Nome FROM Grupo WHERE Id = @Id";
            return Conexao.QuerySingleOrDefault<Grupo>(sql, new { Id = id});
        }

        public IList<Grupo> ObterGrupos(string nome)
        {
            var sql = "SELECT Id, Nome FROM Grupo";

            var parametros = new DynamicParameters();

            if (!string.IsNullOrWhiteSpace(nome))
            {
                sql += " WHERE Nome LIKE @Nome";
                parametros.Add("Nome", "%" + nome + "%");
            }

            return Conexao.Query<Grupo>(sql, parametros).AsList();
        }

        public void RemoverGrupo(int id)
        {
            throw new NotImplementedException();
        }
    }
}
