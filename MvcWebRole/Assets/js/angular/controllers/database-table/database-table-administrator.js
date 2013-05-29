(function() {
  window.DatabaseTableAdministratorsController = function($scope, $rootScope, Administrator) {
    $scope.administrators = Administrator.query();
    $scope.orderOption = 'id';
    $scope.sort = function(newOrderOption) {
      return $scope.orderOption = newOrderOption;
    };
    $scope["delete"] = function(id) {
      var admin;

      admin = _.find($scope.administrators, function(admin) {
        return admin.id === id;
      });
      return admin.$delete(function(data) {
        $scope.administrators = _.filter($scope.administrators, function(admin) {
          return admin.id !== id;
        });
        return $rootScope.$broadcast('infoMessage', "Administrator borttagen");
      }, function(err) {
        return $rootScope.$broadcast('infoMessage', err.status + ": " + err.data.ExceptionMessage);
      });
    };
    $scope.save = function() {
      $scope.currentAdmin.newPassword = String(CryptoJS.SHA3($scope.currentAdmin.newPassword, {
        outputLength: 256
      }));
      console.log($scope.currentAdmin.newPassword);
      if ($scope.currentAdmin.id) {
        return $scope.currentAdmin.$update(function(data) {
          return $rootScope.$broadcast('infoMessage', "Administrator uppdaterad");
        }, function(err) {
          return $rootScope.$broadcast('infoMessage', err.status + ": " + err.data.ExceptionMessage);
        });
      } else {
        return $scope.currentAdmin.$save(function(data) {
          $scope.administrators.push($scope.currentAdmin);
          return $rootScope.$broadcast('infoMessage', "Administrator sparad");
        }, function(err) {
          return $rootScope.$broadcast('infoMessage', err.status + ": " + err.data.ExceptionMessage);
        });
      }
    };
    $scope.open = function(id) {
      if (id) {
        $scope.currentAdmin = _.find($scope.administrators, function(admin) {
          return admin.id === id;
        });
      } else {
        $scope.currentAdmin = new Administrator();
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
