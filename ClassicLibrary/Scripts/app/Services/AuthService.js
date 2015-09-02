app.factory('authService', ['$http', '$q', '$localStorage', function ($http, $q, $localStorage) {   

    var service = {};

    var auth = {
        isAuth: false,
        userName: ""
    };      

    function login(loginData) {
        var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;
        var deffered = $q.defer();

        $http.post('/Token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
            .success(function (response) {
                $localStorage.set('authorizationData', { token: response.access_token, userName: loginData.userName });

                auth.isAuth = true;
                auth.userName = loginData.userName;

                deffered.resolve(response);
            })
            .error(function (err) {
                logout();
                deffered.reject(err);
            });

        return deffered.promise;
    };

    function register() {};

    function logout() {
        $localStorage.remove('authorizationData');

        auth.isAuth = false;
        auth.userName = "";
    };

    function getAuthData() {
        var authData = $localStorage.get('authorizationData');
        if (authData) {
            auth.isAuth = true;
            auth.userName = authData.userName;
        }
    };

    service.login = login;
    service.register = register
    service.authentication = auth;
    service.logout = logout;
    service.fillAuthData = getAuthData;

    return service;
}]);