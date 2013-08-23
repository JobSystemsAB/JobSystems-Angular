(function() {
  window.app.controller('SubcategoryController', [
    '$scope', '$http', 'Subcategory', function($scope, $http, Subcategory) {
      return $scope.subcategories = Subcategory.query();
    }
  ]);

}).call(this);
