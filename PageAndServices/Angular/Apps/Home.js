(function() {
  window.app = angular.module('HomeApp', ['ui.bootstrap', 'ui.date', 'ui.calendar', 'ui.router', 'google-maps']);

  window.app.config([
    '$stateProvider', '$urlRouterProvider', function($stateProvider, $urlRouterProvider) {
      $urlRouterProvider.otherwise("");
      return $stateProvider.state('index', {
        url: "",
        views: {
          'footer': {
            templateUrl: ""
          },
          'body': {
            templateUrl: "/Angular/Views/HomeIndexBodyView.html",
            controller: 'HomeIndexBodyController'
          }
        }
      }).state('service', {
        url: "/service/:serviceId",
        templateUrl: "/Angular/Views/HomeLandingView.html",
        controller: 'HomeIndexBodyController'
      }).state('book', {
        url: "/book/:serviceId",
        templateUrl: "/Angular/Views/HomeBookingView.html"
      }).state('application', {
        url: "/application",
        templateUrl: "/Angular/Views/HomeApplicationView.html"
      }).state('admin', {
        url: "/admin",
        templateUrl: "/Angular/Views/homeAdminLoginView.html"
      });
    }
  ]);

}).call(this);
