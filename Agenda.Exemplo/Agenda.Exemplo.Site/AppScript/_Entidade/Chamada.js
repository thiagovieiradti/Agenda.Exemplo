function Chamada() {

    this.chamadaId = ko.observable();

    this.CriarDTO = function (contato) {

        return {
            chamadaId: this.chamadaId,
            contato: contato.CriarDTO(),
        }
    };

    this.FormatData = function (data) {
        let dataFormatada = "";
        if (data) {
            let dia = data[8] + data[9];
            let mes = data[5] + data[6];
            let ano = data[0] + data[1] + data[2] + data[3];
            dataFormatada = dia + "/" + mes + "/" + ano;
        }
        return dataFormatada;
    }
}