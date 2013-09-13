(function() {
  window.app.controller('MissionsController', [
    '$scope', '$http', 'Mission', function($scope, $http, Mission) {
      return $scope.output.missionsNew = Mission.query();
    }
  ]);

}).call(this);
