(function() {
  window.app.controller('SubcategoryController', [
    '$scope', 'Subcategory', function($scope, Subcategory) {
      $scope.subcategories = Subcategory.query();
      return $scope["delete"] = function(subcategory) {
        subcategory.$remove();
        return $scope.subcategories = _.filter($scope.subcategories, function(sub) {
          return sub.id !== subcategory.id;
        });
      };
    }
  ]);

}).call(this);
