(function() {
  window.app.controller('LoginController', [
    '$scope', 'EmployeeService', function($scope, EmployeeService) {
      return $scope.tryToLogin = function() {
        return EmployeeService.getEmployee($scope.input.email, $scope.input.password).success(function(data, status, headers, config) {
          return console.log('worked!');
        });
      };
    }
  ]);

}).call(this);
