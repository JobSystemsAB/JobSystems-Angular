(function() {
  window.app.service('CategoryService', [
    '$http', function($http) {
      this.baseUrl = "/api/category";
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
      this.getTree = function() {
        return $http({
          url: this.baseUrl + '/gettree',
          method: "GET"
        });
      };
      this.getInputs = function(id) {
        return $http({
          url: this.baseUrl + '/' + id + '/categoryinputs',
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
      this.postAll = function(models) {
        return $http({
          url: "/api/category/savecategories",
          method: "POST",
          data: models
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
