(function() {
  window.app.service('AdministratorService', [
    '$http', function($http) {
      return this.getAdministrator = function(email, password) {
        return $http({
          url: "/api/administrator/getlogin?email=" + email + "&password=" + password,
          method: "GET"
        });
      };
    }
  ]);

}).call(this);
