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
        $rootScope.$broadcast('infoMessage', "Administrator borttagen");
        return $scope.close();
      }, function(err) {
        return $rootScope.$broadcast('infoMessage', err.status + ": " + err.data.ExceptionMessage);
      });
    };
    $scope.save = function() {
      if ($scope.currentAdmin.newPassword !== null && $scope.currentAdmin.newPassword !== '') {
        $scope.currentAdmin.newPassword = String(CryptoJS.SHA3($scope.currentAdmin.newPassword, {
          outputLength: 256
        }));
      }
      if ($scope.currentAdmin.id) {
        return $scope.currentAdmin.$update(function(data) {
          $rootScope.$broadcast('infoMessage', "Administrator uppdaterad");
          return $scope.close();
        }, function(err) {
          return $rootScope.$broadcast('infoMessage', err.status + ": " + err.data.ExceptionMessage);
        });
      } else {
        return $scope.currentAdmin.$save(function(data) {
          $scope.administrators.push($scope.currentAdmin);
          $rootScope.$broadcast('infoMessage', "Administrator sparad");
          return $scope.close();
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
