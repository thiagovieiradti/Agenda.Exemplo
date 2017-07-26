function InserirContatoViewModel($parent) {

    this.$app = null;
    this.$parent = $parent;

    this.contato = new Contato();

    this.grupos = ko.observableArray();

    this.init = function ($app) {
        this.$app = $app;
        this.Iniciar();
    };

    this.salvar = function () {
        this.SalvarContato();
    };

};

InserirContatoViewModel.prototype.Iniciar = function () {
    this.ObterGrupos();
};

InserirContatoViewModel.prototype.ObterGrupos = function () {
    var retorno = function (data) {
        this.grupos(data);
    };

    this.$app.$api.$grupo.ObterGrupos(null, retorno, this);
};

InserirContatoViewModel.prototype.SalvarContato = function () {

    var retorno = function (data) {
        this.$app.ExibirMensagemSucesso('Contato criado');

        var link = {
            nome: 'Contatos',
            html: 'Contato/ListarContato.html',
            vm: new ListarContatoViewModel(this.$parent)
        };

        this.$parent.AbrirPagina(link);
    };

    this.$app.$api.$contato.InserirContato(this.contato.CriarDTO(), retorno, this);
};