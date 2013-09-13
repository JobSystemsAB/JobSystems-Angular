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

    
window.app.directive 'contenteditable', ($timeout, $compile) ->
    return { 
        require: 'ngModel'
        link: (scope, elm, attrs, ctrl) ->

            # view -> model
            elm.on 'blur', ->
                scope.$apply attrs.ngModel + ' = "' + elm.html().replace(/"/g, '\\"') + '"'

                #scope.$apply ->
                    #ctrl.$setViewValue elm.html().replace(/"/g, '\\"')
                    #attrs.ngModel + ' = "' + elm.html().replace(/"/g, '\\"') + '"'
                    #console.log attrs.ngModel
            # model -> view
            ctrl.$render = (value) ->
                elm.html value
                $compile(elm.contents())(scope)
 
            # load init value from DOM
            $timeout ctrl.$render(), 200
    }
    ###
window.app.directive('compile', ($compile) ->
    # directive factory creates a link function
    return (scope, element, attrs) ->
        scope.$watch(
            (scope) -> 
                # watch the 'compile' expression for changes
                return scope.$eval attrs.compile
            ,
            (value) -> 
                # when the 'compile' expression changes
                # assign it into the current DOM
                element.html value
                
                # compile the new DOM and link it to the current
                # scope.
                # NOTE: we only compile .childNodes so that
                # we don't get into infinite loop compiling ourselves
                $compile(element.contents())(scope)
        );
    );
    ###
    ###
window.app.directive 'adminBindHtml', ($timeout) ->
    return {
        link: (scope, tElement, tAttrs) ->
            refresh = ->
                scope.$apply tAttrs.adminBindHtml + ' = "' + tElement.html().replace(/"/g, '\\"') + '"'
                $timeout refresh, 200
                
            scope.$watch tAttrs.adminBindHtml, (val, oldVal) ->
                if val != oldVal && tElement.html() != val
                    tElement.html scope.$eval tAttrs.adminBindHtml
                    
            $timeout refresh, 200
    }
    ###