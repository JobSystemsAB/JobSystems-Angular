(function() {
  window.app.controller('EmployeeController', [
    '$scope', 'Employee', function($scope, Employee) {
      $scope.employees = Employee.query();
      return $scope["delete"] = function(employee) {
        employee.$remove();
        return $scope.employees = _.filter($scope.employees, function(emp) {
          return emp.id !== employee.id;
        });
      };
    }
  ]);

}).call(this);
