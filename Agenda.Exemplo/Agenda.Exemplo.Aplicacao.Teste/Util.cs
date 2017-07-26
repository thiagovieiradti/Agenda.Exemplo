using Agenda.Exemplo.Dominio.DTO;
using Agenda.Exemplo.Repositorio.Base;

namespace Agenda.Exemplo.Aplicacao.Teste
{
    public static class Util
    {
        // extensão
        public static GrupoDTO Clonar(this GrupoDTO dto)
        {
            return new GrupoDTO()
            {
                grupoId = dto.grupoId,
                nome = dto.nome
            };
        }
        
        // entidade
        public static class Entidade
        {
            public static GrupoDTO grupo1 = new GrupoDTO() { nome = "Grupo 1" };
            public static GrupoDTO grupo2 = new GrupoDTO() { nome = "Grupo 2" };
        }

        // banco
        public static void IniciarBanco()
        {
            var _conexao = new RepositorioBase();

            _conexao.Executar("DELETE Chamada");
            _conexao.Executar("DELETE TelefoneContato");
            _conexao.Executar("DELETE Contato");
            _conexao.Executar("DELETE Grupo");
        }
    }
}
