(function() {
  window.app = angular.module('AdminApp', ['services', 'ui.bootstrap', 'ui.date']);

  window.app.config(function($routeProvider, $locationProvider) {
    $routeProvider.when('/approve', {
      templateUrl: 'Assets/js/Partials/Admin/approve-employee.html',
      controller: 'ApproveEmployeeController'
    });
    return $routeProvider.otherwise({
      redirectTo: '/approve'
    });
  });

}).call(this);
