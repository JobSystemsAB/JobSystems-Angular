(function() {
  window.DatabaseTableClientController = function($scope, $rootScope, Client) {
    $scope.clients = Client.query();
    $scope.orderOption = 'id';
    $scope.sort = function(newOrderOption) {
      return $scope.orderOption = newOrderOption;
    };
    $scope["delete"] = function(id) {
      var client;

      client = _.find($scope.clients, function(client) {
        return client.id === id;
      });
      return client.$delete(function(data) {
        $scope.clients = _.filter($scope.clients, function(client) {
          return client.id !== id;
        });
        $rootScope.$broadcast('infoMessage', "Kund borttagen");
        return $scope.close();
      }, function(err) {
        return $rootScope.$broadcast('infoMessage', err.status + ": " + err.data.ExceptionMessage);
      });
    };
    $scope.save = function() {
      if ($scope.currentClient.id) {
        return $scope.currentClient.$update(function(data) {
          $rootScope.$broadcast('infoMessage', "Kund uppdaterad");
          return $scope.close();
        }, function(err) {
          return $rootScope.$broadcast('infoMessage', err.status + ": " + err.data.ExceptionMessage);
        });
      } else {
        return $scope.currentClient.$save(function(data) {
          $scope.clients.push($scope.currentClient);
          $rootScope.$broadcast('infoMessage', "Kund sparad");
          return $scope.close();
        }, function(err) {
          return $rootScope.$broadcast('infoMessage', err.status + ": " + err.data.ExceptionMessage);
        });
      }
    };
    $scope.open = function(id) {
      if (id) {
        $scope.currentClient = _.find($scope.currentClient, function(client) {
          return client.id === id;
        });
      } else {
        $scope.currentClient = new Client();
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
