(function() {
  var app;

  app = angular.module('AdminPortalApp', ['services', 'ui.bootstrap', 'ui.date']);

  app.config(function($routeProvider, $locationProvider) {
    $routeProvider.when('/login', {
      templateUrl: 'Assets/js/angular/partials/admin-portal/login.html'
    });
    $routeProvider.when('/administrators', {
      templateUrl: 'Assets/js/angular/partials/database-table/administrator.html'
    });
    $routeProvider.when('/performers', {
      templateUrl: 'Assets/js/angular/partials/database-table/performer.html'
    });
    $routeProvider.when('/assignments', {
      templateUrl: 'Assets/js/angular/partials/database-table/assignment.html'
    });
    $routeProvider.when('/timereports', {
      templateUrl: 'Assets/js/angular/partials/database-table/timereport.html'
    });
    $routeProvider.when('/clients', {
      templateUrl: 'Assets/js/angular/partials/database-table/client.html'
    });
    return $routeProvider.otherwise({
      redirectTo: '/404'
    });
  });

  app.run(function($rootScope, $location) {
    $rootScope.auth = {
      loggedIn: localStorage.getItem('auth.loggedIn' === "true"),
      username: localStorage.getItem('auth.username'),
      userId: parseInt(localStorage.getItem('auth.userId')),
      accessToken: localStorage.getItem('auth.accessToken')
    };
    return $rootScope.$on("$routeChangeStart", function(event, next, current) {
      if (!$rootScope.auth.loggedIn) {
        if (next.templateUrl !== "Assets/js/angular/partials/admin-login.html") {
          return $location.path("/login");
        }
      }
    });
  });

}).call(this);
