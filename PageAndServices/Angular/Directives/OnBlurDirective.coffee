window.app.directive 'onBlur', ->
    {
        restrict: 'A'
        link: (scope, elm, attrs) ->
            elm.bind 'blur', ->
                scope.$apply attrs.onBlur
    }