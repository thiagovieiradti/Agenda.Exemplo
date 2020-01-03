function Chamada() {

    this.chamadaId = ko.observable();

    this.CriarDTO = function (contato) {

        return {
            chamadaId: this.chamadaId,
            contato: contato.CriarDTO(),
        }
    };
}