app.controller('MainController', ['$scope', '$location', 'authService', 'dialogBox', function ($scope, $location, authService, dialogBox) {    

    $scope.authentication = authService.authentication;

    $scope.logout = function () {
        authService.logout();
        $location.path('/Books');
    };

    $scope.click = function () {
        dialogBox.show();
    }
    
}]);