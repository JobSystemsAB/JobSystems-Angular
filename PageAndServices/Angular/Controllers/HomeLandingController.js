(function() {
  window.app.controller('HomeLandingController', [
    '$scope', '$state', 'TestimonialService', 'TextService', function($scope, $state, TestimonialService, TextService) {
      google.maps.visualRefresh = true;
      angular.extend($scope, {
        center: {
          latitude: 59.344679,
          longitude: 18.071171
        },
        markers: [
          {
            latitude: 59.344679,
            longitude: 18.071171
          }
        ],
        zoom: 15
      });
      $scope.controllerName = 'homelanding' + $state.current.data.serviceName;
      $scope.textsOriginal = [
        {
          controllerName: $scope.controllerName,
          elementId: 'title-window-text',
          text: 'title-window-text'
        }, {
          controllerName: $scope.controllerName,
          elementId: 'title-window-button',
          text: 'title-window-button'
        }, {
          controllerName: $scope.controllerName,
          elementId: 'price-title',
          text: 'price-title'
        }, {
          controllerName: $scope.controllerName,
          elementId: 'price-short',
          text: 'price-short'
        }, {
          controllerName: $scope.controllerName,
          elementId: 'price-read-more',
          text: 'price-read-more'
        }, {
          controllerName: $scope.controllerName,
          elementId: 'why-title',
          text: 'why-title'
        }, {
          controllerName: $scope.controllerName,
          elementId: 'why-short',
          text: 'why-short'
        }, {
          controllerName: $scope.controllerName,
          elementId: 'why-read-more',
          text: 'why-read-more'
        }, {
          controllerName: $scope.controllerName,
          elementId: 'about-title',
          text: 'about-title'
        }, {
          controllerName: $scope.controllerName,
          elementId: 'about-short',
          text: 'about-short'
        }, {
          controllerName: $scope.controllerName,
          elementId: 'about-read-more',
          text: 'about-read-more'
        }, {
          controllerName: $scope.controllerName,
          elementId: 'map-title',
          text: 'map-title'
        }, {
          controllerName: $scope.controllerName,
          elementId: 'map-short',
          text: 'map-short'
        }, {
          controllerName: $scope.controllerName,
          elementId: 'map-address',
          text: 'map-address'
        }, {
          controllerName: $scope.controllerName,
          elementId: 'map-phone-number',
          text: 'map-phone-number'
        }, {
          controllerName: $scope.controllerName,
          elementId: 'map-email',
          text: 'map-email'
        }, {
          controllerName: $scope.controllerName,
          elementId: 'testimonials-title',
          text: 'testimonials-title'
        }, {
          controllerName: $scope.controllerName,
          elementId: 'book-now-button',
          text: 'book-now-button'
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
      TextService.getAllByControllerAndLanguage($scope.controllerName, 'sv').success(function(data, status, headers, config) {
        return $scope.uniteTexts(data);
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('danger', 'Misslyckades att hämta texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
      });
      TestimonialService.getAllByLanguage('sv').success(function(data, status, headers, config) {
        return $scope.testimonials = data;
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('danger', 'Misslyckades att spara referenser, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
      });
      $scope.save = function() {
        return TextService.postAll($scope.textsOriginal).success(function(data, status, headers, config) {
          return AlertService.addAlert('success', 'Texter sparade.');
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Misslyckades att spara texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
        });
      };
      return $scope.goToBooking = function() {
        return $state.go('book', {
          serviceUrl: $state.current.data.serviceName
        });
      };
    }
  ]);

}).call(this);
