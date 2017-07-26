using Agenda.Exemplo.Dominio.Entidade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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

        [TestMethod]
        public void TesteObterContatosSemParametros()
        {
            var grupo = Util.Entidade.grupo1.Clonar();
            var contato = new Contato()
            {
                Nome = "João da Silva",
                Grupo = grupo
            };

            var contato2 = new Contato()
            {
                Nome = "Maria",
                Grupo = grupo
            };

            grupo.GrupoId = _grupoRepositorio.InserirGrupo(grupo);
            contato.ContatoId = _contatoRepositorio.InserirContato(contato);
            contato2.ContatoId = _contatoRepositorio.InserirContato(contato2);
            var contatos = _contatoRepositorio.ObterContatos(null, null);

            Assert.IsNotNull(contatos);
            Assert.IsTrue(contatos.Any(c => c.ContatoId == contato.ContatoId));
            Assert.IsTrue(contatos.Any(c => c.ContatoId == contato2.ContatoId));
        }

        [TestMethod]
        public void TesteObterContatosComGrupo()
        {
            var grupo = Util.Entidade.grupo1.Clonar();
            var contato = new Contato()
            {
                Nome = "João da Silva",
                Grupo = grupo
            };

            var contato2 = new Contato()
            {
                Nome = "Maria",
                Grupo = grupo
            };

            grupo.GrupoId = _grupoRepositorio.InserirGrupo(grupo);
            contato.ContatoId = _contatoRepositorio.InserirContato(contato);
            contato2.ContatoId = _contatoRepositorio.InserirContato(contato2);
            var contatos = _contatoRepositorio.ObterContatos(grupo.GrupoId, null);

            Assert.IsNotNull(contatos);
            Assert.IsTrue(contatos.Any(c => c.ContatoId == contato.ContatoId));
            Assert.IsTrue(contatos.Any(c => c.ContatoId == contato2.ContatoId));
        }

        [TestMethod]
        public void TesteObterContatosComNome()
        {
            var grupo = Util.Entidade.grupo1.Clonar();
            var contato = new Contato()
            {
                Nome = "João da Silva",
                Grupo = grupo
            };

            var contato2 = new Contato()
            {
                Nome = "Maria",
                Grupo = grupo
            };
            
            grupo.GrupoId = _grupoRepositorio.InserirGrupo(grupo);
            contato.ContatoId = _contatoRepositorio.InserirContato(contato);
            contato2.ContatoId = _contatoRepositorio.InserirContato(contato2);
            var contatos = _contatoRepositorio.ObterContatos(null, contato.Nome);

            Assert.IsNotNull(contatos);
            Assert.IsTrue(contatos.Any(c => c.ContatoId == contato.ContatoId));
            Assert.IsFalse(contatos.Any(c => c.ContatoId == contato2.ContatoId));
        }

        [TestMethod]
        public void TesteObterContatosComNomeEGrupo()
        {
            var grupo = Util.Entidade.grupo1.Clonar();
            var contato = new Contato()
            {
                Nome = "João da Silva",
                Grupo = grupo
            };

            var contato2 = new Contato()
            {
                Nome = "Maria",
                Grupo = grupo
            };

            grupo.GrupoId = _grupoRepositorio.InserirGrupo(grupo);
            contato.ContatoId = _contatoRepositorio.InserirContato(contato);
            contato2.ContatoId = _contatoRepositorio.InserirContato(contato2);
            var contatos = _contatoRepositorio.ObterContatos(grupo.GrupoId, contato.Nome);

            Assert.IsNotNull(contatos);
            Assert.IsTrue(contatos.Any(c => c.ContatoId == contato.ContatoId));
            Assert.IsFalse(contatos.Any(c => c.ContatoId == contato2.ContatoId));
        }

        [TestMethod]
        public void TesteEditarContato()
        {
            var grupo = Util.Entidade.grupo1.Clonar();
            var contato = new Contato()
            {
                Nome = "Arthur",
                Grupo = grupo
            };

            grupo.GrupoId =  _grupoRepositorio.InserirGrupo(grupo);
            contato.ContatoId = _contatoRepositorio.InserirContato(contato);

            var contato2 = _contatoRepositorio.ObterContato(contato.ContatoId);

            Assert.IsNotNull(contato2);
            Assert.AreEqual(contato.Nome, contato2.Nome);

            contato2.Nome = "Julia";

            _contatoRepositorio.EditarContato(contato2);

            var contato3 = _contatoRepositorio.ObterContato(contato2.ContatoId);

            Assert.AreNotEqual(contato.Nome, contato3.Nome);
            Assert.AreEqual(contato2.Nome, contato3.Nome);

        }

    }
}
