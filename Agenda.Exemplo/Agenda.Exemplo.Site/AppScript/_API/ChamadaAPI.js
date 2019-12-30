function ChamadaApi($app) {
    this.$app = $app;
};

ChamadaAPI.prototype.ObterContatos = function (chamadaId, retorno, contexto) {
    let url = URL_API + 'chamadas' + chamadaId;
    if (chamadaId) url += 'chamadaId' + chamadaId;
    this.$app.AjaxGet(url, retorno, null, contexto);
};

ChamadaAPI.prototype.InserirContato = function (chamada, retorno, contexto) {
    let url = URL_API + 'chamadas';
    this.$app.AjaxPost(url, chamada, retorno, null, contexto);
};

ChamadaApi.prototype.RemoverChamada = function (chamadaId, retorno, contexto) {
    let url = URL_API + 'chamada' + chamadaId;
    this.$app.AjaxDelete(url, retorno, null, contexto);
};

