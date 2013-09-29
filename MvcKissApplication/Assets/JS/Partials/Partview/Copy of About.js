(function() {
  window.app.controller('AboutController', [
    '$scope', 'TextService', function($scope, TextService) {
      var files;

      $scope.text - (files = ['about-short', 'read-more']);
      return TextService.getTexts('AboutController', 'sv').success(function(data, status, headers, config) {
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
