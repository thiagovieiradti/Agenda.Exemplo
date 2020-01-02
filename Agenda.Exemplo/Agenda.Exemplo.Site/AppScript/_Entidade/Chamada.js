function Chamada() {
    this.CriarDtO = function () {
        return {
            chamadaId: this.chamadaId,
            contato: this.contato.CriarDtO,
        }
    };
}