(function() {
  var app;

  app = angular.module('GardenApp', ['services', 'ui.bootstrap', 'ui.date']);

  app.config(function($routeProvider, $locationProvider) {
    $routeProvider.when('/', {
      templateUrl: 'Assets/angular/partials/garden/index.html',
      controller: 'GardenIndexController'
    });
    return $routeProvider.otherwise({
      redirectTo: '/404'
    });
  });

  app.directive('autoComplete', function($timeout) {
    return function(scope, iElement, iAttrs) {
      return iElement.autocomplete({
        source: scope[iAttrs.uiItems],
        select: function() {
          return $timeout(function() {
            return iElement.trigger('input');
          }, 0);
        }
      });
    };
  });

}).call(this);
