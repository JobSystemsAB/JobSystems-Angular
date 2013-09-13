(function() {
  window.app.controller('HomeIndexController', [
    '$scope', 'Category', 'AlertService', 'TextService', function($scope, Category, AlertService, TextService) {
      $scope.output = {};
      Category.query(function(data) {
        return $scope.output.categories = _.filter(data, function(item) {
          return item.parentId === null;
        });
      }, function(error) {
        return AlertService.addAlert('error', 'Fel: ' + error.status);
      });
      TextService.getTexts('HomeIndexController', 'sv').success(function(data, status, headers, config) {
        return $scope.texts = _.groupBy(data, function(iter) {
          return iter.elementId;
        });
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('error', 'Fel: ' + error.status);
      });
      google.maps.visualRefresh = true;
      return angular.extend($scope, {
        center: {
          latitude: 59.344679,
          longitude: 18.071171
        },
        markers: [
          {
            latitude: 59.344679,
            longitude: 18.071171
          }
        ],
        zoom: 15
      });
    }
  ]);

}).call(this);
