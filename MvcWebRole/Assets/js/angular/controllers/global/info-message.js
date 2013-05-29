(function() {
  window.InfoMessageController = function($scope, $timeout) {
    $scope.infos = [];
    $scope.currentTime = function() {
      var hour, minute, now, second;

      now = new Date();
      hour = String(now.getHours());
      minute = String(now.getMinutes());
      second = String(now.getSeconds());
      if (hour.length < 2) {
        hour = "0" + hour;
      }
      if (minute.length < 2) {
        minute = "0" + minute;
      }
      if (second.length < 2) {
        second = "0" + second;
      }
      return hour + ":" + minute + ":" + second;
    };
    $scope.add = function(message) {
      return $scope.infos.push({
        message: message,
        time: $scope.currentTime()
      });
    };
    $scope.remove = function() {
      return $scope.infos.pop();
    };
    return $scope.$on('infoMessage', function(e, args) {
      $scope.add(args);
      return $timeout($scope.remove, 5000);
    });
  };

}).call(this);
