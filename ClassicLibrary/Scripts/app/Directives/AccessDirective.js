//app.directive('accessType', function () {
//    return {
//        controller: function ($scope) { }
//    };
//});

app.directive("access", function () {
    return {
        restrict: 'A',
        scope: {
            accessType: '@',
        },
        controller: ['$scope', 'authService', '$attrs', function ($scope, authService, $attrs) {
            $scope.accessType = this.accessType;

            $scope.$watch(function () {
                return authService.authentication.isAuth;
            }, function () {
                var visible = false;
                if (authService.authentication.isAuth) {
                    visible = true;
                    if ($scope.accessType && !authService.isInRole($scope.accessType)) {
                        visible = false;
                    }
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