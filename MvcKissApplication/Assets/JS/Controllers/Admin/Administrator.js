(function() {
  window.app.controller('AdministratorController', [
    '$scope', 'Administrator', function($scope, Administrator) {
      $scope.administrators = Administrator.query();
      return $scope["delete"] = function(administrator) {
        administrator.$remove();
        return $scope.administrators = _.filter($scope.administrators, function(admin) {
          return admin.id !== administrator.id;
        });
      };
    }
  ]);

}).call(this);
