(function() {
  window.app.controller('TestimonialsController', [
    '$scope', 'AlertService', 'TextService', 'TestimonialService', function($scope, AlertService, TextService, TestimonialService) {
      var files;

      $scope.text - (files = ['testimonials-title']);
      TextService.getAllByControllerAndLanguage('TestimonialsController', 'sv').success(function(data, status, headers, config) {
        $scope.textsOriginal = data;
        return $scope.texts = _.groupBy($scope.textsOriginal, function(text) {
          return text.elementId;
        });
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('danger', 'Misslyckades att hämta texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
      });
      TestimonialService.getAllByLanguage('sv').success(function(data, status, headers, config) {
        return $scope.testimonials = data;
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('danger', 'Misslyckades att spara referenser, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
      });
      return $scope.save = function() {
        TextService.postAll($scope.textsOriginal).success(function(data, status, headers, config) {
          return AlertService.addAlert('success', 'Tester sparades.');
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Misslyckades att spara texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
        });
        return TestimonialService.postAll($scope.testimonials).success(function(data, status, headers, config) {
          return AlertService.addAlert('success', 'Referenser sparades.');
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Misslyckades att spara referenserna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
        });
      };
    }
  ]);

}).call(this);
