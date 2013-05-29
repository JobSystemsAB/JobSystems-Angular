(function() {
  window.DatabaseTableAssignmentController = function($scope, $rootScope, Assignment, Client, Performer) {
    $scope.assignments = Assignment.query();
    $scope.clients = Client.query();
    $scope.performers = Performer.query();
    $scope.orderOption = 'id';
    $scope.sort = function(newOrderOption) {
      return $scope.orderOption = newOrderOption;
    };
    $scope["delete"] = function(id) {
      var assignment;

      assignment = _.find($scope.assignments, function(assignment) {
        return assignment.id === id;
      });
      return assignment.$delete(function(data) {
        $scope.assignments = _.filter($scope.assignments, function(assignment) {
          return assignment.id !== id;
        });
        return $rootScope.$broadcast('infoMessage', "Uppdrag borttaget");
      }, function(err) {
        return $rootScope.$broadcast('infoMessage', err.status + ": " + err.data.ExceptionMessage);
      });
    };
    $scope.save = function() {
      if ($scope.currentAssignment.id) {
        return $scope.currentAssignment.$update(function(data) {
          return $rootScope.$broadcast('infoMessage', "Uppdrag uppdaterat");
        }, function(err) {
          return $rootScope.$broadcast('infoMessage', err.status + ": " + err.data.ExceptionMessage);
        });
      } else {
        return $scope.currentAssignment.$save(function(data) {
          $scope.assignments.push($scope.currentAssignment);
          return $rootScope.$broadcast('infoMessage', "Uppdrag sparat");
        }, function(err) {
          return $rootScope.$broadcast('infoMessage', err.status + ": " + err.data.ExceptionMessage);
        });
      }
    };
    $scope.open = function(id) {
      if (id) {
        $scope.currentAssignment = _.find($scope.assignments, function(assignment) {
          return assignment.id === id;
        });
      } else {
        $scope.currentAssignment = new Assignment();
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
