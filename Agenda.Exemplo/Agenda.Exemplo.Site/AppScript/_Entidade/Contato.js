function Contato() {

    this.contatoId = ko.observable();
    this.nome = ko.observable();
    this.grupo = new Grupo();
    this.telefone = ko.observable();

    this.Preencher = function (dto) {
        this.contatoId(dto.contatoId);
        this.nome(dto.nome);
        this.grupo.Preencher(dto.grupo);
        this.telefone(dto.telefone);
    };

    this.CriarDTO = function () {
        return {
            contatoId: this.contatoId(),
            nome: this.nome(),
            grupo: this.grupo.CriarDTO(),
            telefone: this.telefone()
        };
    };

};