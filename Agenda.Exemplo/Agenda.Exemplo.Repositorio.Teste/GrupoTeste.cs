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
            Util.IniciarBanco();
            _grupoRepositorio = new GrupoRepositorio();
        }
        
        [TestMethod]
        public void TesteInserirGrupo()
        {
            var grupo = Util.Entidade.grupo1.Clonar();

            int grupoId = _grupoRepositorio.InserirGrupo(grupo);

            Assert.IsTrue(grupoId > 0);

            var novoGrupo = _grupoRepositorio.ObterGrupo(grupoId);

            Assert.IsNotNull(novoGrupo);
            Assert.AreEqual(grupoId, novoGrupo.Id);
            Assert.AreEqual(grupo.Nome, novoGrupo.Nome);
        }

        [TestMethod]
        public void TesteEditarGrupo()
        {
            var grupo = Util.Entidade.grupo2.Clonar();
            int grupoId = _grupoRepositorio.InserirGrupo(grupo);
            grupo.Id = grupoId;

            Assert.IsTrue(grupoId > 0);

            grupo.Nome = "Novo Nome";

            _grupoRepositorio.EditarGrupo(grupo);

            var novoGrupo = _grupoRepositorio.ObterGrupo(grupoId);

            Assert.IsNotNull(novoGrupo);
            Assert.AreEqual(grupoId, novoGrupo.Id);
            Assert.AreEqual(grupo.Nome, novoGrupo.Nome);
            Assert.AreNotEqual(Util.Entidade.grupo2.Nome, novoGrupo.Nome);
        }

        [TestMethod]
        public void TesteExcluirGrupo()
        {
            var grupo = Util.Entidade.grupo3.Clonar();

            int grupoId = _grupoRepositorio.InserirGrupo(grupo);
            Assert.IsTrue(grupoId > 0);

            _grupoRepositorio.RemoverGrupo(grupoId);

            var novoGrupo = _grupoRepositorio.ObterGrupo(grupoId);

            Assert.IsNull(novoGrupo);
        }

        [TestMethod]
        public void TesteObterGruposSemFiltro()
        {
            Util.IniciarBanco();

            _grupoRepositorio.InserirGrupo(Util.Entidade.grupo1);
            _grupoRepositorio.InserirGrupo(Util.Entidade.grupo2);
            _grupoRepositorio.InserirGrupo(Util.Entidade.grupo3);

            var grupos = _grupoRepositorio.ObterGrupos("");

            Assert.IsNotNull(grupos);
            Assert.AreEqual(3, grupos.Count);
            Assert.IsTrue(grupos.Any((g => g.Nome == Util.Entidade.grupo1.Nome)));
            Assert.IsTrue(grupos.Any((g => g.Nome == Util.Entidade.grupo2.Nome)));
            Assert.IsTrue(grupos.Any((g => g.Nome == Util.Entidade.grupo3.Nome)));
        }

        [TestMethod]
        public void TesteObterGruposComFiltro()
        {
            Util.IniciarBanco();

            _grupoRepositorio.InserirGrupo(Util.Entidade.grupo1);
            _grupoRepositorio.InserirGrupo(Util.Entidade.grupo2);
            _grupoRepositorio.InserirGrupo(Util.Entidade.grupo3);

            var grupos = _grupoRepositorio.ObterGrupos(Util.Entidade.grupo1.Nome);

            Assert.IsNotNull(grupos);
            Assert.AreEqual(1, grupos.Count);
            Assert.IsTrue(grupos.Any((g => g.Nome == Util.Entidade.grupo1.Nome)));
            Assert.IsFalse(grupos.Any((g => g.Nome == Util.Entidade.grupo2.Nome)));
            Assert.IsFalse(grupos.Any((g => g.Nome == Util.Entidade.grupo3.Nome)));
        }

    }
}
