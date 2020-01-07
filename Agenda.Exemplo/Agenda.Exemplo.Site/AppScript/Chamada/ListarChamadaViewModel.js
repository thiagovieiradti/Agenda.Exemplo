function ListarChamadaViewModel($parent) {

    this.$app = null;
    this.$parent = $parent;

    this.nome = ko.observable();

    this.chamadas = ko.observableArray();

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
    this.ObterChamadas();
};

ListarChamadaViewModel.prototype.ObterChamadas = function () {
    var retorno = function (data) {
        this.chamadas(data);
    };

    this.$app.$api.$chamada.ObterChamadas(this.chamadaId, retorno, this);
}

ListarChamadaViewModel.prototype.RemoverChamada = function (chamada) {
    var retorno = function () {
        this.$app.ExibirMensagemSucesso('Chamada excluida');
        this.ObterChamadas();
    }

    this.$app.$api.$chamada.RemoverChamada(chamada.chamadaId,chamada.nome, retorno, this);
};