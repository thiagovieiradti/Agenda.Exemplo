function ListaGrupoViewModel() {

    this.$app = null;

    this.grupos = ko.observableArray();

    this.init = function ($app) {
        this.$app = $app;
        this.Iniciar();
    };

};

ListaGrupoViewModel.prototype.Iniciar = function () {
    this.ObterGrupos();
};

ListaGrupoViewModel.prototype.ObterGrupos = function () {

    var retorno = function (data) {
        this.grupos(data);
    };

    this.$app.$api.$grupo.ObterGrupos('', retorno, this);
};

