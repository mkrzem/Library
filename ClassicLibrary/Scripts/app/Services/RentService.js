app.factory('rentService', ['$http', '$q', '$resource', function ($http, $q, $resource) {
    var service = {
        borrow: $resource('api/borrow/:id', { id: '@id' })
    };

    return service;

    
    //function borrowBook(id) {
    //    $resource('api/borrow/:id',)
    //    var deffered = $q.defer();

    //    $http.post('api/borrow/:id', 
    //        id
    //    )
    //    .success(function (response) {
    //        deffered.resolve(response);
    //    })
    //    .error(function (err) {
    //        deffered.reject(err);
    //    });

    //    return deffered.promise;
    //};

    //function queueBook(id) {
    //    var deffered = $q.defer();

    //    $http.post('api/borrow', {
    //        Id: id,
    //        queue: true
    //    })
    //    .success(function (response) {
    //        deffered.resolve(response);
    //    })
    //    .error(function (err) {
    //        deffered.reject(err);
    //    });

    //    return deffered.promise;
    //};
}]);