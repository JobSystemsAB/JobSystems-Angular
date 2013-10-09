(function() {
  window.app.controller('HomeApplicationController', [
    '$scope', '$routeParams', 'CategoryService', 'GoogleMapsService', 'TextService', 'AlertService', 'MissionService', function($scope, $routeParams, CategoryService, GoogleMapsService, TextService, AlertService, MissionService) {
      $scope.isAdmin = true;
      $scope.category = [];
      $scope.controllerName = 'homeapplication';
      $scope.currentLang = 'sv';
      $scope.textsOriginal = [
        {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'input-text',
          text: 'input-text'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'employee-description',
          text: 'employee-description'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'video-text',
          text: 'video-text'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'button',
          text: 'button'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'input-firstName-description',
          text: 'input-firstName-description'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'input-lastName-description',
          text: 'input-lastName-description'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'input-phoneNumber-description',
          text: 'input-phoneNumber-description'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'input-emailAddress-description',
          text: 'input-emailAddress-description'
        }
      ];
      $scope.uniteTexts = function(data) {
        var dataGroup, originalGroup;

        originalGroup = _.groupBy($scope.textsOriginal, function(text) {
          return text.elementId;
        });
        dataGroup = _.groupBy(data, function(text) {
          return text.elementId;
        });
        _.each(dataGroup, function(val, key) {
          return originalGroup[key] = val;
        });
        $scope.texts = originalGroup;
        return $scope.textsOriginal = _.map(originalGroup, function(val, key) {
          return val[0];
        });
      };
      CategoryService.getTree().success(function(data, status, headers, config) {
        return $scope.categories = data;
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('danger', 'Misslyckades med att hämta kategorier. Vänligen kontakta kundtjänst om problemet kvarstår.');
      });
      TextService.getAllByControllerAndLanguage($scope.controllerName, 'sv').success(function(data, status, headers, config) {
        return $scope.uniteTexts(data);
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('danger', 'Misslyckades att hämta texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
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
