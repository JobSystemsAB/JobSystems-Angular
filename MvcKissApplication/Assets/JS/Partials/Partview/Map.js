(function() {
  window.app.controller('MapController', [
    '$scope', 'TextService', function($scope, TextService) {
      var files;

      $scope.text - (files = ['map-title', 'map-address', 'map-phone-number', 'map-email']);
      google.maps.visualRefresh = true;
      angular.extend($scope, {
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
      TextService.getTexts('MapController', 'sv').success(function(data, status, headers, config) {
        $scope.textsOriginal = data;
        return $scope.texts = _.groupBy($scope.textsOriginal, function(text) {
          return text.elementId;
        });
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('danger', 'Misslyckades att hämta texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
      });
      return $scope.save = function() {
        return TextService.saveTexts($scope.textsOriginal).success(function(data, status, headers, config) {
          return AlertService.addAlert('success', 'Texter sparade.');
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Misslyckades att spara texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
        });
      };
    }
  ]);

}).call(this);
