(function() {
  window.app.controller('CustomerController', [
    '$scope', 'Customer', function($scope, Customer) {
      $scope.customers = Customer.query();
      return $scope["delete"] = function(customer) {
        customer.$remove();
        return $scope.customers = _.filter($scope.customers, function(cus) {
          return cus.id !== customer.id;
        });
      };
    }
  ]);

}).call(this);
