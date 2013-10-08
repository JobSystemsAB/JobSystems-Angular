window.app.directive 'onFocus', ->
    {
        restrict: 'A'
        link: (scope, elm, attrs) ->
            elm.bind 'focus', ->
                scope.$apply attrs.onFocus
    }