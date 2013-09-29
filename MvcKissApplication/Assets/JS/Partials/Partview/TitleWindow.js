(function() {
  window.app.controller('TitleWindowController', [
    '$scope', '$stateParams', 'TextService', function($scope, $stateParams, TextService) {
      var files;

      $scope.text - (files = ['title-window-text', 'title-window-book-text', 'title-window-button']);
      $scope.currentCategoryId = $stateParams.serviceId;
      TextService.getTexts('TitleWindowController', 'sv').success(function(data, status, headers, config) {
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
