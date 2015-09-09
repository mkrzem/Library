(function () {
    angular.module('LibraryApp')
           .factory('authInterceptor', ['$q', '$location', '$localStorageService', '$routeParams', AuthInterceptor])

    function AuthInterceptor($q, $location, $localStorageService, $routeParams) {
        var authInterceptorService = {};

        function request(config) {
            //config.headers = headers || {};        
            var authorizationData = $localStorageService.get('authorizationData');

            if (authorizationData) {
                config.headers.Authorization = 'Bearer ' + authorizationData.token;
            }

            return config;
        };

        function response(response) {
            if (response.status === 401) {
                $location.path('/Login');
            }
            return $q.reject(response);
        };

        authInterceptorService.request = request;
        authInterceptorService.responseError = response;
        return authInterceptorService;
    };
})();