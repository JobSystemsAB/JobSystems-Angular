(function() {
  window.app.controller('HomeAdminLoginController', [
    '$scope', '$rootScope', '$timeout', 'AdministratorService', 'AlertService', function($scope, $rootScope, $timeout, AdministratorService, AlertService) {
      $scope.admin = {
        email: '',
        password: ''
      };
      return $scope.tryLogin = function() {
        return AdministratorService.login($scope.admin.email, $scope.admin.password).success(function(data, status, headers, config) {
          AlertService.addAlert('success', 'Inloggad som ' + $scope.admin.email + '. Du vidarebefordras till startsidan. Notera att alla ändringar påverkar sidan live.');
          console.log(data.authToken);
          $rootScope.isAdmin = true;
          return $timeout(function() {
            return $state.go('admin', {});
          }, 2500);
        }).error(function(data, status, headers, config) {
          if (status === 404) {
            return AlertService.addAlert('danger', 'Inloggning misslyckades, vänligen kontrollera användarnamn och lösenord.');
          } else {
            return AlertService.addAlert('danger', 'Inloggning misslyckades, vänligen prova igen eller ta kontakt med en tekniker.');
          }
        });
      };
    }
  ]);

}).call(this);
