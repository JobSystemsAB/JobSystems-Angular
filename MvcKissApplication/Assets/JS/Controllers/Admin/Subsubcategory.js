(function() {
  window.app.controller('SubsubcategoryController', [
    '$scope', 'Subsubcategory', function($scope, Subsubcategory) {
      $scope.subsubcategories = Subsubcategory.query();
      return $scope["delete"] = function(subsubcategory) {
        subsubcategory.$remove();
        return $scope.subsubcategories = _.filter($scope.subsubcategories, function(sub) {
          return sub.id !== subsubcategory.id;
        });
      };
    }
  ]);

}).call(this);
