function Aplicacao($vm, elementoId) {

    this.$vm = $vm;
    this.elementoId = elementoId;

    this.$api = {
        $grupo: new GrupoAPI(this)
    };

    this.init = function () {
        ko.applyBindings(this.$vm, document.getElementById(this.elementoId));
        this.$vm.init(this);
    };

};

Aplicacao.prototype.ExibirCarregando = function () {
    //TO-DO
};

Aplicacao.prototype.OcultarCarregando = function () {
    //TO-DO
};

Aplicacao.prototype.ExibirErro = function () {
    //TO-DO
};

Aplicacao.prototype.Get = function (url, success, error, context, loading) {

    loading && this.$app.ExibirCarregando();

    $.ajax({
        method: 'GET',
        url: url,
        contentType: 'application/json',
        context: context,
        success: function (data) {
            loading && this.$app.OcultarCarregando();
            success && success.call(context, data);
        },
        error: function (err) {
            console.log('get-err: ' + url);
            console.log(err);
            loading && this.$app.OcultarCarregando();
            if (error)
                error.call(context, err);
            else
                this.$app.ExibirErro('get', url, err);
        }
    });

};