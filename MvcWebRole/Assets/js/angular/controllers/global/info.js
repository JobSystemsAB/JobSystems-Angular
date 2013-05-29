(function() {
  window.InfoCtrl = function($scope, $timeout) {
    $scope.infos = [];
    $scope.currentTime = function() {
      var now;

      now = new Date();
      return now.getHours() + ':' + now.getMinutes() + ':' + now.getSeconds();
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
