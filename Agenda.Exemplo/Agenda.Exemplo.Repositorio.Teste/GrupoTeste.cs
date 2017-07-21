using Agenda.Exemplo.Dominio.Entidade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Agenda.Exemplo.Repositorio.Teste
{
    [TestClass]
    public class GrupoTeste
    {
        private GrupoRepositorio _grupoRepositorio;

        [TestInitialize]
        public void Iniciar()
        {
            _grupoRepositorio = new GrupoRepositorio();
        }
        
        [TestMethod]
        public void TesteObterGrupo()
        {
            var grupo = _grupoRepositorio.ObterGrupo(1);

            Assert.IsNotNull(grupo);
            Assert.IsInstanceOfType(grupo, typeof(Grupo));
            Assert.IsNotNull(grupo.Id);
            Assert.IsNotNull(grupo.Nome);
        }

        [TestMethod]
        public void TesteObterGrupos()
        {
            var grupos = _grupoRepositorio.ObterGrupos("grupo");

            Assert.IsNotNull(grupos);
            Assert.IsTrue(grupos.Count > 0);
            Assert.IsTrue(grupos.All(g => g.Nome.ToLower().Contains("grupo")));
        }
    }
}
