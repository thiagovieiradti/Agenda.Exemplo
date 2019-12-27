using Agenda.Exemplo.Aplicacao;
using Agenda.Exemplo.Dominio.Aplicacao;
using Agenda.Exemplo.Dominio.Repositorio;
using Agenda.Exemplo.Repositorio;
using Agenda.Exemplo.RepositorioMock;
using SimpleInjector;

namespace Agenda.Exemplo.Injetor
{
    public class Injetor
    {
        private static Container container = null;
        
        public static Container Container
        {
            get
            {
                if (container == null)
                    container = new Container();
                return container;
            }
        }
        
        public static void IniciarContainer()
        {
            Container.Register<IGrupoRepositorio, GrupoRepositorio>();
            Container.Register<IContatoRepositorio, ContatoRepositorio>();
            Container.Register<IChamadaRepositorio, ChamadaRepositorio>();

            RegistarCamadaAplicacao();
        }
        public static void IniciarContainerRepositorioMockado()
        {
            Container.Register<IGrupoRepositorio, GrupoRepositorioMock>();
            Container.Register<IContatoRepositorio, ContatoRepositorioMock>();

            RegistarCamadaAplicacao();
        }

        private static void RegistarCamadaAplicacao()
        {
            Container.Register<IGrupoAplicacao, GrupoAplicacao>();
            Container.Register<IContatoAplicacao, ContatoAplicacao>();
            Container.Register<IChamadaAplicacao, ChamadaAplicacao>();
        }

        public static void FinalizarContainer()
        {
            container.Dispose();
            container = null;
        }

        public static T ObterInstanciaDe<T>()
        {   
            return (T)Container.GetInstance(typeof(T));
        }

    }
}
