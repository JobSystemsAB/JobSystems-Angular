(function() {
  window.app.controller('AlertController', [
    '$scope', 'AlertService', function($scope, AlertService) {
      return $scope.closeAlert = function(index) {
        return AlertService.closeAlert(index, 1);
      };
    }
  ]);

}).call(this);
