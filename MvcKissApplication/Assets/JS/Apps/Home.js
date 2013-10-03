(function() {
  window.app = angular.module('HomeApp', ['services', 'ui.bootstrap', 'ui.date', 'ui.calendar', 'ui.router', 'google-maps']);

  /*
  window.app.config ($routeProvider, $locationProvider) ->
  
      $routeProvider.when '/index',
          templateUrl: '/Assets/JS/Partials/Home/Index.html'
          controller: 'HomeIndexController'
  
      $routeProvider.when '/category/:categoryId',
          templateUrl: '/Assets/JS/Partials/Home/Category.html'
          controller: 'CategoryController'
          
      $routeProvider.when '/application',
          templateUrl: '/Assets/JS/Partials/Home/Application.html'
          controller: 'ApplicationController'
  
      $routeProvider.otherwise
          redirectTo: '/index'
  */


  window.app.config([
    '$stateProvider', '$urlRouterProvider', function($stateProvider, $urlRouterProvider) {
      $urlRouterProvider.otherwise("");
      return $stateProvider.state('index', {
        url: "",
        templateUrl: "/assets/js/partials/view/homeindexbody.html",
        controller: 'HomeIndexBodyController'
      }).state('service', {
        url: "/service/:serviceId",
        templateUrl: "/assets/js/partials/view/homelandingpage.html",
        controller: 'HomeIndexBodyController'
      }).state('book', {
        url: "/book/:serviceId",
        templateUrl: "/assets/js/partials/view/homebookingpage.html"
      }).state('application', {
        url: "/application",
        templateUrl: "/assets/js/partials/view/homeapplication.html"
      }).state('admin', {
        url: "/admin",
        templateUrl: "/assets/js/partials/view/homeadminlogin.html"
      });
    }
  ]);

}).call(this);
