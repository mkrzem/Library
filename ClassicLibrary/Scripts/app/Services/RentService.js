app.factory('rentService', ['$http', '$q', function ($http, $q) {
    var service = {
        borrow: borrowBook,
        queue: queueBook
    };

    return service;

    function borrowBook(id) {
        var deffered = $q.defer();

        $http.post('api/borrow', {
            Id: id
        })
        .success(function (response) {
            deffered.resolve(response);
        })
        .error(function (err) {
            deffered.reject(err);
        });

        return deffered.promise;
    };

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