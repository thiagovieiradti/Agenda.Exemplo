function Contato() {

    this.contatoId = ko.observable();
    this.nome = ko.observable();
    this.grupo = new Grupo();

    this.Preencher = function (dto) {
        this.contatoId(dto.contatoId);
        this.nome(dto.nome);
        this.grupo.Preencher(dto.grupo);
    };

    this.CriarDTO = function () {
        return {
            contatoId: this.contatoId(),
            nome: this.nome(),
            grupo: this.grupo.CriarDTO()
        };
    };

};