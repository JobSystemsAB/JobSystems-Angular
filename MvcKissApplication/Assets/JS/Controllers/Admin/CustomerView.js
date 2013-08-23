(function() {
  window.app.controller('CustomerViewController', [
    '$scope', '$routeParams', 'PrivateCustomer', 'CompanyCustomer', function($scope, $routeParams, PrivateCustomer, CompanyCustomer) {
      $scope.input = {};
      $scope.save = function() {
        if ($scope.isNotNew()) {
          return $scope.input.$update();
        } else {
          if ($scope.input.type === 'PrivateCustomer') {
            $scope.input = new PrivateCustomer($scope.input);
          } else {
            $scope.input = new CompanyCustomer($scope.input);
          }
          $scope.input.$save();
          return console.log($scope.input);
        }
      };
      $scope["delete"] = function() {
        return $scope.input.$remove();
      };
      $scope.isNotNew = function() {
        return $scope.input.id !== '0';
      };
      $scope.isPrivate = function() {
        return $scope.input.type === 'PrivateCustomer';
      };
      $scope.input.id = $routeParams.customerId;
      $scope.input.type = $routeParams.customerType;
      if ($scope.isNotNew()) {
        if ($scope.input.type === 'PrivateCustomer') {
          return $scope.input = PrivateCustomer.get({
            id: $scope.input.id
          });
        } else {
          return $scope.input = CompanyCustomer.get({
            id: $scope.input.id
          });
        }
      }
    }
  ]);

}).call(this);
