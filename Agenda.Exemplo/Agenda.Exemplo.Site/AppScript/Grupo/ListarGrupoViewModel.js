function ListarGrupoViewModel($parent) {

    this.$app = null;
    this.$parent = $parent;

    this.grupos = ko.observableArray();

    this.filtro = ko.observable();

    this.init = function ($app) {
        this.$app = $app;
        this.Iniciar();
    };

    this.filtrar = function () {
        this.ObterGrupos();
    };

    this.inserir = function () {
        this.AbrirPaginaInserir();
    };

    this.remover = function (grupo) {
        this.RemoverGrupo(grupo);
    };

    this.editar = function (grupo) {
        this.AbrirPaginaEditar(grupo);
    };

};

ListarGrupoViewModel.prototype.Iniciar = function () {
    this.ObterGrupos();
};

ListarGrupoViewModel.prototype.ObterGrupos = function () {

    var retorno = function (data) {
        this.grupos(data);
    };

    this.$app.$api.$grupo.ObterGrupos(this.filtro(), retorno, this);
};

ListarGrupoViewModel.prototype.AbrirPaginaInserir = function () {
    var link = {
        nome: 'Grupos',
        html: 'Grupo/Grupo.html',
        vm: new InserirGrupoViewModel(this.$parent)
    };

    this.$parent.AbrirPagina(link);
};

ListarGrupoViewModel.prototype.RemoverGrupo = function (grupo) {

    var retorno = function () {
        this.$app.ExibirMensagemSucesso('Grupo excluído');
        this.ObterGrupos();
    };

    this.$app.$api.$grupo.RemoverGrupo(grupo.grupoId, retorno, this);
};

ListarGrupoViewModel.prototype.AbrirPaginaEditar = function (grupo) {
    var link = {
        nome: 'Grupos',
        html: 'Grupo/Grupo.html',
        vm: new EditarGrupoViewModel(this.$parent, grupo.grupoId)
    };

    this.$parent.AbrirPagina(link);
};