window.app = angular.module 'HomeApp', ['ui.bootstrap', 'ui.date', 'ui.calendar', 'ui.router', 'ui.tinymce', 'google-maps']

###
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
###

window.app.config ['$stateProvider', '$urlRouterProvider', ($stateProvider, $urlRouterProvider) ->
    
    # For any unmatched url, redirect to index
    $urlRouterProvider.otherwise("");

    $stateProvider
        .state 'index', 
            url: ""
            views:
                'header':
                    templateUrl: '/Angular/Views/MenuView.html'
                'body': 
                    templateUrl: '/Angular/Views/HomeIndexBodyView.html'
                    controller: 'HomeIndexBodyController'
                'footer': 
                    templateUrl: '/Angular/Views/FooterView.html'
                    controller: 'FooterController'
        
        .state 'application',
            url: "/application"
            views:
                'header':
                    templateUrl: '/Angular/Views/MenuView.html'
                'body':
                    templateUrl: '/Angular/Views/HomeApplicationView.html'
                    controller: 'HomeApplicationController'
                'footer': 
                    templateUrl: '/Angular/Views/FooterView.html'
                    controller: 'FooterController'

        # ADMIN
        
        .state 'admin',
            url: "/admin"
            views:
                'header':
                    templateUrl: '/Angular/Views/MenuView.html'
                'body':
                    templateUrl: '/Angular/Views/HomeAdminLoginView.html'
                    controller: 'HomeAdminLoginController'
                'footer': 
                    templateUrl: '/Angular/Views/FooterView.html'
                    controller: 'FooterController'

        .state 'adminServices',
            url: "/admin/services"
            views:
                'body':
                    templateUrl: '/Angular/Views/AdminServicesView.html'
                    controller: 'AdminServicesController'

        .state 'adminTexts',
            url: "/admin/texts"
            views:
                'body':
                    templateUrl: '/Angular/Views/AdminTextsView.html'
                    controller: 'AdminTextsController'

        .state 'adminTestimonials',
            url: "/admin/testimonials"
            views:
                'body':
                    templateUrl: '/Angular/Views/AdminTestimonialsView.html'
                    controller: 'AdminTestimonialsController'

        # BOOKING PAGE

        .state 'book',
            url: "/boka/:serviceName"
            views:
                'header':
                    templateUrl: '/Angular/Views/MenuView.html'
                'body':
                    templateUrl: '/Angular/Views/HomeBookingView.html'
                    controller: 'HomeBookingController'
                'footer': 
                    templateUrl: '/Angular/Views/FooterView.html'
                    controller: 'FooterController'

        # LANDING PAGES
    
        .state 'service',
            url: "/:serviceName"
            views:
                'header':
                    templateUrl: '/Angular/Views/MenuView.html'
                'body':
                    templateUrl: '/Angular/Views/HomeLandingView.html'
                    controller: 'HomeLandingController'
                    
                'footer': 
                    templateUrl: '/Angular/Views/FooterView.html'
                    controller: 'FooterController'        


]
