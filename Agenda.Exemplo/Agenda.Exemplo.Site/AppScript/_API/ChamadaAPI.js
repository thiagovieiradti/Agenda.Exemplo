function ChamadaAPI($app) {
    this.$app = $app;
};

ChamadaAPI.prototype.ObterChamadas = function (chamadaId, retorno, contexto) {
    let url = URL_API + 'chamadas';
    if (chamadaId) url += 'chamadaId' + chamadaId;
    this.$app.AjaxGet(url, retorno, null, contexto);
};

ChamadaAPI.prototype.InserirChamada = function (chamada, retorno, contexto) {
    let url = URL_API + 'chamadas';
    this.$app.AjaxPost(url, chamada, retorno, null, contexto);
};

ChamadaAPI.prototype.RemoverChamada = function (chamadaId, retorno, contexto) {
    let url = URL_API + 'chamada/' + chamadaId;
    this.$app.AjaxDelete(url, retorno, null, contexto);
};

