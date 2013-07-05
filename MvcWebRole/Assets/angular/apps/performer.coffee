window.app = angular.module 'PerformerApp', ['services', 'ui.bootstrap', 'ui.date']

window.app.config ($routeProvider, $locationProvider) ->

    $routeProvider.when '/timereport',
        templateUrl: 'Assets/angular/partials/performer/timereport.html'
        controller: 'PerformerTimereportController'

    $routeProvider.when '/timefree',
        templateUrl: 'Assets/angular/partials/performer/timefree.html'
        controller: 'PerformerTimefreeController'

    $routeProvider.otherwise
        redirectTo: '/timereport'

window.app.service('CalendarService', [ '$rootScope', ($rootScope) ->
    date = new Date()
    
    return {
        getDate: ->
            return date
        setDate: (value) ->
            date = value
            $rootScope.$broadcast 'CalendarService.update', date
        getFreeTimes: (performerId) ->
            $rootScope.$broadcast 'CalendarService.getFreeTimes', performerId
        ready: ->
            $rootScope.$broadcast 'CalendarService.ready'
    }
])