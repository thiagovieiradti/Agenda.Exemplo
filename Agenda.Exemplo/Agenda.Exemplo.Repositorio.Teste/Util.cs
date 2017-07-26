using Agenda.Exemplo.Dominio.Entidade;
using Agenda.Exemplo.Repositorio.Base;

namespace Agenda.Exemplo.Repositorio.Teste
{
    public static class Util
    {
        // extensão
        public static Grupo Clonar(this Grupo grupo)
        {
            return new Grupo()
            {
                GrupoId = grupo.GrupoId,
                Nome = grupo.Nome
            };
        }
        
        // entidades
        public static class Entidade
        {
            public static Grupo grupo1 = new Grupo() { Nome = "Grupo 1" };
            public static Grupo grupo2 = new Grupo() { Nome = "Grupo 2" };
            public static Grupo grupo3 = new Grupo() { Nome = "Teste" };
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
