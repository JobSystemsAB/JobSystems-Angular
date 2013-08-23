(function() {
  window.app.controller('SubcategoryViewController', [
    '$scope', '$routeParams', 'Subcategory', function($scope, $routeParams, Subcategory) {
      $scope.input = {};
      $scope.save = function() {
        if ($scope.isNotNew()) {
          return $scope.input.$update();
        } else {
          $scope.input = new Subcategory($scope.input);
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
      $scope.input.id = $routeParams.subcategoryId;
      if ($scope.isNotNew()) {
        return $scope.input = Subcategory.get({
          id: $scope.input.id
        });
      }
    }
  ]);

}).call(this);
