(function () {
    angular.module('LibraryApp')
           .factory('$localStorageService', LocalStorageService)
        
    LocalStorageService.$inject = ['$window'];
        
    function LocalStorageService($window) {
        var localStorage = {};
        localStorage.get = get;
        localStorage.set = set;
        localStorage.remove = remove;

        return localStorage;

        function get(key) {
            return JSON.parse($window.localStorage.getItem(key));
        };

        function set(key, value) {
            $window.localStorage.setItem(key, JSON.stringify(value));
        };

        function remove(key) {
            $window.localStorage.removeItem(key);
        };
        
    };
})();