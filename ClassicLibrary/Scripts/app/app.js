﻿angular.module('LibraryApp', ['ngRoute', 'ngResource', 'ui.bootstrap']);
    
angular.module('LibraryApp')
       .config(['$routeProvider', '$locationProvider', '$httpProvider', function ($routeProvider, $locationProvider, $httpProvider) {
    $routeProvider
        .when('/Books', {
            controller: 'HomeController',
            templateUrl: '/Templates/BooksList.html'
        })
        .when('/AddBook', {
            controller: 'AddBookController',
            templateUrl: '/Templates/Add.html'
        })
        .when('/MyBooks', {
            controller: 'MyBooksController',
            templateUrl: '/Templates/MyBooks.html'
        })
        .when('/Login', {
            templateUrl: '/Templates/Login.html',
            controller: 'LoginController'
        })
        .when('/Register', {
            templateUrl: '/Templates/Register.html'
        })
        .otherwise({
            redirectTo: '/Books'
        });

    //$locationProvider.html5Mode({
    //    enable: true,
    //    requireBase: false
    //});

    $httpProvider.interceptors.push('authInterceptor');
}]);