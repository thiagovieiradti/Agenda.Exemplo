function GrupoAPI($app) {
    this.$app = $app;
};


GrupoAPI.prototype.ObterGrupos = function (nome, retorno, contexto) {
    var url = 'http://localhost:53546/grupos';
    if (nome) url += '?nome=' + nome;
    this.$app.Get(url, retorno, null, contexto);
};