(function() {
  window.app.controller('SubsubcategoryViewController', [
    '$scope', '$routeParams', 'Subsubcategory', function($scope, $routeParams, Subsubcategory) {
      $scope.input = {};
      $scope.save = function() {
        if ($scope.isNotNew()) {
          return $scope.input.$update();
        } else {
          $scope.input = new Subsubcategory($scope.input);
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
      $scope.input.id = $routeParams.subsubcategoryId;
      if ($scope.isNotNew()) {
        return $scope.input = Subsubcategory.get({
          id: $scope.input.id
        });
      }
    }
  ]);

}).call(this);
