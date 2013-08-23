(function() {
  window.app.controller('AdministratorViewController', [
    '$scope', '$routeParams', 'Administrator', function($scope, $routeParams, Administrator) {
      $scope.input = {};
      $scope.save = function() {
        if ($scope.isNotNew()) {
          return $scope.input.$update();
        } else {
          $scope.input = new Administrator($scope.input);
          $scope.input.$save();
          return console.log($scope.input);
        }
      };
      $scope["delete"] = function() {
        return $scope.input.$remove();
      };
      $scope.isNotNew = function() {
        return $scope.input.id !== '0';
      };
      $scope.input.id = $routeParams.administratorId;
      if ($scope.isNotNew()) {
        return $scope.input = Administrator.get({
          id: $scope.input.id
        });
      }
    }
  ]);

}).call(this);
