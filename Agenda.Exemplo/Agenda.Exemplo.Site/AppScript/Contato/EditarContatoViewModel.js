function EditarContatoViewModel($parent, contatoId) {

    this.$app = null;

    this.$parent = $parent;

    this.grupos = ko.observableArray();

    this.contatoId = contatoId;
    this.contato = new Contato();

    this.init = function ($app) {
        this.$app = $app;
        this.ObterContato();
        this.ObterGrupos();
    };

    this.salvar = function () {
        this.EditarContato();
    };
};

EditarContatoViewModel.prototype.ObterContato = function () {
    var retorno = function (data) {
        this.contato.Preencher(data);
    };

    this.$app.$api.$contato.ObterContato(this.contatoId, retorno, this);
};

EditarContatoViewModel.prototype.ObterGrupos = function () {
    var retorno = function (data) {
        this.grupos(data);
    };

    this.$app.$api.$grupo.ObterGrupos(null, retorno, this);
};

EditarContatoViewModel.prototype.EditarContato = function () {

    var retorno = function (data) {
        this.$app.ExibirMensagemSucesso('Contato editado');

        var link = {
            nome: 'Contatos',
            html: 'Contato/ListarContato.html',
            vm: new ListarContatoViewModel(this.$parent)
        };

        this.$parent.AbrirPagina(link);
    };

    this.$app.$api.$contato.EditarContato(this.contato.CriarDTO(), retorno, this);
};