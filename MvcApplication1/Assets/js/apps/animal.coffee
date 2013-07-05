window.app = angular.module 'AnimalApp', ['services', 'ui.bootstrap', 'ui.date']

window.app.config ($routeProvider, $locationProvider) ->

    $routeProvider.when '/index',
        templateUrl: 'Assets/js/Partials/Animal/index.html'
        controller: 'AnimalIndexController'

    $routeProvider.when '/application',
        templateUrl: 'Assets/js/Partials/Animal/employee-application.html'
        controller: 'EmployeeApplicationController'

    $routeProvider.otherwise
        redirectTo: '/index'