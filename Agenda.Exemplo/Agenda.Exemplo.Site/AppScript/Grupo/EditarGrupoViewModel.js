function EditarGrupoViewModel($parent, grupoId) {

    this.$app = null;

    this.$parent = $parent;

    this.grupoId = grupoId;
    this.grupo = new Grupo();

    this.init = function ($app) {
        this.$app = $app;
        this.ObterGrupo();
    };

    this.salvar = function () {
        this.EditarGrupo();
    };
};

EditarGrupoViewModel.prototype.ObterGrupo = function () {
    var retorno = function (data) {
        this.grupo.Preencher(data);
    };

    this.$app.$api.$grupo.ObterGrupo(this.grupoId, retorno, this);
};

EditarGrupoViewModel.prototype.EditarGrupo = function () {

    var retorno = function (data) {
        this.$app.ExibirMensagemSucesso('Grupo editado');

        var link = {
            nome: 'Grupos',
            html: 'Grupo/ListarGrupo.html',
            vm: new ListarGrupoViewModel(this.$parent)
        };

        this.$parent.AbrirPagina(link);
    };

    this.$app.$api.$grupo.EditarGrupo(this.grupo.CriarDTO(), retorno, this);
};