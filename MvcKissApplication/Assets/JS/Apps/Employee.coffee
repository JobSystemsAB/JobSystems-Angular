window.app = angular.module 'EmployeeApp', ['services', 'ui.bootstrap', 'ui.date', 'google-maps']

window.app.config ($routeProvider, $locationProvider) ->

    $routeProvider.when '/index',
        templateUrl: '/Assets/JS/Partials/Employee/Index.html'
        controller: 'EmployeeIndexController'

    $routeProvider.when '/profile',
        templateUrl: '/Assets/JS/Partials/Employee/Profile.html'
        controller: 'EmployeeController'
        
    $routeProvider.otherwise
        redirectTo: '/index'