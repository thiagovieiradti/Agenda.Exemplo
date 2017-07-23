(function () {
    var $vm = new AgendaViewModel();
    var $app = new Aplicacao($vm, 'agenda');
    $app.init();
})();