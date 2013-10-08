(function() {
  window.app.controller('FooterController', [
    '$scope', '$state', 'CategoryService', 'AlertService', function($scope, $state, CategoryService, AlertService) {
      CategoryService.getAll().success(function(data, status, headers, config) {
        return $scope.categories = _.filter(data, function(item) {
          return item.parentId === null;
        });
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('danger', 'Misslyckades att hämta tjänsterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
      });
      return $scope.goToService = function(serviceId) {
        return $state.go('service', {
          'serviceId': serviceId
        });
      };
    }
  ]);

}).call(this);
