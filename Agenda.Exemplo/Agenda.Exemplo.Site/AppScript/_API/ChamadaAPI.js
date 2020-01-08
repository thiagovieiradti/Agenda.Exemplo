function ChamadaAPI($app) {
    this.$app = $app;
};

ChamadaAPI.prototype.ObterChamadas = function (grupoId, nome, retorno, contexto) {
    let url = URL_API + 'chamadas?';
    if (grupoId) url += 'grupoId=' + grupoId + '&';
    if (nome) url += 'nome=' + nome + '&';
    this.$app.AjaxGet(url, retorno, null, contexto);
};

ChamadaAPI.prototype.InserirChamada = function (chamada, retorno, contexto) {
    let url = URL_API + 'chamadas';
    this.$app.AjaxPost(url, chamada, retorno, null, contexto);
};

ChamadaAPI.prototype.RemoverChamada = function (chamadaId, retorno, contexto) {
    let url = URL_API + 'chamadas/' + chamadaId;
    this.$app.AjaxDelete(url, retorno, null, contexto);
};

