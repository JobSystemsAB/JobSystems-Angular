(function() {
  window.app.controller('AdminTextsController', [
    '$scope', 'TextService', 'AlertService', function($scope, TextService, AlertService) {
      $scope.tinymceOptions = {
        plugins: ["advlist autolink lists link image charmap print preview hr anchor pagebreak", "searchreplace wordcount visualblocks visualchars code fullscreen", "insertdatetime media nonbreaking save table contextmenu directionality", "emoticons template paste textcolor"]
      };
      TextService.getAllByLanguage('sv').success(function(data, status, headers, config) {
        $scope.texts = _.groupBy(data, function(text) {
          return text.controllerName;
        });
        return console.log($scope.texts);
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('danger', 'Could not load texts.');
      });
      $scope.select = function(text) {
        return $scope.selected = text;
      };
      $scope.update = function() {
        return TextService.put($scope.selected).success(function(data, status, headers, config) {
          return AlertService.addAlert('success', 'Updated the text.');
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Could not save the text.');
        });
      };
      return $scope.unique = function(controller) {
        var ids;

        ids = _.map(controller, function(text) {
          return text.elementId;
        });
        return _.unique(ids).length;
      };
    }
  ]);

}).call(this);
