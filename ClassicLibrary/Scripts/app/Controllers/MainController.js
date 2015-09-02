app.controller('MainController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {    

    $scope.authentication = authService.authentication;

    $scope.logout = function () {
        authService.logout();
        $location.path('/Books');
    };

    
}]);