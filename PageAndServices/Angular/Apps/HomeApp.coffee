window.app = angular.module 'HomeApp', ['ui.bootstrap', 'ui.date', 'ui.calendar', 'ui.router', 'ui.tinymce', 'ngGrid', 'google-maps']

window.app.config ['$stateProvider', '$urlRouterProvider', ($stateProvider, $urlRouterProvider) ->
    
    # For any unmatched url, redirect to index
    $urlRouterProvider.otherwise("");

    $stateProvider
        .state 'home', 
            url: ""
            views:
                'header':
                    templateUrl: '/Angular/Views/Partials/MenuView.html'
                'body': 
                    templateUrl: '/Angular/Views/Home/IndexView.html'
                    controller: 'HomeIndexBodyController'
                'footer': 
                    templateUrl: '/Angular/Views/Partials/FooterView.html'
                    controller: 'FooterController'
        
        .state 'application',
            url: "/application"
            views:
                'header':
                    templateUrl: '/Angular/Views/Partials/MenuView.html'
                'body':
                    templateUrl: '/Angular/Views/Home/ApplicationView.html'
                    controller: 'HomeApplicationController'
                'footer': 
                    templateUrl: '/Angular/Views/Partials/FooterView.html'
                    controller: 'FooterController'

        # ADMIN
        
        .state 'admin',
            url: "/admin"
            views:
                'body':
                    templateUrl: '/Angular/Views/Admin/IndexView.html'
                    controller: 'HomeAdminLoginController'
           
        .state 'adminEmployees',
            url: "/admin/employees"
            views:
                'body':
                    templateUrl: '/Angular/Views/Admin/EmployeesView.html'
                    controller: 'AdminEmployeesController'
                
        .state 'adminLogin',
            url: "/admin/login"
            views:
                'body':
                    templateUrl: '/Angular/Views/Admin/LoginView.html'
                    controller: 'HomeAdminLoginController'
                
        .state 'adminServices',
            url: "/admin/services"
            views:
                'body':
                    templateUrl: '/Angular/Views/Admin/ServicesView.html'
                    controller: 'AdminServicesController'

        .state 'adminTexts',
            url: "/admin/texts"
            views:
                'body':
                    templateUrl: '/Angular/Views/Admin/TextsView2.html'
                    controller: 'AdminTextsController'

        .state 'adminTestimonials',
            url: "/admin/testimonials"
            views:
                'body':
                    templateUrl: '/Angular/Views/Admin/TestimonialsView2.html'
                    controller: 'AdminTestimonialsController'

        .state 'adminInputs',
            url: "/admin/inputs"
            views:
                'body':
                    templateUrl: '/Angular/Views/Admin/ServiceInputsView.html'
                    controller: 'AdminServiceInputsController'

        # BOOKING PAGE

        .state 'book',
            url: "/boka/:serviceName"
            views:
                'header':
                    templateUrl: '/Angular/Views/Partials/MenuView.html'
                'body':
                    templateUrl: '/Angular/Views/Home/BookingView.html'
                    controller: 'HomeBookingController'
                'footer': 
                    templateUrl: '/Angular/Views/Partials/FooterView.html'
                    controller: 'FooterController'

        # LANDING PAGES
    
        .state 'service',
            url: "/:serviceName"
            views:
                'header':
                    templateUrl: '/Angular/Views/Partials/MenuView.html'
                'body':
                    templateUrl: '/Angular/Views/Home/LandingView.html'
                    controller: 'HomeLandingController'
                    
                'footer': 
                    templateUrl: '/Angular/Views/Partials/FooterView.html'
                    controller: 'FooterController'        


]
