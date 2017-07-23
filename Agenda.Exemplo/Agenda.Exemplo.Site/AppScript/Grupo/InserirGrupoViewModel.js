function InserirGrupoViewModel($parent) {

    this.$app = null;
    this.$parent = $parent;

    this.grupo = new Grupo();

    this.init = function ($app) {
        this.$app = $app;
    };

    this.salvar = function () {
        this.SalvarGrupo();
    };

};

InserirGrupoViewModel.prototype.SalvarGrupo = function () {

    var retorno = function (data) {
        this.$app.ExibirMensagemSucesso('Grupo criado');

        var link = {
            nome: 'Grupos',
            html: 'Grupo/ListarGrupo.html',
            vm: new ListarGrupoViewModel(this.$parent)
        };

        this.$parent.AbrirPagina(link);
    };

    this.$app.$api.$grupo.InserirGrupo(this.grupo.CriarDTO(), retorno, this);
};