function ListarChamadaViewModel() {

    this.$app = null;
    this.$parent = $parent;

    this.init = function ($app) {
        this.$app = $app;
        this.Iniciar();
    };
};

ListarChamadaViewModel.prototype.Iniciar = function () {
    this.Chamada();
}