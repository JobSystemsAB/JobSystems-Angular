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