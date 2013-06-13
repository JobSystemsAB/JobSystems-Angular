app = angular.module 'GardenPageApp', ['services', 'ui.bootstrap', 'ui.date']

app.config ($routeProvider, $locationProvider) ->

    $routeProvider.when '/',
        templateUrl: 'Assets/js/angular/partials/garden-page/garden.html'
        controller: 'GardenInputFormCtrl'

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