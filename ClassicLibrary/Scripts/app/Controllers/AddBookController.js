app.controller('AddBookController', ['$scope', '$location',  function ($scope, $location) {
    $scope.newBook= {
        Name: '',
        Genre: 'Drama',
        Author: '',
        Status: 'Available',
        Quantity: 1
    };

    $scope.$location = $location;

    //$scope.save = function() {
    //    var result = bookService.save($scope.newBook.Name, $scope.newBook.Genre, $scope.newBook.Author);

        
   // };
}]);