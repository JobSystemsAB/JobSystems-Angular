app = angular.module 'PerformerPortalApp', ['services', 'ui.bootstrap', 'ui.date']

app.config ($routeProvider, $locationProvider) ->

    $routeProvider.when '/timereport',
        templateUrl: 'Assets/js/angular/partials/performer-portal/timereport.html'
        controller: 'PerformerTimereportController'

    $routeProvider.otherwise
        redirectTo: '/timereport'