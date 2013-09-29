window.app.directive 'onFocus', ->
    {
        restrict: 'A'
        link: (scope, elm, attrs) ->
            elm.bind 'focus', ->
                scope.$apply attrs.onFocus
    }

window.app.directive 'onBlur', ->
    {
        restrict: 'A'
        link: (scope, elm, attrs) ->
            elm.bind 'blur', ->
                scope.$apply attrs.onBlur
    }

window.app.directive 'contenteditable', ($timeout) ->
    return { 
        require: 'ngModel'
        link: (scope, elm, attrs, ctrl) ->

            # view -> model
            elm.bind 'blur', ->
                scope.$apply ->
                    ctrl.$setViewValue elm.html()
                
            # model -> view
            ctrl.$render = ->
                elm.html ctrl.$viewValue
        
            # load init value from DOM
            ctrl.$render()
           
    }

window.app.directive 'compile', ($compile, $timeout) ->
    return (scope, elm, attrs) ->
        scope.$watch(
            (scope) ->
                # watch the 'compile' expression for changes
                return scope.$eval attrs.compile

            , (value) ->
                # when the 'compile' expression changes
                # assign it into the current DOM
                elm.html _.unescape _.unescape value
 
                $timeout ->
                    # compile the new DOM and link it to the current scope.
                    # NOTE: we only compile .childNodes so that we don't get into infinite loop compiling ourselves
                    template = $compile elm.contents()
                    template scope
                , 200
        )
