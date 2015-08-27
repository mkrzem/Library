(function() {
    app.factory('bookService', service);

    service.$inject = ['$http', '$q'];

    function service($http, $q) {
        var service = {
            genres: getGenres,
            save: saveBook
        };

        return service;

        function getGenres() {
            var deffered = $q.defer();

            $http.get('home/getgenres')
                .success(function (response) {
                    deffered.resolve(response);
                })
                .error(function (err) {
                    console.error(err);
                });

            return deffered.promise;
        }

        function saveBook() {
            
        }
    };
})();