app.controller('AddBookController', ['$scope', '$location', 'bookService', function ($scope, $location, bookService) {
    $scope.added = false;
    $scope.failed = false;
    $scope.error = '';
    $scope.booksCount = 0;
    $scope.submitted = false;

    $scope.newBook = {
        Id: 0,
        Name: '',
        Genre: '0',
        Author: '',
        Status: 'Available',
        Quantity: 1
    };

    $scope.$location = $location;

    bookService.genres().then(function(data) {
        $scope.genres = data;
    });
    
    $scope.save = function (addBookForm) {

        if (addBookForm.$valid) {
            var result = bookService.save($scope.newBook);
            result.then(function (response) {
                $scope.failed = false;
                $scope.added = true;
                $scope.booksCount += 1;

                $scope.submitted = false;
                $scope.newBook = '';
            }, function (err) {
                $scope.added = false;
                $scope.error = err;
                $scope.failed = true;
            });
        } else {
            $scope.submitted = true;
        }
    };

    $scope.toggle = function() {
        $scope.added = !$scope.added;
        $scope.failed = !$scope.failed;
    };
}]);