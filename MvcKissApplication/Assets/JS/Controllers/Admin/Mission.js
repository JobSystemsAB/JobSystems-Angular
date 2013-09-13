(function() {
  window.app.controller('MissionController', [
    '$scope', 'Mission', 'MissionService', function($scope, Mission, MissionService) {
      $scope.missions = {};
      $scope.missions = MissionService.getEmployed().success(function(data, status) {
        return $scope.employed = data;
      });
      $scope.missions = MissionService.getUnemployed().success(function(data, status) {
        return $scope.unemployed = data;
      });
      $scope.missions = MissionService.getDisabled().success(function(data, status) {
        return $scope.disabled = data;
      });
      return $scope["delete"] = function(mission) {
        mission.$remove();
        return $scope.missions = _.filter($scope.missions, function(mis) {
          return mis.id !== mission.id;
        });
      };
    }
  ]);

}).call(this);
