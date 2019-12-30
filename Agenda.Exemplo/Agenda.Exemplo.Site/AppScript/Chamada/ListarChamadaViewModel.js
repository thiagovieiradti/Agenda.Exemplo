function ListarChamadaViewModel($parent) {

    this.$app = null;
    this.$parent = $parent;

    this.init = function ($app) {
        this.$app = $app;
        this.Iniciar();
    };


    this.remover = function () {
        this.RemoverChamada();
    };

};

ListarChamadaViewModel.prototype.Iniciar = function () {
    // ??
}