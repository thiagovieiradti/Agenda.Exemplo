function ListarChamadaViewModel($parent) {

    this.$app = null;
    this.$parent = $parent;

    this.nome = ko.observable();
    this.grupoId = ko.observable();
    this.data = ko.observable();

    this.chamadas = ko.observableArray();
    this.grupos = ko.observableArray();

    this.init = function ($app) {
        this.$app = $app;
        this.Iniciar();
    };

    this.remover = function (chamada) {
        this.RemoverChamada(chamada);
    };

    this.filtrar = function () {
        this.ObterChamadas();
    }
};

ListarChamadaViewModel.prototype.Iniciar = function () {
    this.ObterGrupos();
    this.ObterChamadas();
};

ListarChamadaViewModel.prototype.ObterGrupos = function () {
    var retorno = function (data) {
        this.grupos(data);
    };

    this.$app.$api.$grupo.ObterGrupos(null, retorno, this);
};

ListarChamadaViewModel.prototype.ObterChamadas = function () {
    var retorno = function (data) {
        this.chamadas(data);
    };

    this.$app.$api.$chamada.ObterChamadas(this.grupoId(), this.nome(),this.data(), retorno, this);
}

ListarChamadaViewModel.prototype.RemoverChamada = function (chamada) {
    var retorno = function () {
        this.$app.ExibirMensagemSucesso('Chamada excluida');
        this.ObterChamadas();
    }

    this.$app.$api.$chamada.RemoverChamada(chamada.chamadaId, retorno, this);
};

