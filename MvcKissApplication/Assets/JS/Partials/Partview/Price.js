(function() {
  window.app.controller('PriceController', [
    '$scope', 'TextService', function($scope, TextService) {
      var files;

      $scope.text - (files = ['price-title', 'price-short', 'price-more']);
      TextService.getTexts('PriceController', 'sv').success(function(data, status, headers, config) {
        $scope.textsOriginal = data;
        return $scope.texts = _.groupBy($scope.textsOriginal, function(text) {
          return text.elementId;
        });
      }).error(function(data, status, headers, config) {
        return console.log(status);
      });
      return $scope.save = function() {
        return TextService.saveTexts($scope.textsOriginal).success(function(data, status, headers, config) {
          return console.log(status);
        }).error(function(data, status, headers, config) {
          return console.log(status);
        });
      };
    }
  ]);

}).call(this);
