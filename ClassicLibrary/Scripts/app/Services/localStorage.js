app.factory('$localStorage', ['$window', function ($window) {
    return {
        get: function (key) {
            return $window.localStorage.getItem(key);
        },

        set: function (key, value) {
            $window.localStorage.setItem(key, value);
        }
    };
}]);