(function() {
  window.app.controller('AdminServiceInputsController', [
    '$scope', 'CategoryService', 'CategoryInputService', 'AlertService', function($scope, CategoryService, CategoryInputService, AlertService) {
      CategoryService.getAll().success(function(data, status, headers, config) {
        return $scope.categories = _.filter(data, function(item) {
          return item.parentId === null;
        });
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('danger', 'Failed to load all services.');
      });
      CategoryInputService.getAll().success(function(data, status, headers, config) {
        $scope.inputs = data;
        $scope.inputsGrouped = _.groupBy(data, 'categoryId');
        return console.log($scope.inputsGrouped);
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('danger', 'Failed to load all service inputs.');
      });
      $scope.create = function() {
        return CategoryInputService.post($scope.newInput).success(function(data, status, headers, config) {
          AlertService.addAlert('success', 'New input saved.');
          $scope.inputs.push(data);
          return $scope.inputsGrouped = _.groupBy($scope.inputs, 'categoryId');
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Failed to save new input.');
        });
      };
      $scope.update = function(input) {
        return CategoryInputService.put(input).success(function(data, status, headers, config) {
          return AlertService.addAlert('success', 'Input updated.');
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Failed to save new input.');
        });
      };
      return $scope["delete"] = function(inputId) {
        return CategoryInputService["delete"](inputId).success(function(data, status, headers, config) {
          AlertService.addAlert('success', 'Input removed.');
          $scope.inputs = _.reject($scope.inputs, function(input) {
            return input.id === inputId;
          });
          return $scope.inputsGrouped = _.groupBy($scope.inputs, 'categoryId');
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Failed to save new input.');
        });
      };
    }
  ]);

}).call(this);
