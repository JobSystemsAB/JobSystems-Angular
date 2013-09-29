(function() {
  window.app.service('TestimonialService', [
    '$http', function($http) {
      this.getTestimonials = function(language) {
        return $http({
          url: "/api/testimonial?language=" + language,
          method: "GET"
        });
      };
      return this.saveTestimonials = function(testimonials) {
        return $http({
          url: "/api/testimonial/saveTestimonials",
          method: "POST",
          data: testimonials
        });
      };
    }
  ]);

}).call(this);
