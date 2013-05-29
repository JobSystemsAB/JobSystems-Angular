app = angular.module 'MainPageApp', ['services', 'ui.bootstrap', 'ui.date']

app.config ($routeProvider, $locationProvider) ->

    $routeProvider.when '/',
        templateUrl: 'Assets/js/angular/partials/main-page.html'

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