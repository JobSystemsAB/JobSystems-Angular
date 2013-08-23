(function() {
  window.app.controller('LoginController', [
    '$scope', 'AdministratorService', function($scope, AdministratorService) {
      return $scope.tryToLogin = function() {
        return AdministratorService.getAdministrator($scope.input.email, $scope.input.password).success(function(data, status, headers, config) {
          return console.log('worked!');
        });
      };
    }
  ]);

}).call(this);
