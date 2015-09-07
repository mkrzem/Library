app.controller('MainController', ['$scope', '$location', 'authService', 'dialogBox', '$modal', function ($scope, $location, authService, dialogBox, $modal) {    

    $scope.authentication = authService.authentication;

    $scope.logout = function () {
        authService.logout();
        $location.path('/Books');
    };

    $scope.click = function () {
        config = {
            //controller: function (message, title, input) {
            //    this.message = message;
            //    this.title = title;
            //}
            input: {
                message: "Testing message input",
                title: "Testin Header"
            },
            error: false
        }
        dialogBox.show(config);
    }
    
}]);