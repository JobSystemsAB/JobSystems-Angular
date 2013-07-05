(function() {
  window.app = angular.module('PerformerPortalApp', ['services', 'ui.bootstrap', 'ui.date']);

  window.app.config(function($routeProvider, $locationProvider) {
    $routeProvider.when('/timereport', {
      templateUrl: 'Assets/angular/partials/performer-portal/timereport.html',
      controller: 'PerformerTimereportController'
    });
    $routeProvider.when('/timefree', {
      templateUrl: 'Assets/angular/partials/performer-portal/timefree.html',
      controller: 'PerformerTimefreeController'
    });
    return $routeProvider.otherwise({
      redirectTo: '/timereport'
    });
  });

  window.app.service('calendarService', function() {
    var date;

    date = new Date();
    return {
      getDate: function() {
        return date;
      },
      setDate: function(value) {
        return date = value;
      }
    };
  });

}).call(this);
