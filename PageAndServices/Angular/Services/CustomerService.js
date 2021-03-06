(function() {
  window.app.service('CustomerService', [
    '$http', function($http) {
      this.baseUrl = "/api/customer";
      this["delete"] = function(id) {
        return $http({
          url: this.baseUrl + "/" + id,
          method: "DELETE"
        });
      };
      this.get = function(id) {
        return $http({
          url: this.baseUrl + "/" + id,
          method: "GET"
        });
      };
      this.getAll = function() {
        return $http({
          url: this.baseUrl,
          method: "GET"
        });
      };
      this.login = function(email, password) {
        return $http({
          url: this.baseUrl + "/getlogin?email=" + email + "&password=" + password,
          method: "GET"
        });
      };
      this.post = function(model) {
        return $http({
          url: this.baseUrl,
          method: "POST",
          data: model
        });
      };
      return this.put = function(model) {
        return $http({
          url: this.baseUrl,
          method: "PUT",
          data: model
        });
      };
    }
  ]);

}).call(this);
