var app = angular.module('LibraryApp', ['ngRoute']);

app.controller('MainController', ['$scope', '$location', function ($scope, $location) {
    $scope.$location = $location;
}]);
    
app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/Books', {
            controller: 'HomeController',
            templateUrl: '/Templates/BookList.html'
        })
        .when('/AddBook', {
            controller: 'AddBookController',
            templateUrl: '/Templates/Add.html'
        })
       // .when('/YourBooks')
        .otherwise({
            redirectTo: '/'
        });

    //$locationProvider.html5Mode({
    //    enable: true,
    //    requireBase: false
    //});
}]);