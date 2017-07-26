function AgendaViewModel() {

    this.$app = null;

    this.linkAbertoNome = ko.observable();

    this.links = [
        {
            nome: 'Grupos',
            html: 'Grupo/ListarGrupo.html',
            vm: new ListarGrupoViewModel(this)
        },
        {
            nome: 'Contatos',
            html: 'Contato/ListarContato.html',
            vm: new ListarContatoViewModel(this)
        },
        {
            nome: 'Chamadas'
        }
    ];
    
    this.init = function ($app) {
        this.$app = $app;
    };

    this.navegar = function (link) {
        this.AbrirPagina(link);
    };

};

AgendaViewModel.prototype.AbrirPagina = function (link) {
    if (link.html && link.vm) {
        this.linkAbertoNome(link.nome);
        this.$app.ObterPagina(URL_SITE_PAGINAS + link.html, link.vm, 'agendaConteudo');
    }
};