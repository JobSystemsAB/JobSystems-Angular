(function() {
  window.app.controller('TitleWindowController', [
    '$scope', '$state', '$stateParams', 'AlertService', 'TextService', function($scope, $state, $stateParams, AlertService, TextService) {
      var files;

      $scope.text - (files = ['title-window-text', 'title-window-book-text', 'title-window-button']);
      $scope.currentCategoryId = $stateParams.serviceId;
      TextService.getTexts('TitleWindowController', 'sv').success(function(data, status, headers, config) {
        $scope.textsOriginal = data;
        return $scope.texts = _.groupBy($scope.textsOriginal, function(text) {
          return text.elementId;
        });
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('danger', 'Misslyckades att hämta texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
      });
      $scope.save = function() {
        return TextService.saveTexts($scope.textsOriginal).success(function(data, status, headers, config) {
          return AlertService.addAlert('success', 'Texter sparade.');
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Misslyckades att spara texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
        });
      };
      return $scope.goToBooking = function() {
        return $state.go('book', {
          serviceId: $scope.currentCategoryId
        });
      };
    }
  ]);

}).call(this);
