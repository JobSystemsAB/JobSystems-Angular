(function() {
  window.app.controller('TestimonialsController', [
    '$scope', 'TextService', 'TestimonialService', function($scope, TextService, TestimonialService) {
      var files;

      $scope.text - (files = ['testimonials-title']);
      TextService.getTexts('TestimonialsController', 'sv').success(function(data, status, headers, config) {
        $scope.textsOriginal = data;
        $scope.texts = _.groupBy($scope.textsOriginal, function(text) {
          return text.elementId;
        });
        return console.log(status);
      }).error(function(data, status, headers, config) {
        return console.log(status);
      });
      TestimonialService.getTestimonials('sv').success(function(data, status, headers, config) {
        $scope.testimonials = data;
        return console.log(status);
      }).error(function(data, status, headers, config) {
        return console.log(status);
      });
      return $scope.save = function() {
        TextService.saveTexts($scope.textsOriginal).success(function(data, status, headers, config) {
          return console.log(status);
        }).error(function(data, status, headers, config) {
          return console.log(status);
        });
        return TestimonialService.saveTestimonials($scope.testimonials).success(function(data, status, headers, config) {
          return console.log(status);
        }).error(function(data, status, headers, config) {
          return console.log(status);
        });
      };
    }
  ]);

}).call(this);
