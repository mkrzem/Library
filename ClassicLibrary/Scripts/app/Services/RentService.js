(function () {
    angular.module('LibraryApp')
           .factory('rentService', RentService);
        
    RentService.$inject = ['$http', '$q', '$resource'];

    function RentService($http, $q, $resource) {
        var service = {};
        service.getResource = function () {
            var resource = $resource('api/borrow/:id', { id: '@id' });
            return new resource();
        };
        
        return service;

    };
})();