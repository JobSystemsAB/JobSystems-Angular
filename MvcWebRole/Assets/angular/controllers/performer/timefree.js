(function() {
  window.PerformerTimefreeController = function($scope, CalendarService, PerformerTimeFree) {
    $scope.resetTimes = function() {
      return $scope.times = [
        {
          id: 0,
          text: '08:00 - 12:00',
          checked: false
        }, {
          id: 1,
          text: '13:00 - 16:00',
          checked: false
        }, {
          id: 2,
          text: '17:00 - 20:00',
          checked: false
        }
      ];
    };
    $scope.checkTime = function(id) {
      $scope.times[id].checked = !$scope.times[id].checked;
      return $scope.save();
    };
    $scope.save = function() {
      var data, performerTimeFree;

      data = {};
      data.performerId = 5;
      data.day = CalendarService.getDate();
      data.morning = $scope.times[0].checked;
      data.afternoon = $scope.times[1].checked;
      data.evening = $scope.times[2].checked;
      performerTimeFree = new PerformerTimeFree(data);
      return performerTimeFree.$save(function(data) {
        return console.log(data);
      }, function(err) {
        return console.log(err);
      });
    };
    $scope.$on('CalendarService.update', function(event, date) {
      $scope.resetTimes();
      return $scope.input.date = CalendarService.getDate();
    });
    $scope.$on('CalendarService.ready', function(event) {
      return CalendarService.getFreeTimes(5);
    });
    $scope.input = {};
    $scope.input.date = CalendarService.getDate();
    return $scope.resetTimes();
  };

}).call(this);
