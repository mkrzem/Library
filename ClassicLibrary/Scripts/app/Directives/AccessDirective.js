app.directive("lockAccess", function () {
    return {
        restrict: 'A',
        scope: {
            lockAccess: '@',
        },
        controller: ['$scope', 'authService', '$attrs', function ($scope, authService, $attrs) {
            authService.fillAuthData();
            if (this.lockAccess === "NoAuth") {
                $scope.visibleNotAuthorized = true;
            } else {
                $scope.lockAccess = this.lockAccess;
            }

            $scope.$watch(function () {
                return authService.authentication.isAuth;
            }, function () {
                var visible = false;
                if (authService.authentication.isAuth) {
                    visible = true;
                    if ($scope.lockAccess && !authService.isInRole($scope.lockAccess)) {
                        visible = false;
                    }
                }
                
                if ($scope.visibleNotAuthorized) {
                    visible = !visible;
                }

                if (visible)
                    $attrs.$removeClass('hidden');
                else
                    $attrs.$addClass('hidden');
            });
        }],
        controllerAs: 'ctrl',
        bindToController: true        
    };
});