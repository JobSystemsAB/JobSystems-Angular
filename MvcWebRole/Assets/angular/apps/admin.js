(function() {
  var app;

  app = angular.module('AdminApp', ['services', 'ui.bootstrap', 'ui.date']);

  app.config(function($routeProvider, $locationProvider) {
    $routeProvider.when('/login', {
      templateUrl: 'Assets/angular/partials/admin/login.html',
      controller: 'AdminLoginController'
    });
    $routeProvider.when('/administrators', {
      templateUrl: 'Assets/angular/partials/database/administrator.html',
      controller: 'DatabaseAdministratorController'
    });
    $routeProvider.when('/performers', {
      templateUrl: 'Assets/angular/partials/database/performer.html',
      controller: 'DatabasePerformerController'
    });
    $routeProvider.when('/assignments', {
      templateUrl: 'Assets/angular/partials/database/assignment.html',
      controller: 'DatabaseAssignmentController'
    });
    $routeProvider.when('/timereports', {
      templateUrl: 'Assets/angular/partials/database/timereport.html',
      controller: 'DatabasePerformerTimeReportController'
    });
    $routeProvider.when('/clients', {
      templateUrl: 'Assets/angular/partials/database/client.html',
      controller: 'DatabaseClientController'
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
        if (next.templateUrl !== "Assets/angular/partials/admin/login.html") {
          return $location.path("/login");
        }
      }
    });
  });

}).call(this);
