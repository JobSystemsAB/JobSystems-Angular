(function() {
  window.app.controller('HomeApplicationController', [
    '$scope', '$routeParams', 'CategoryService', 'GoogleMapsService', 'TextService', 'AlertService', 'MissionService', function($scope, $routeParams, CategoryService, GoogleMapsService, TextService, AlertService, MissionService) {
      $scope.category = [];
      CategoryService.getTree().success(function(data, status, headers, config) {
        return $scope.categories = data;
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('danger', 'Misslyckades med att hämta kategorier. Vänligen kontakta kundtjänst om problemet kvarstår.');
      });
      TextService.getAllByControllerAndLanguage('HomeApplicationController', 'sv').success(function(data, status, headers, config) {
        $scope.textsOriginal = data;
        return $scope.texts = _.groupBy($scope.textsOriginal, function(text) {
          return text.elementId;
        });
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('danger', 'Misslyckades med att hämta texter. Vänligen kontakta kundtjänst om problemet kvarstår.');
      });
      $scope.categoryClicked = function(child, level) {
        if (!child.data.checked) {
          child.data.checked = true;
        } else {
          child.data.checked = false;
        }
        $scope.category[level] = child;
        $scope.category[level + 1] = null;
        $scope.category[level + 2] = null;
        return $scope.checkCategory($scope.category[1]);
      };
      $scope.checkCategory = function(topParent) {
        return _.each($scope.categories.children, function(child) {
          if (child.data.id !== topParent.data.id) {
            child.data.checked = false;
            return _.each(child.children, function(child2) {
              child2.data.checked = false;
              return _.each(child2.children, function(child3) {
                return child3.data.checked = false;
              });
            });
          } else {
            child.data.checked = true;
            return _.each(child.children, function(child2) {
              if (child2.children.length > 0) {
                return child2.data.checked = _.find(child2.children, function(child3) {
                  return child3.data.checked === true;
                });
              }
            });
          }
        });
      };
      return $scope.save = function() {
        return TextService.postAll($scope.textsOriginal).success(function(data, status, headers, config) {
          return AlertService.addAlert('success', 'Texter sparade.');
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Misslyckades att spara texterna, prova igen och kontakta en tekniker om problemet kvarstår.');
        });
      };
    }
  ]);

}).call(this);
