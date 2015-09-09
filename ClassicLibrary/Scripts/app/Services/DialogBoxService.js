(function (){
    angular.module('LibraryApp')
           .factory('dialogBox', ['$modal', DialogBox])
    
    function DialogBox($modal) {
        var dialogBox = {};
        ///Config - configuration of modal window display
        function show(config) {        
            var options = {
                templateUrl: 'Templates/Dialogs/Info.html',
                controller: ['$scope', 'config', function ($scope, config) {
                    var config = config;
                    if (config.input) {
                        for (var inputName in config.input) {
                            $scope[inputName] = config.input[inputName];
                        }
                    };

                    $scope.getType = function () {
                        if (config.error) {
                            return 'alert-danger';
                        } else {
                            return 'alert-success';
                        }
                    }

                    $scope.getIcon = function () {
                        if (config.error) {
                            return 'glyphicon-warning-sign';
                        } else {
                            return 'glyphicon-ok';
                        }
                    }
                }],
                animation: false,
                resolve: {
                    config: function () { return config }
                }
            };        

            var modalInstance = $modal.open(options);
            modalInstance.result.then(function () {
            });
        };
        
        dialogBox.show = show;
        return dialogBox;
    };
})();