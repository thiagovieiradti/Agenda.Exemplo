function Grupo() {

    this.id = ko.observable();
    this.nome = ko.observable();

    this.Preencher = function (dto) {
        this.id(dto.id);
        this.nome(dto.nome);
    };

    this.CriarDTO = function () {
        return new {
            id: this.id(),
            nome: this.nome()
        };
    };

};