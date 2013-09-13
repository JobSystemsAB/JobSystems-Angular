(function() {
  window.app.service('CategoryService', [
    '$http', function($http) {
      this.getCategoryInputs = function(categoryId) {
        return $http({
          url: "/api/category/" + categoryId + "/categoryinputs",
          method: "GET"
        });
      };
      return this.getTree = function() {
        return $http({
          url: "/api/category/gettree",
          method: "GET"
        });
      };
    }
  ]);

}).call(this);
