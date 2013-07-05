(function() {
  window.app = angular.module('PerformerApp', ['services', 'ui.bootstrap', 'ui.date']);

  window.app.config(function($routeProvider, $locationProvider) {
    $routeProvider.when('/timereport', {
      templateUrl: 'Assets/angular/partials/performer/timereport.html',
      controller: 'PerformerTimereportController'
    });
    $routeProvider.when('/timefree', {
      templateUrl: 'Assets/angular/partials/performer/timefree.html',
      controller: 'PerformerTimefreeController'
    });
    return $routeProvider.otherwise({
      redirectTo: '/timereport'
    });
  });

  window.app.service('CalendarService', [
    '$rootScope', function($rootScope) {
      var date;

      date = new Date();
      return {
        getDate: function() {
          return date;
        },
        setDate: function(value) {
          date = value;
          return $rootScope.$broadcast('CalendarService.update', date);
        },
        getFreeTimes: function(performerId) {
          return $rootScope.$broadcast('CalendarService.getFreeTimes', performerId);
        },
        ready: function() {
          return $rootScope.$broadcast('CalendarService.ready');
        }
      };
    }
  ]);

}).call(this);
