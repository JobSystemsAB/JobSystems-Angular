(function() {
  var app;

  app = angular.module('PerformerPortalApp', ['services', 'ui.bootstrap', 'ui.date']);

  app.config(function($routeProvider, $locationProvider) {
    $routeProvider.when('/timereport', {
      templateUrl: 'Assets/js/angular/partials/performer-portal/timereport.html',
      controller: 'PerformerTimereportController'
    });
    return $routeProvider.otherwise({
      redirectTo: '/timereport'
    });
  });

}).call(this);
