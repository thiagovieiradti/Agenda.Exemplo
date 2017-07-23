using Agenda.Exemplo.Dominio.DTO;

namespace Agenda.Exemplo.Aplicacao.Teste
{
    public static class Util
    {
        // extensão
        public static GrupoDTO Clonar(this GrupoDTO dto)
        {
            return new GrupoDTO()
            {
                id = dto.id,
                nome = dto.nome
            };
        }
        
        public static class Entidade
        {
            public static GrupoDTO grupo1 = new GrupoDTO() { nome = "Grupo 1" };
            public static GrupoDTO grupo2 = new GrupoDTO() { nome = "Grupo 2" };
        }
    }
}
