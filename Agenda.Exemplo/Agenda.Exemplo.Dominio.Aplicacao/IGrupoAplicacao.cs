using Agenda.Exemplo.Dominio.DTO;
using System.Collections.Generic;

namespace Agenda.Exemplo.Dominio.Aplicacao
{
    public interface IGrupoAplicacao
    {
        GrupoDTO ObterGrupo(int id);
        IList<GrupoDTO> ObterGrupos(string nome);
    }
}
