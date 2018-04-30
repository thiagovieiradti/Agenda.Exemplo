using Agenda.Exemplo.Dominio.Entidade;
using Agenda.Exemplo.Dominio.Repositorio;
using Agenda.Exemplo.Repositorio.Base;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Exemplo.Repositorio
{
    public class ContatoRepositorio : RepositorioBase, IContatoRepositorio
    {
        public ContatoRepositorio() : base()
        {

        }

        public object Conexao { get; private set; }

        public void EditarContato(Contato contato)
        {
            var sql = @"
                UPDATE
                    Contato
                SET
                    Nome = @Nome,
                    GrupoId = @GrupoId
                WHERE
                    ContatoId = @ContatoId
            ";

            using (var conexao = AbrirConexao())
            {
                conexao.Execute(sql, new
                {
                    contato.Nome,
                    contato.Grupo.GrupoId,
                    contato.ContatoId
                });
            }
        }

        public int InserirContato(Contato contato)
        {
            var sql = @"
                INSERT INTO Contato (Nome, GrupoId)
                VALUES (@Nome, @GrupoId)
                SELECT SCOPE_IDENTITY()";

            using (var conexao = AbrirConexao())
            {
                return conexao.QuerySingleOrDefault<int>(sql,
                new
                {
                    contato.Nome,
                    contato.Grupo.GrupoId
                });
            }
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
                    ON c.GrupoId = g.GrupoId
                WHERE
                    c.ContatoId = @ContatoId";

            using (var conexao = AbrirConexao())
            {
                return conexao.Query<Contato, Grupo, Contato>(sql, (contato, grupo) =>
                {
                    contato.Grupo = grupo;
                    return contato;
                }, splitOn: "GrupoId", param: new { ContatoId = contatoId }).AsList().SingleOrDefault();
            }
        }

        public IList<Contato> ObterContatos(int? grupoId, string nome)
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
                    ON c.GrupoId = g.GrupoId
                WHERE 
                    {0}
                ORDER BY 
                    g.Nome, 
                    c.Nome";

            var clausulaWhere = new List<string>();
            var parametros = new DynamicParameters();

            clausulaWhere.Add("1 = 1");

            if (grupoId.HasValue)
            {
                clausulaWhere.Add("g.GrupoId = @GrupoId");
                parametros.Add("GrupoId", grupoId);
            }

            if (!string.IsNullOrEmpty(nome))
            {
                clausulaWhere.Add("c.Nome LIKE @Nome");
                parametros.Add("Nome", "%" + nome + "%");
            }

            sql = string.Format(sql, string.Join(" AND ", clausulaWhere));

            using (var conexao = AbrirConexao())
            {
                return conexao.Query<Contato, Grupo, Contato>(sql, (contato, grupo) =>
                {
                    contato.Grupo = grupo;
                    return contato;
                }, splitOn: "GrupoId", param: parametros).AsList();
            }
        }

        public void RemoverContato(int contatoId)
        {
            var sql = @"DELETE Contato WHERE contatoId = @contatoId";
            using (var conexao = AbrirConexao())
            {
                conexao.Execute(sql, new { contatoId });
            }
        }
    }
}
