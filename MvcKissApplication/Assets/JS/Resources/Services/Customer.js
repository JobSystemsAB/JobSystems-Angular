(function() {
  window.app.service('CustomerService', [
    '$http', function($http) {
      return this.getCustomer = function(email, password) {
        return $http({
          url: "/api/customer/getlogin?email=" + email + "&password=" + password,
          method: "GET"
        });
      };
    }
  ]);

}).call(this);
