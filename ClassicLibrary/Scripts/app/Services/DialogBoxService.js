app.factory('dialogBox', ['$modal', function ($modal) {
    function show(config) {
        var opts = {
            templateUrl: 'Templates/Dialogs/Info.html'
        };

        var modalInstance = $modal.open(opts);
        modalInstance.result.then(function () {
        });
    };

    var dialogBox = {};
    dialogBox.show = show;

    return dialogBox;
}]);