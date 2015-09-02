app.controller('MyBooksController', ['$scope', 'bookService', function ($scope, bookService) {
    bookService.myBooks().then(function (data) {
        $scope.myBooks = data;
    });
}]);