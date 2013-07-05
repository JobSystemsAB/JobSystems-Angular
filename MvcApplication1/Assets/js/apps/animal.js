(function() {
  window.app = angular.module('AnimalApp', ['services', 'ui.bootstrap', 'ui.date']);

  window.app.config(function($routeProvider, $locationProvider) {
    $routeProvider.when('/index', {
      templateUrl: 'Assets/js/Partials/Animal/index.html',
      controller: 'AnimalIndexController'
    });
    $routeProvider.when('/application', {
      templateUrl: 'Assets/js/Partials/Animal/employee-application.html',
      controller: 'EmployeeApplicationController'
    });
    return $routeProvider.otherwise({
      redirectTo: '/index'
    });
  });

}).call(this);
