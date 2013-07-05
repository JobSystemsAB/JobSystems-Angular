app = angular.module 'GardenApp', ['services', 'ui.bootstrap', 'ui.date']

app.config ($routeProvider, $locationProvider) ->

    $routeProvider.when '/',
        templateUrl: 'Assets/angular/partials/garden/index.html'
        controller: 'GardenIndexController'

    $routeProvider.otherwise
        redirectTo: '/404'

app.directive 'autoComplete', ($timeout) ->
    return (scope, iElement, iAttrs) ->
        iElement.autocomplete(
            source: scope[iAttrs.uiItems]
            select: ->
                $timeout ->
                    iElement.trigger('input')
                , 0)