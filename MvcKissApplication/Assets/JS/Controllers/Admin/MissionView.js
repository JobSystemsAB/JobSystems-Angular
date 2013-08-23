(function() {
  window.app.controller('MissionViewController', [
    '$scope', '$routeParams', 'Mission', 'Category', 'CategoryService', 'SubcategoryService', function($scope, $routeParams, Mission, Category, CategoryService, SubcategoryService) {
      $scope.input = {};
      $scope.input.inputs = {};
      $scope.output = {};
      $scope.updateSubcategory = function() {
        $scope.output.subcategories = [];
        $scope.output.subsubcategories = [];
        CategoryService.getSubcategories($scope.input.categoryId).success(function(data, status, headers, config) {
          return $scope.output.subcategories = data;
        });
        return CategoryService.getCategoryInputs($scope.input.categoryId).success(function(data, status, headers, config) {
          return $scope.output.inputs = data;
        });
      };
      $scope.updateSubsubcategory = function() {
        $scope.output.subsubcategories = [];
        return SubcategoryService.getSubsubcategories($scope.input.subcategoryId).success(function(data, status, headers, config) {
          return $scope.output.subsubcategories = data;
        });
      };
      $scope.inputsToJson = function() {
        return angular.toJson(_.map($scope.output.inputs, function(input) {
          return {
            name: input.name,
            value: input.value
          };
        }));
      };
      $scope.save = function() {
        if ($scope.isNotNew()) {
          return $scope.input.$update();
        } else {
          $scope.input = new Mission($scope.input);
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
      $scope.hasSubcategory = function() {
        return $scope.output.subcategories && $scope.output.subcategories.length > 0;
      };
      $scope.hasSubsubcategory = function() {
        return $scope.output.subsubcategories && $scope.output.subsubcategories.length > 0;
      };
      $scope.input.id = $routeParams.missionId;
      if ($scope.isNotNew()) {
        $scope.input = Mission.get({
          id: $scope.input.id
        });
      }
      return $scope.output.categories = Category.query();
    }
  ]);

}).call(this);
