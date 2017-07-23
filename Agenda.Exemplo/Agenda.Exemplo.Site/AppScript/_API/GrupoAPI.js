function GrupoAPI($app) {
    this.$app = $app;
};

GrupoAPI.prototype.ObterGrupo = function (grupoId, retorno, contexto) {
    var url = URL_API + 'grupos/' + grupoId;
    this.$app.AjaxGet(url, retorno, null, contexto);
};

GrupoAPI.prototype.ObterGrupos = function (nome, retorno, contexto) {
    var url = URL_API + 'grupos';
    if (nome) url += '?nome=' + nome;
    this.$app.AjaxGet(url, retorno, null, contexto);
};

GrupoAPI.prototype.InserirGrupo = function (grupo, retorno, contexto) {
    var url = URL_API + 'grupos';
    this.$app.AjaxPost(url, grupo, retorno, null, contexto);
};

GrupoAPI.prototype.EditarGrupo = function (grupo, retorno, contexto) {
    var url = URL_API + 'grupos';
    this.$app.AjaxPut(url, grupo, retorno, null, contexto);
};

GrupoAPI.prototype.RemoverGrupo = function (grupoId, retorno, contexto) {
    var url = URL_API + 'grupos/' + grupoId;
    this.$app.AjaxDelete(url, retorno, null, contexto);
};