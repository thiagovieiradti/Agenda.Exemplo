using Agenda.Exemplo.Dominio.DTO;
using System.Collections.Generic;

namespace Agenda.Exemplo.Dominio.Aplicacao
{
    public interface IGrupoAplicacao
    {
        GrupoDTO ObterGrupo(int grupoId);
        IList<GrupoDTO> ObterGrupos(string nome);
        int InserirGrupo(GrupoDTO grupo);
        void EditarGrupo(GrupoDTO grupo);
        void RemoverGrupo(int grupoId);
    }
}
