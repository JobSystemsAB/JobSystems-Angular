(function() {
  var app;

  app = angular.module('GardenPageApp', ['services', 'ui.bootstrap', 'ui.date']);

  app.config(function($routeProvider, $locationProvider) {
    $routeProvider.when('/', {
      templateUrl: 'Assets/js/angular/partials/garden-page/garden.html',
      controller: 'GardenInputFormCtrl'
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
