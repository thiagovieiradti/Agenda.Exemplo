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

Aplicacao.prototype.ObterPagina = function (url, vm, elementoId) {

    var retorno = function (html) {
        var elemento = document.getElementById(elementoId);

        elemento.innerHTML = '';
        ko.cleanNode(elemento);

        elemento.innerHTML = html;
        ko.applyBindings(vm, elemento);
        vm.init(this);
    };

    this.AjaxGet(url, retorno, null, this);

};

Aplicacao.prototype.ExibirMensagemSucesso = function (texto) {
    alert(texto);
};

Aplicacao.prototype.ExibirCarregando = function () {
    //TO-DO
};

Aplicacao.prototype.OcultarCarregando = function () {
    //TO-DO
};

Aplicacao.prototype.ExibirErro = function (method, url, err) {
    var msg = err.responseJSON.ExceptionMessage;

    if (msg) {
        alert(msg);
    }
};

Aplicacao.prototype.AjaxGet = function (url, success, error, context, loading) {

    loading && this.$app.ExibirCarregando();

    $.ajax({
        method: 'GET',
        url: url,
        contentType: 'application/json',
        context: this,
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
                this.ExibirErro('get', url, err);
        }
    });

};

Aplicacao.prototype.AjaxPost = function (url, object, success, error, context, loading) {

    loading && this.$app.ExibirCarregando();

    $.ajax({
        method: 'POST',
        url: url,
        contentType: 'application/json',
        context: this,
        data: JSON.stringify(object),
        success: function (data) {
            loading && this.$app.OcultarCarregando();
            success && success.call(context, data);
        },
        error: function (err) {
            console.log('post-err: ' + url);
            console.log(err);
            loading && this.$app.OcultarCarregando();
            if (error)
                error.call(context, err);
            else
                this.ExibirErro('post', url, err);
        }
    });
};

Aplicacao.prototype.AjaxPut = function (url, object, success, error, context, loading) {

    loading && this.$app.ExibirCarregando();

    $.ajax({
        method: 'PUT',
        url: url,
        contentType: 'application/json',
        context: this,
        data: JSON.stringify(object),
        success: function (data) {
            loading && this.$app.OcultarCarregando();
            success && success.call(context, data);
        },
        error: function (err) {
            console.log('put-err: ' + url);
            console.log(err);
            loading && this.$app.OcultarCarregando();
            if (error)
                error.call(context, err);
            else
                this.ExibirErro('put', url, err);
        }
    });
};

Aplicacao.prototype.AjaxDelete = function (url, success, error, context, loading) {

    loading && this.$app.ExibirCarregando();

    $.ajax({
        type: 'DELETE',
        url: url,
        contentType: 'application/json',
        context: this,
        success: function (data) {
            loading && this.$app.OcultarCarregando();
            success && success.call(context, data);
        },
        error: function (err) {
            console.log('del-err: ' + url);
            console.log(err);
            loading && this.$app.OcultarCarregando();
            if (error)
                error.call(context, err);
            else
                this.ExibirErro('delete', url, err);
        }
    });
};