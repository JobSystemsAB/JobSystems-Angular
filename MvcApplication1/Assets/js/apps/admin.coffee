window.app = angular.module 'AdminApp', ['services', 'ui.bootstrap', 'ui.date']

window.app.config ($routeProvider, $locationProvider) ->

    $routeProvider.when '/approve',
        templateUrl: 'Assets/js/Partials/Admin/approve-employee.html'
        controller: 'ApproveEmployeeController'

    $routeProvider.otherwise
        redirectTo: '/approve'