(function() {
  window.app.controller('HomeIndexController', [
    '$scope', '$http', 'Category', function($scope, $http, Category) {
      $scope.output = {};
      return $scope.output.categories = Category.query();
    }
  ]);

}).call(this);
