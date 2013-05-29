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
        return $rootScope.$broadcast('infoMessage', "Kund borttagen");
      }, function(err) {
        return $rootScope.$broadcast('infoMessage', err.status + ": " + err.data.ExceptionMessage);
      });
    };
    $scope.save = function() {
      if ($scope.currentClient.id) {
        return $scope.currentClient.$update(function(data) {
          return $rootScope.$broadcast('infoMessage', "Kund uppdaterad");
        }, function(err) {
          return $rootScope.$broadcast('infoMessage', err.status + ": " + err.data.ExceptionMessage);
        });
      } else {
        return $scope.currentClient.$save(function(data) {
          $scope.clients.push($scope.currentClient);
          return $rootScope.$broadcast('infoMessage', "Kund sparad");
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
