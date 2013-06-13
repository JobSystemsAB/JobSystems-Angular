(function() {
  window.PerformerTimereportController = function($scope, $rootScope, $http, TimeReport) {
    $scope.assignments = [];
    $scope.input = {};
    $scope.input.timereport = {};
    $scope.input.timereport.performerId = 5;
    $http({
      method: 'GET',
      url: 'api/performer/' + $scope.input.timereport.performerId + '/Assigments'
    }).success(function(data, status) {
      $scope.status = status;
      return $scope.assignments = data;
    }).error(function(data, status) {
      $scope.data = data || "Request failed";
      return $scope.status = status;
    });
    $scope.dateOptions = {
      monthNames: ['Januari', 'Februari', 'Mars', 'April', 'Maj', 'Juni', 'Juli', 'Augusti', 'September', 'Oktober', 'November', 'December'],
      monthNamesShort: ['Jan', 'Feb', 'Mar', 'Apr', 'Maj', 'Jun', 'Jul', 'Aug', 'Sep', 'Okt', 'Nov', 'Dec'],
      dayNamesShort: ['Sön', 'Mån', 'Tis', 'Ons', 'Tor', 'Fre', 'Lör'],
      dayNames: ['Söndag', 'Måndag', 'Tisdag', 'Onsdag', 'Torsdag', 'Fredag', 'Lördag'],
      dayNamesMin: ['Sö', 'Må', 'Ti', 'On', 'To', 'Fr', 'Lö'],
      weekHeader: 'Ve',
      dateFormat: 'yy-mm-dd',
      firstDay: 1,
      isRTL: false
    };
    $scope.changeAssignment = function() {
      if ($scope.input.timereport.assignmentId) {
        return $http({
          method: 'GET',
          url: 'api/performer/TimeReports?performerId=' + $scope.input.timereport.performerId + '&assignmentId=' + $scope.input.timereport.assignmentId
        }).success(function(data, status) {
          return $scope.timereports = data;
        }).error(function(data, status) {
          return console.log('failed!');
        });
      } else {
        return $scope.timereports = null;
      }
    };
    return $scope.createTimereport = function() {
      var inputData;

      inputData = new TimeReport($scope.input.timereport);
      return inputData.$save(function(data) {
        return $scope.timereports.push(data);
      }, function(err) {
        return console.log('error');
      });
    };
  };

}).call(this);
