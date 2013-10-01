(function() {
  window.app.controller('ServicesController', [
    '$scope', 'TextService', 'CategoryService', 'AlertService', function($scope, TextService, CategoryService, AlertService) {
      var files;

      $scope.text - (files = ['services-title', 'services-text']);
      TextService.getTexts('ServicesController', 'sv').success(function(data, status, headers, config) {
        $scope.textsOriginal = data;
        return $scope.texts = _.groupBy($scope.textsOriginal, function(text) {
          return text.elementId;
        });
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('error', 'Fel: ' + status);
      });
      CategoryService.getAll().success(function(data, status, headers, config) {
        return $scope.categories = _.filter(data, function(item) {
          return item.parentId === null;
        });
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('error', 'Fel: ' + status);
      });
      return $scope.save = function() {
        TextService.saveTexts($scope.textsOriginal).success(function(data, status, headers, config) {
          return console.log(status);
        }).error(function(data, status, headers, config) {
          return console.log(status);
        });
        console.log($scope.categories);
        return CategoryService.saveCategories($scope.categories).success(function(data, status, headers, config) {
          return console.log(status);
        }).error(function(data, status, headers, config) {
          return console.log(status);
        });
      };
    }
  ]);

}).call(this);
