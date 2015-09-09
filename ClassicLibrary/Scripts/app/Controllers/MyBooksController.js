(function() {
    angular.module('LibraryApp')
           .controller('MyBooksController', ['$scope', 'bookService', MyBooksController])
    
    function MyBooksController($scope, bookService) {
        bookService.myBooks().then(function (data) {
            $scope.myBooks = data;
        });
    };
})();