(function() {
  window.DatabaseTableTimeReportController = function($scope, $rootScope, TimeReport, Assignment, Performer) {
    $scope.timeReports = TimeReport.query();
    $scope.assignments = Assignment.query();
    $scope.performers = Performer.query();
    $scope.orderOption = 'id';
    $scope.sort = function(newOrderOption) {
      return $scope.orderOption = newOrderOption;
    };
    $scope["delete"] = function(id) {
      var timeReport;

      timeReport = _.find($scope.timeReports, function(timeReport) {
        return timeReport.id === id;
      });
      return timeReport.$delete(function(data) {
        $scope.timeReports = _.filter($scope.timeReports, function(timeReport) {
          return timeReport.id !== id;
        });
        return $rootScope.$broadcast('infoMessage', "Tidrapport borttagen");
      }, function(err) {
        return $rootScope.$broadcast('infoMessage', err.status + ": " + err.data.ExceptionMessage);
      });
    };
    $scope.save = function() {
      if ($scope.currentTimeReport.id) {
        return $scope.currentTimeReport.$update(function(data) {
          return $rootScope.$broadcast('infoMessage', "Tidrapport uppdaterad");
        }, function(err) {
          return $rootScope.$broadcast('infoMessage', err.status + ": " + err.data.ExceptionMessage);
        });
      } else {
        return $scope.currentTimeReport.$save(function(data) {
          $scope.timeReports.push($scope.currentTimeReport);
          return $rootScope.$broadcast('infoMessage', "Tidrapport sparad");
        }, function(err) {
          return $rootScope.$broadcast('infoMessage', err.status + ": " + err.data.ExceptionMessage);
        });
      }
    };
    $scope.open = function(id) {
      if (id) {
        $scope.currentTimeReport = _.find($scope.timeReports, function(timeReport) {
          return timeReport.id === id;
        });
      } else {
        $scope.currentTimeReport = new TimeReport();
      }
      return $scope.shouldBeOpen = true;
    };
    $scope.close = function() {
      return $scope.shouldBeOpen = false;
    };
    return $scope.opts = {
      backdropFade: true,
      dialogFade: true
    };
  };

}).call(this);
