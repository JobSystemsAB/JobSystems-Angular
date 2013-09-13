window.app = angular.module 'HomeApp', ['services', 'ui.bootstrap', 'ui.date', 'ui.calendar', 'google-maps']

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