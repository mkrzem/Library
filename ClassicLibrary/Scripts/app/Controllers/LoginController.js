(function () {
    angular.module('LibraryApp')
           .controller('LoginController', ['$scope', '$location', 'authService', LoginController])
    
    function LoginController($scope, $location, authService) {
        $scope.submitted = false;
        $scope.message = "";
        $scope.loginData = {
            userName: '',
            password: ''
        };

        $scope.login = function (loginForm) {
            if (loginForm.$valid) {
                var result = authService.login($scope.loginData);

                result.then(function (response) {
                    $location.path('/Books');
                }, function (error) {
                    $scope.message = 'Invalid login attempt.';
                    console.error(error);
                });
            } else {
                $scope.submitted = true;
            }
        };
    }
})();