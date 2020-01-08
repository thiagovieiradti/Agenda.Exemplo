﻿using Agenda.Exemplo.Dominio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Exemplo.Dominio.Aplicacao
{
    public interface IChamadaAplicacao
    {
        int InserirChamada(ChamadaDTO chamada);
        ChamadaDTO ObterChamada(int chamadaId);
        IList<ChamadaDTO> ObterChamadas(int? grupoId, string nome, string data);
        void RemoverChamada(int chamadaId);
    }
}
