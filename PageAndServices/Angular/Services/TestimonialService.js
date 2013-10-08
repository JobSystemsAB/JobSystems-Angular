(function() {
  window.app.service('TestimonialService', [
    '$http', function($http) {
      this.baseUrl = "/api/testimonial";
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
      this.getAllByLanguage = function(language) {
        return $http({
          url: this.baseUrl + "?language=" + language,
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
          url: this.baseUrl + "/saveTestimonials",
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
