(function() {
  window.app.controller('EmployeeViewController', [
    '$scope', '$routeParams', 'Employee', function($scope, $routeParams, Employee) {
      $scope.input = {};
      $scope.save = function() {
        if ($scope.isNotNew()) {
          return $scope.input.$update();
        } else {
          $scope.input = new Category($scope.input);
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
      $scope.input.id = $routeParams.CategoryId;
      if ($scope.isNotNew()) {
        return $scope.input = Category.get({
          id: $scope.input.id
        });
      }
    }
  ]);

}).call(this);
