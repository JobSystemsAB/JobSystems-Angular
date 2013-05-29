(function() {
  var app;

  app = angular.module('MainPageApp', ['services', 'ui.bootstrap', 'ui.date']);

  app.config(function($routeProvider, $locationProvider) {
    $routeProvider.when('/', {
      templateUrl: 'Assets/js/angular/partials/main-page.html'
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
