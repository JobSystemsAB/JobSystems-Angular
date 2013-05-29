(function() {
  window.DatabaseTablePerformerController = function($scope, $rootScope, Performer) {
    $scope.performers = Performer.query();
    $scope.dateOptions = {
      changeYear: true,
      changeMonth: true,
      yearRange: '1900:-0'
    };
    $scope.orderOption = 'id';
    $scope.sort = function(newOrderOption) {
      return $scope.orderOption = newOrderOption;
    };
    $scope["delete"] = function(id) {
      var performer;

      performer = _.find($scope.performers, function(performer) {
        return performer.id === id;
      });
      return performer.$delete(function(data) {
        $scope.performers = _.filter($scope.performers, function(performer) {
          return performer.id !== id;
        });
        $rootScope.$broadcast('infoMessage', "Uförare borttagen");
        return $scope.close();
      }, function(err) {
        return $rootScope.$broadcast('infoMessage', err.status + ": " + err.data.ExceptionMessage);
      });
    };
    $scope.save = function() {
      $scope.currentPerformer.password = String(CryptoJS.SHA3($scope.currentPerformer.password, {
        outputLength: 256
      }));
      if ($scope.currentPerformer.id) {
        return $scope.currentPerformer.$update(function(data) {
          $rootScope.$broadcast('infoMessage', "Utförare uppdaterad");
          return $scope.close();
        }, function(err) {
          return $rootScope.$broadcast('infoMessage', err.status + ": " + err.data.ExceptionMessage);
        });
      } else {
        return $scope.currentPerformer.$save(function(data) {
          $scope.performers.push($scope.currentPerformer);
          $rootScope.$broadcast('infoMessage', "Utförare sparad");
          return $scope.close();
        }, function(err) {
          return $rootScope.$broadcast('infoMessage', err.status + ": " + err.data.ExceptionMessage);
        });
      }
    };
    $scope.open = function(id) {
      if (id) {
        $scope.currentPerformer = _.find($scope.performers, function(performer) {
          return performer.id === id;
        });
      } else {
        $scope.currentPerformer = new Performer();
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
