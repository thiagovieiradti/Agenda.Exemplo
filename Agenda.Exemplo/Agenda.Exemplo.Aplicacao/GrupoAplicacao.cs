using Agenda.Exemplo.Aplicacao.Mapper;
using Agenda.Exemplo.Dominio.Aplicacao;
using Agenda.Exemplo.Dominio.DTO;
using Agenda.Exemplo.Dominio.Entidade;
using Agenda.Exemplo.Dominio.Repositorio;
using System;
using System.Collections.Generic;

namespace Agenda.Exemplo.Aplicacao
{
    public class GrupoAplicacao : IGrupoAplicacao
    {
        private readonly IGrupoRepositorio _grupoRepositorio;
        
        public GrupoAplicacao(IGrupoRepositorio grupoRepositorio)
        {
            _grupoRepositorio = grupoRepositorio;
        }

        private void ValidarGrupo(Grupo grupo)
        {
            if (string.IsNullOrWhiteSpace(grupo.Nome))
                throw new Exception("Nome do grupo deve ser preenchido.");
        }

        private void ValidarGrupoInserir(Grupo grupo)
        {
            ValidarGrupo(grupo);
        }

        private void ValidarGrupoEditar(Grupo grupo)
        {
            if (grupo.Id <= 0)
                throw new Exception("ID do grupo não definido");

            ValidarGrupo(grupo);
        }
        
        public GrupoDTO ObterGrupo(int id)
        {
            return _grupoRepositorio.ObterGrupo(id).CriarDTO();
        }

        public IList<GrupoDTO> ObterGrupos(string nome)
        {
            return _grupoRepositorio.ObterGrupos(nome).CriarDTO();
        }

        public int InserirGrupo(GrupoDTO grupoDTO)
        {
            var grupoEntidade = grupoDTO.CriarEntidade();
            ValidarGrupoInserir(grupoEntidade);
            return _grupoRepositorio.InserirGrupo(grupoEntidade);
        }

        public void EditarGrupo(GrupoDTO grupoDTO)
        {
            var grupoEntidade = grupoDTO.CriarEntidade();
            ValidarGrupoEditar(grupoEntidade);
            _grupoRepositorio.EditarGrupo(grupoEntidade);
        }
        
        public void RemoverGrupo(int id)
        {
            _grupoRepositorio.RemoverGrupo(id);
        }
    }
}
