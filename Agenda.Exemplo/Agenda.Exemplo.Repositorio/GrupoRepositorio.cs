﻿using Agenda.Exemplo.Dominio.Entidade;
using Agenda.Exemplo.Dominio.Repositorio;
using Agenda.Exemplo.Repositorio.Base;
using Dapper;
using System.Collections.Generic;

namespace Agenda.Exemplo.Repositorio
{
    public class GrupoRepositorio : RepositorioBase, IGrupoRepositorio
    {
        public GrupoRepositorio() : base()
        {

        }

        public void EditarGrupo(Grupo grupo)
        {
            var sql = @"
                UPDATE Grupo
                SET Nome = @Nome
                WHERE GrupoId = @GrupoId
            ";

            using (var conexao = AbrirConexao())
            {
                conexao.Execute(sql, grupo);
            }
        }

        public int InserirGrupo(Grupo grupo)
        {
            var sql = @"
                INSERT INTO Grupo (Nome) VALUES (@Nome)
                SELECT SCOPE_IDENTITY()
            ";
            using (var conexao = AbrirConexao())
            {
                return conexao.QueryFirstOrDefault<int>(sql, grupo);
            }
        }

        public Grupo ObterGrupo(int grupoId)
        {
            var sql = "SELECT GrupoId, Nome FROM Grupo WHERE GrupoId = @GrupoId";
            using (var conexao = AbrirConexao())
            {
                return conexao.QuerySingleOrDefault<Grupo>(sql, new { GrupoId = grupoId });
            }
        }

        public IList<Grupo> ObterGrupos(string nome)
        {
            var sql = "SELECT GrupoId, Nome FROM Grupo";

            var parametros = new DynamicParameters();

            if (!string.IsNullOrWhiteSpace(nome))
            {
                sql += " WHERE Nome LIKE @Nome";
                parametros.Add("Nome", "%" + nome + "%");
            }

            sql += " ORDER BY Nome";
            using (var conexao = AbrirConexao())
            {
                return conexao.Query<Grupo>(sql, parametros).AsList();
            }
        }

        public void RemoverGrupo(int grupoId)
        {
            var sql = @"DELETE Grupo WHERE GrupoId = @GrupoId";
            using (var conexao = AbrirConexao())
            {
                conexao.Execute(sql, new { GrupoId = grupoId });
            }
        }
    }
}
