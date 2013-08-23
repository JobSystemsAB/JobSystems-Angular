(function() {
  window.app.controller('HomeIndexController', [
    '$scope', '$http', 'Category', 'Subcategory', 'Subsubcategory', function($scope, $http, Category, Subcategory, Subsubcategory) {
      $scope.output = {};
      $scope.input = {};
      $scope.category = Category.query();
      $scope.subcategory = Subcategory.query();
      return $scope.subsubcategory = Subsubcategory.query();
    }
  ]);

}).call(this);
