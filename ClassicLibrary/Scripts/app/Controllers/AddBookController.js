app.controller('AddBookController', ['$scope', '$location', 'bookService', function ($scope, $location, bookService) {
    $scope.added = false;
    $scope.booksCount = 0;

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
    
    $scope.save = function() {
        var result = bookService.save($scope.newBook);
        result.then(function (response) {
            $scope.added = true;
            $scope.booksCount += 1;
        }, function (err) {
            alert(err);
        })
    };
}]);