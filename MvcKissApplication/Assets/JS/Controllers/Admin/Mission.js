(function() {
  window.app.controller('MissionController', [
    '$scope', 'Mission', function($scope, Mission) {
      $scope.missions = Mission.query();
      return $scope["delete"] = function(mission) {
        mission.$remove();
        return $scope.missions = _.filter($scope.missions, function(mis) {
          return mis.id !== mission.id;
        });
      };
    }
  ]);

}).call(this);
