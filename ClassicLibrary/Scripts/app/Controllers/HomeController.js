app.controller("HomeController", ['$scope', '$http', '$window', 'bookService', 'rentService',  function ($scope, $http, $window, bookService, rentService) {
    
    bookService.books().then(function (data) {
        $scope.books = data;
    });

    $scope.reserveBook = function (book) {        
        var rentResource = new rentService.borrow();
        rentResource.id = book.Id;
        rentResource.$save();
    };
}])