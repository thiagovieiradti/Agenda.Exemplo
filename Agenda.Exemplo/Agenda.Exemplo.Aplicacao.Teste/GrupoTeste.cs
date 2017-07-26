using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agenda.Exemplo.Dominio.Aplicacao;

namespace Agenda.Exemplo.Aplicacao.Teste
{
    [TestClass]
    public class GrupoTeste
    {
        private IGrupoAplicacao _grupoAplicacao;

        [TestInitialize]
        public void Iniciar()
        {
            Injetor.Injetor.IniciarContainer();
            _grupoAplicacao = Injetor.Injetor.ObterInstanciaDe<IGrupoAplicacao>();
            Util.IniciarBanco();
        }

        [TestCleanup]
        public void Finalizar()
        {
            Injetor.Injetor.FinalizarContainer();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TesteInserirGrupoSemNome()
        {
            var grupo = Util.Entidade.grupo1.Clonar();
            grupo.nome = "";
            _grupoAplicacao.InserirGrupo(grupo);
        }

        [TestMethod]
        public void TesteInserirGrupo()
        {
            var grupo = Util.Entidade.grupo1.Clonar();

            int grupoId = _grupoAplicacao.InserirGrupo(grupo);

            var grupoInserido = _grupoAplicacao.ObterGrupo(grupoId);

            Assert.AreEqual(grupoId, grupoInserido.grupoId);
            Assert.AreEqual(grupo.nome, grupoInserido.nome);
        }
    }
}
