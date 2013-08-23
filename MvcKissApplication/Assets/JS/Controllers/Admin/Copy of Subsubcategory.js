(function() {
  window.app.controller('SubsubcategoryController', [
    '$scope', '$http', 'Subsubcategory', function($scope, $http, Subsubcategory) {
      return $scope.subsubcategories = Subsubcategory.query();
    }
  ]);

}).call(this);
