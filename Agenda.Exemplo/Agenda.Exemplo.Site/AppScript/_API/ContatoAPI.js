function ContatoAPI($app) {
    this.$app = $app;
};

ContatoAPI.prototype.ObterContatos = function (grupoId, nome, retorno, contexto) {
    var url = URL_API + 'contatos?';
    if (grupoId) url += 'grupoId=' + grupoId + '&';
    if (nome) url += 'nome=' + nome + '&';
    this.$app.AjaxGet(url, retorno, null, contexto);
};

ContatoAPI.prototype.InserirContato = function (contato, retorno, contexto) {
    var url = URL_API + 'contatos';
    this.$app.AjaxPost(url, contato, retorno, null, contexto);
};