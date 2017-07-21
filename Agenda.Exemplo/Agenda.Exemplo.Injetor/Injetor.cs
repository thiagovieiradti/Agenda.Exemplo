using Agenda.Exemplo.Aplicacao;
using Agenda.Exemplo.Dominio.Aplicacao;
using Agenda.Exemplo.Dominio.Repositorio;
using Agenda.Exemplo.Repositorio;
using SimpleInjector;

namespace Agenda.Exemplo.Injetor
{
    public class Injetor
    {
        private static Container container = new Container();

        public static Container Container
        {
            get
            {
                return container;
            }
        }
        
        public static void IniciarContainer()
        {
            container.Register<IGrupoRepositorio, GrupoRepositorio>();

            container.Register<IGrupoAplicacao, GrupoAplicacao>();
        }

        public static T ObterInstanciaDe<T>()
        {
            return (T)container.GetInstance(typeof(T));
        }

    }
}
