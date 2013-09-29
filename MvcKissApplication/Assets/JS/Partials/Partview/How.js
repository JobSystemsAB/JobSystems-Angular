(function() {
  window.app.controller('HowController', [
    '$scope', 'TextService', function($scope, TextService) {
      var files;

      $scope.text - (files = ['how-title', 'how-short', 'how-read-more']);
      return TextService.getTexts('HowController', 'sv').success(function(data, status, headers, config) {
        $scope.textsOriginal = data;
        return $scope.texts = _.groupBy($scope.textsOriginal, function(text) {
          return text.elementId;
        });
      }).error(function(data, status, headers, config) {
        return console.log(status);
      });
    }
  ]);

}).call(this);
