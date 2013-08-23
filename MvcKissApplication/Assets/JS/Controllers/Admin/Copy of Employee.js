(function() {
  window.app.controller('EmployeeController', [
    '$scope', '$http', 'Employee', function($scope, $http, Employee) {
      return $scope.employees = Employee.query();
    }
  ]);

}).call(this);
