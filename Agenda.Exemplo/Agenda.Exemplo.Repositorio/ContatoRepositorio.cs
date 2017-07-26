using Agenda.Exemplo.Dominio.Entidade;
using Agenda.Exemplo.Dominio.Repositorio;
using Agenda.Exemplo.Repositorio.Base;
using Dapper;
using System.Linq;

namespace Agenda.Exemplo.Repositorio
{
    public class ContatoRepositorio : RepositorioBase, IContatoRepositorio
    {
        public ContatoRepositorio() : base()
        {

        }

        public int InserirContato(Contato contato)
        {
            var sql = @"
                INSERT INTO Contato (Nome, GrupoId)
                VALUES (@Nome, @GrupoId)
                SELECT SCOPE_IDENTITY()";

            return Conexao.QuerySingleOrDefault<int>(sql,
                new {
                    Nome = contato.Nome,
                    GrupoId = contato.Grupo.GrupoId
                });
        }

        public Contato ObterContato(int contatoId)
        {
            var sql = @"
                SELECT
                    c.ContatoId,
                    c.Nome,
                    g.GrupoId,
                    g.Nome
                FROM
                    Contato c
                INNER JOIN Grupo g
                    ON c.GrupoId = g.GrupoId";

            return Conexao.Query<Contato, Grupo, Contato>(sql, (contato, grupo) =>
            {
                contato.Grupo = grupo;
                return contato;
            }, splitOn: "GrupoId").AsList().SingleOrDefault();
        }
    }
}
