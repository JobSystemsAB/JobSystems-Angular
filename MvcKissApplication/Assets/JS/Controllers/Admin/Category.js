(function() {
  window.app.controller('CategoryController', [
    '$scope', 'Category', function($scope, Category) {
      $scope.categories = Category.query();
      return $scope["delete"] = function(category) {
        category.$remove();
        return $scope.categories = _.filter($scope.categories, function(cat) {
          return cat.id !== category.id;
        });
      };
    }
  ]);

}).call(this);
