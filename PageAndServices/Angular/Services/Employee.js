(function() {
  window.app.service('EmployeeService', [
    '$http', function($http) {
      this.connectCategories = function(employeeId, categoryIds) {
        return $http({
          url: "/api/employee/" + employeeId + "/ConnectCategory",
          data: {
            'employeeId': employeeId,
            'categoryIds': categoryIds
          },
          method: "POST"
        });
      };
      return this.getEmployee = function(email, password) {
        return $http({
          url: "/api/employee/getlogin?email=" + email + "&password=" + password,
          method: "GET"
        });
      };
    }
  ]);

}).call(this);
