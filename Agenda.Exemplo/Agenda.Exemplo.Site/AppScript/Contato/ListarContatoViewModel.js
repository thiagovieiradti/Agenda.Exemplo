﻿function ListarContatoViewModel($parent) {

    this.$app = null;
    this.$parent = $parent;

    this.grupos = ko.observableArray();
    this.contatos = ko.observableArray();

    this.grupoId = ko.observable();
    this.nome = ko.observable();

    this.chamada = new Chamada();

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

ListarContatoViewModel.prototype.InserirChamada = function (contato) {
    var retorno = function () {
        this.$app.ExibirMensagemSucesso('Chamada realizada');
    };

    this.$app.$api.$chamada.InserirChamada(this.chamada.CriarDTO(contato), retorno, this)
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
    this.contatos.removeAll();
    var retorno = function (data) {
        for (var i = 0; i < data.length; i++) {
            var contato = new Contato();
            contato.Preencher(data[i]);
            this.contatos.push(contato);
        }
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