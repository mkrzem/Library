app.controller("HomeController", ['$scope', '$http', '$window', 'bookService', 'rentService', 'dialogBox',  function ($scope, $http, $window, bookService, rentService, dialogBox) {
    function getBooks() {
        bookService.books().then(function (data) {
            $scope.books = data;
        });
    };

    getBooks();

    $scope.reserveBook = function (book) {        
        var rentResource = new rentService.borrow();
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
        getBooks();
    };
}])