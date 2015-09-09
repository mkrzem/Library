(function () {
    angular.module('LibraryApp')
           .controller('HomeController', ['$scope', '$http', '$window', 'bookService', 'rentService', 'dialogBox', HomeController])
    
    function HomeController($scope, $http, $window, bookService, rentService, dialogBox) {
        vm = this;
        vm.getBooks = function () {
            bookService.books().then(function (data) {
                $scope.books = data;
            });
        };

        vm.getBooks();

        $scope.reserveBook = function (book) {
            var rentResource = rentService.getResource();
            rentResource.id = book.Id;
            rentResource.$save().then(function (response) {
                config = {
                    input: {
                        message: response.result
                    },
                    error: false
                }

                dialogBox.show(config);
            });
            vm.getBooks();
        };
    };
})();