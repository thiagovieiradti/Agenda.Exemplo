using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agenda.Exemplo.Dominio.Entidade;

namespace Agenda.Exemplo.Repositorio.Teste
{
    [TestClass]
    public class ContatoTeste
    {

        private GrupoRepositorio _grupoRepositorio;
        private ContatoRepositorio _contatoRepositorio;

        [TestInitialize]
        public void Iniciar()
        {
            Util.IniciarBanco();
            _grupoRepositorio = new GrupoRepositorio();
            _contatoRepositorio = new ContatoRepositorio();
        }

        [TestMethod]
        public void TesteInserirContato()
        {
            var grupo = Util.Entidade.grupo1.Clonar();
            var contato = new Contato()
            {
                Nome = "João da Silva",
                Grupo = grupo
            };

            grupo.GrupoId = _grupoRepositorio.InserirGrupo(grupo);
            contato.ContatoId = _contatoRepositorio.InserirContato(contato);
            var contato2 = _contatoRepositorio.ObterContato(contato.ContatoId);

            Assert.IsNotNull(contato2);
            Assert.IsNotNull(contato2.Grupo);

            Assert.AreEqual(contato.ContatoId, contato2.ContatoId);
            Assert.AreEqual(contato.Nome, contato2.Nome);
            Assert.AreEqual(contato.Grupo.GrupoId, contato2.Grupo.GrupoId);
            Assert.AreEqual(contato.Grupo.Nome, contato2.Grupo.Nome);
            
        }
    }
}
