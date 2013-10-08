(function() {
  window.app.controller('ServicesController', [
    '$scope', '$state', 'TextService', 'CategoryService', 'AlertService', function($scope, $state, TextService, CategoryService, AlertService) {
      var files;

      $scope.text - (files = ['services-title', 'services-text']);
      TextService.getAllByControllerAndLanguage('ServicesController', 'sv').success(function(data, status, headers, config) {
        $scope.textsOriginal = data;
        return $scope.texts = _.groupBy($scope.textsOriginal, function(text) {
          return text.elementId;
        });
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('danger', 'Misslyckades att hämta texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
      });
      CategoryService.getAll().success(function(data, status, headers, config) {
        return $scope.categories = _.filter(data, function(item) {
          return item.parentId === null;
        });
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('danger', 'Misslyckades att hämta tjänsterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
      });
      $scope.save = function() {
        TextService.postAll($scope.textsOriginal).success(function(data, status, headers, config) {
          return AlertService.addAlert('success', 'Texter sparade.');
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Misslyckades att spara texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
        });
        return CategoryService.postAll($scope.categories).success(function(data, status, headers, config) {
          return AlertService.addAlert('success', 'Tjänster sparade.');
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Misslyckades att spara tjänsterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
        });
      };
      return $scope.goToService = function(serviceId, serviceUrl) {
        return $state.go(serviceUrl, {
          'serviceId': serviceId
        });
      };
    }
  ]);

}).call(this);
