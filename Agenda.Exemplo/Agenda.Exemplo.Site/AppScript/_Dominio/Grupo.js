function Grupo() {

    this.grupoId = ko.observable();
    this.nome = ko.observable();

    this.Preencher = function (dto) {
        this.grupoId(dto.grupoId);
        this.nome(dto.nome);
    };

    this.CriarDTO = function () {
        return {
            grupoId: this.grupoId(),
            nome: this.nome()
        };
    };

};