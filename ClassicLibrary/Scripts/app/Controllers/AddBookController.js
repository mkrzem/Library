app.controller('AddBookController', ['$scope', '$location', 'bookService',  function ($scope, $location, bookService) {
    $scope.newBook= {
        Name: '',
        Genre: 'Drama',
        Author: '',
        Status: 'Available',
        Quantity: 1
    };

    $scope.$location = $location;

    bookService.genres().then(function(data) {
        $scope.genres = data.data;
    });
    
    $scope.save = function() {
        var result = bookService.save($scope.newBook.Name, $scope.newBook.Genre, $scope.newBook.Author);        
    };
}]);