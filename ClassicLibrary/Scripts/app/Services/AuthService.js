(function(){
    angular.module('LibraryApp')
           .factory('authService', ['$http', '$q', '$localStorageService', AuthService])
        
    function AuthService($http, $q, $localStorageService) {
        self = this;
        self.auth = {};

        return {
            login: login,
            logout: logout,
            fillAuthData: getAuthData,
            isInRole: isInRole,
            authentication: self.auth
        };

        self.auth = {
            isAuth: false,
            userName: "",
            roles: []
        };

        function login(loginData) {
            var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;
            var deffered = $q.defer();

            $http.post('/Token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                .success(function (response) {
                    $localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, roles: response.roles });

                    self.auth.isAuth = true;
                    self.auth.userName = loginData.userName;
                    self.auth.roles = response.roles.split(",", 10);

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
            $localStorageService.remove('authorizationData');

            self.auth.isAuth = false;
            self.auth.userName = "";
            self.auth.roles = [];
        };

        function getAuthData() {
            var authData = $localStorageService.get('authorizationData');
            if (authData) {
                self.auth.isAuth = true;
                self.auth.userName = authData.userName;
                self.auth.roles = authData.roles;
            }
        };

        function isInRole(role) {
            return self.auth.roles.indexOf(role) > -1;
        };

        //authService.login = login;
        //authService.register = register
        //authService.authentication = auth;
        //authService.logout = logout;
        //authService.fillAuthData = getAuthData;
        //authService.isInRole = isInRole;

        //return authService;
    };
})();