function ListarContatoViewModel($parent) {

    this.$app = null;
    this.$parent = $parent;

    this.grupos = ko.observableArray();
    this.contatos = ko.observableArray();

    this.grupoId = ko.observable();
    this.nome = ko.observable();

    this.init = function ($app) {
        this.$app = $app;
        this.Iniciar();
    };

    this.filtrar = function () {
        this.ObterContatos();
    };

    this.inserir = function () {
        this.AbrirPaginaInserir();
    };

    this.remover = function (contato) {
        this.RemoverContato(contato);
    };

    this.editar = function (contato) {
        this.AbrirPaginaEditar(contato);
    };

    this.chamar = function (contato) {
        this.InserirChamada(contato);
    };

};

ListarContatoViewModel.prototype.InserirChamada = function () {
    this.$app.$api.$chamada.InserirChamada(this.chamada.CriarDTO(),retorno,this)
};

ListarContatoViewModel.prototype.Iniciar = function () {
    this.ObterGrupos();
    this.ObterContatos();
};

ListarContatoViewModel.prototype.ObterGrupos = function () {
    var retorno = function (data) {
        this.grupos(data);
    };

    this.$app.$api.$grupo.ObterGrupos(null, retorno, this);
};

ListarContatoViewModel.prototype.ObterContatos = function () {

    var retorno = function (data) {
        this.contatos(data);
    };

    this.$app.$api.$contato.ObterContatos(this.grupoId(), this.nome(), retorno, this);
};

ListarContatoViewModel.prototype.AbrirPaginaInserir = function () {
    var link = {
        nome: 'Contatos',
        html: 'Contato/Contato.html',
        vm: new InserirContatoViewModel(this.$parent)
    };

    this.$parent.AbrirPagina(link);
};

ListarContatoViewModel.prototype.AbrirPaginaEditar = function (contato) {
    var link = {
        nome: 'Contatos',
        html: 'Contato/Contato.html',
        vm: new EditarContatoViewModel(this.$parent, contato.contatoId)
    };

    this.$parent.AbrirPagina(link);
};

ListarContatoViewModel.prototype.RemoverContato = function (contato) {

    var retorno = function () {
        this.$app.ExibirMensagemSucesso('Contato excluído');
        this.ObterContatos();
    };

    this.$app.$api.$contato.RemoverContato(contato.contatoId, retorno, this);
};