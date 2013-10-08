(function() {
  window.app.controller('ApproveEmployeeController', [
    '$scope', '$http', function($scope, $http) {
      return $http({
        url: "/api/employees/GetAllPet",
        method: "GET"
      }).success(function(status, data, headers, config) {
        $scope.employees = status;
        return $scope.addAlert("Din ansökan är nu skickad", "success");
      }).error(function(status, data, headers, config) {
        return $scope.addAlert("Misslyckades skicka ansökan, prova igen eller vänligen kontakta oss", "error");
      });
    }
  ]);

}).call(this);
