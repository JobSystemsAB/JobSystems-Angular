(function() {
  window.app.controller('AdminServicesController', [
    '$scope', 'CategoryService', 'AlertService', function($scope, CategoryService, AlertService) {
      $scope.loadTree = function() {
        return CategoryService.getTree().success(function(data, status, headers, config) {
          return $scope.categoryTree = data;
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Failed to load all services.');
        });
      };
      $scope.loadTree();
      $scope.changeSelected = function(selected) {
        $scope.service.parent = selected;
        return $scope.selected = selected;
      };
      $scope.service = {};
      $scope.orderUp = function() {
        return $scope.selected.order += 1;
      };
      $scope.orderDown = function() {
        return $scope.selected.order -= 1;
      };
      $scope.create = function() {
        var parentId;

        parentId = null;
        if ($scope.service.parent) {
          parentId = $scope.service.parent.id;
        }
        return CategoryService.post({
          description: $scope.service.description,
          name: $scope.service.name,
          parentId: parentId,
          salary: $scope.service.salary,
          order: 0
        }).success(function(data, status, headers, config) {
          AlertService.addAlert('success', 'New service saved.');
          return $scope.loadTree();
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Service was not able to be saved.');
        });
      };
      $scope.update = function() {
        return CategoryService.put($scope.selected).success(function(data, status, headers, config) {
          return AlertService.addAlert('success', 'Service updated.');
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Service was not able to be updated.');
        });
      };
      return $scope["delete"] = function() {
        return CategoryService["delete"]($scope.selected.id).success(function(data, status, headers, config) {
          AlertService.addAlert('success', 'New service saved.');
          return $scope.loadTree();
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Service was not able to be saved.');
        });
      };
    }
  ]);

}).call(this);
