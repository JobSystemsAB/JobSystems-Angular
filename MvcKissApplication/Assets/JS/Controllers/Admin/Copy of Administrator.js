(function() {
  window.app.controller('AdministratorController', [
    '$scope', '$http', 'Administrator', function($scope, $http, Administrator) {
      return $scope.administrators = Administrator.query();
    }
  ]);

}).call(this);
