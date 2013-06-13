(function() {
  window.AdminLoginController = function($scope, $rootScope, $location, $http) {
    return $scope.SignIn = function() {
      var hashPassword, loginData;

      hashPassword = String(CryptoJS.SHA3($scope.form.password, {
        outputLength: 256
      }));
      loginData = {
        username: $scope.form.username,
        password: hashPassword
      };
      return $http({
        url: "/api/administrator/login",
        data: loginData,
        method: "POST"
      }).success(function(status, data, headers, config) {
        localStorage.setItem('auth.accessToken', status.accessToken);
        localStorage.setItem('auth.userId', status.id);
        localStorage.setItem('auth.username', status.username);
        localStorage.setItem('auth.loggedIn', true);
        $rootScope.auth.loggedIn = true;
        $rootScope.auth.username = status.username;
        $rootScope.auth.userId = status.id;
        $rootScope.auth.accessToken = status.accessToken;
        return $location.path("administrators");
      }).error(function(status, data, headers, config) {
        return $scope.$broadcast('infoMessage', data + ": Inloggning misslyckades, vänligen prova igen");
      });
    };
  };

}).call(this);
