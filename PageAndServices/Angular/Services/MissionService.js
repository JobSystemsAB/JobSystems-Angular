(function() {
  window.app.service('MissionService', [
    '$http', function($http) {
      this.baseUrl = "/api/mission";
      this["delete"] = function(id) {
        return $http({
          utl: this.baseUrl + "/" + id,
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
      this.getEmployed = function() {
        return $http({
          url: this.baseUrl + "/employed",
          method: "GET"
        });
      };
      this.getUnemployed = function() {
        return $http({
          url: this.baseUrl + "/unemployed",
          method: "GET"
        });
      };
      this.getDisabled = function() {
        return $http({
          url: this.baseUrl + "/disabled",
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
