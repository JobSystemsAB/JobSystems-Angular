(function() {
  window.app = angular.module('HomeApp', ['ui.bootstrap', 'ui.date', 'ui.calendar', 'ui.router', 'google-maps']);

  /*
  window.app.config ['$routeProvider', '$locationProvider', ( $routeProvider,   $locationProvider) ->
  
      $routeProvider.when '/index',
          templateUrl: '/Angular/Views/HomeIndexBodyView.html'
          controller: 'HomeIndexBodyController'
  
      $routeProvider.when '/service/:serviceId',
          templateUrl: '/Angular/Views/HomeLandingView.html'
          controller: 'CategoryController'
          
      $routeProvider.when '/application',
          templateUrl: '/Angular/Views/HomeApplicationView.html'
          controller: 'ApplicationController'
  
      $routeProvider.otherwise
          redirectTo: '/index'
  
  ]
  */


  window.app.config([
    '$stateProvider', '$urlRouterProvider', function($stateProvider, $urlRouterProvider) {
      $urlRouterProvider.otherwise("");
      return $stateProvider.state('index', {
        url: "",
        views: {
          'header': {
            templateUrl: '/Angular/Views/MenuView.html'
          },
          'body': {
            templateUrl: '/Angular/Views/HomeIndexBodyView.html',
            controller: 'HomeIndexBodyController'
          },
          'footer': {
            templateUrl: '/Angular/Views/FooterView.html',
            controller: 'FooterController'
          }
        }
      }).state('application', {
        url: "/application",
        views: {
          'header': {
            templateUrl: '/Angular/Views/MenuView.html'
          },
          'body': {
            templateUrl: '/Angular/Views/HomeApplicationView.html',
            controller: 'HomeApplicationController'
          },
          'footer': {
            templateUrl: '/Angular/Views/FooterView.html',
            controller: 'FooterController'
          }
        }
      }).state('book', {
        url: "/boka/:serviceUrl",
        views: {
          'header': {
            templateUrl: '/Angular/Views/MenuView.html'
          },
          'body': {
            templateUrl: '/Angular/Views/HomeBookingView.html',
            controller: 'HomeBookingController'
          },
          'footer': {
            templateUrl: '/Angular/Views/FooterView.html',
            controller: 'FooterController'
          }
        }
      }).state('admin', {
        url: "/admin",
        views: {
          'header': {
            templateUrl: '/Angular/Views/MenuView.html'
          },
          'body': {
            templateUrl: '/Angular/Views/HomeAdminLoginView.html',
            controller: 'HomeAdminLoginController'
          },
          'footer': {
            templateUrl: '/Angular/Views/FooterView.html',
            controller: 'FooterController'
          }
        }
      }).state('adminServices', {
        url: "/admin/services",
        views: {
          'body': {
            templateUrl: '/Angular/Views/AdminServicesView.html',
            controller: 'AdminServicesController'
          }
        }
      }).state('adminTexts', {
        url: "/admin/texts",
        views: {
          'body': {
            templateUrl: '/Angular/Views/AdminTextsView.html',
            controller: 'AdminTextsController'
          }
        }
      }).state('service', {
        url: "/:serviceName",
        views: {
          'header': {
            templateUrl: '/Angular/Views/MenuView.html'
          },
          'body': {
            templateUrl: '/Angular/Views/HomeLandingView.html',
            controller: 'HomeLandingController'
          },
          'footer': {
            templateUrl: '/Angular/Views/FooterView.html',
            controller: 'FooterController'
          }
        }
      });
      /*
      .state 'barnpassning',
          url: "/barnpassning"
          data:
              serviceName: 'barnpassning'
          views:
              'header':
                  templateUrl: '/Angular/Views/MenuView.html'
              'body':
                  templateUrl: '/Angular/Views/HomeLandingView.html'
                  controller: 'HomeLandingController'
      
              'footer': 
                  templateUrl: '/Angular/Views/FooterView.html'
                  controller: 'FooterController'
      
      .state 'husdjurspassning',
          url: "/husdjurspassning"
          data:
              serviceName: 'husdjurspassninig'
          views:
              'header':
                  templateUrl: '/Angular/Views/MenuView.html'
              'body':
                  templateUrl: '/Angular/Views/HomeLandingView.html'
                  controller: 'HomeLandingController'
              'footer': 
                  templateUrl: '/Angular/Views/FooterView.html'
                  controller: 'FooterController'
      
      .state 'laxhjalp',
          url: "/laxhjalp"
          data:
              serviceName: 'laxhjalp'
          views:
              'header':
                  templateUrl: '/Angular/Views/MenuView.html'
              'body':
                  templateUrl: '/Angular/Views/HomeLandingView.html'
                  controller: 'HomeLandingController'
              'footer': 
                  templateUrl: '/Angular/Views/FooterView.html'
                  controller: 'FooterController'
      
      .state 'snoskottning',
          url: "/snoskottning"
          data:
              serviceName: 'snoskattning'
          views:
              'header':
                  templateUrl: '/Angular/Views/MenuView.html'
              'body':
                  templateUrl: '/Angular/Views/HomeLandingView.html'
                  controller: 'HomeLandingController'
              'footer': 
                  templateUrl: '/Angular/Views/FooterView.html'
                  controller: 'FooterController'
      
      .state 'stadning',
          url: "/stadning"
          data:
              serviceName: 'stadning'
          views:
              'header':
                  templateUrl: '/Angular/Views/MenuView.html'
              'body':
                  templateUrl: '/Angular/Views/HomeLandingView.html'
                  controller: 'HomeLandingController'
              'footer': 
                  templateUrl: '/Angular/Views/FooterView.html'
                  controller: 'FooterController'
      
      .state 'ovrigt',
          url: "/ovrigt"
          data:
              serviceName: 'ovrigt'
          views:
              'header':
                  templateUrl: '/Angular/Views/MenuView.html'
              'body':
                  templateUrl: '/Angular/Views/HomeLandingView.html'
                  controller: 'HomeLandingController'
              'footer': 
                  templateUrl: '/Angular/Views/FooterView.html'
                  controller: 'FooterController'
      */

    }
  ]);

}).call(this);
