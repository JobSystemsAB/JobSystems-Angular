(function() {
  window.app.service('CategoryService', [
    '$http', function($http) {
      this.getCategoryInputs = function(categoryId) {
        return $http({
          url: "/api/category/" + categoryId + "/categoryinputs",
          method: "GET"
        });
      };
      this.getAll = function() {
        return $http({
          url: "/api/category",
          method: "GET"
        });
      };
      this.getTree = function() {
        return $http({
          url: "/api/category/gettree",
          method: "GET"
        });
      };
      return this.saveCategories = function(categories) {
        return $http({
          url: "/api/category/savecategories",
          method: "POST",
          data: categories
        });
      };
    }
  ]);

}).call(this);
