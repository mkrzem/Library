app.factory('authService', ['$http', '$q', '$localStorage', function ($http, $q, $localStorage) {   

    var service = {};

    var auth = {
        isAuth: false,
        userName: "",
        roles: []
    };      

    function login(loginData) {
        var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;
        var deffered = $q.defer();

        $http.post('/Token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
            .success(function (response) {
                $localStorage.set('authorizationData', { token: response.access_token, userName: loginData.userName, roles: response.roles });

                auth.isAuth = true;
                auth.userName = loginData.userName;
                auth.roles = response.roles.split(",", 10);

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
        auth.roles = [];
    };

    function getAuthData() {
        var authData = $localStorage.get('authorizationData');
        if (authData) {
            auth.isAuth = true;
            auth.userName = authData.userName;
            auth.roles = authData.roles;
        }
    };

    function isInRole(role) {
        return auth.roles.indexOf(role) > -1;
    };

    service.login = login;
    service.register = register
    service.authentication = auth;
    service.logout = logout;
    service.fillAuthData = getAuthData;
    service.isInRole = isInRole;

    return service;
}]);