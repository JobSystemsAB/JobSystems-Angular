window.app.directive 'contenteditable', 

['$timeout', '$rootScope',
( $timeout,   $rootScope) ->

    return { 
        require: 'ngModel'
        link: (scope, elm, attrs, ctrl) ->

            # view -> model
            elm.bind 'blur', ->
                scope.$apply ->
                    ctrl.$setViewValue _.unescape elm.html().replace('<span class="ng-scope">', '').replace('</span>', '')

            # model -> view
            ctrl.$render = ->
                attrs.$set 'contenteditable', true #$rootScope.isAdmin
                elm.html _.escape ctrl.$viewValue
        
            # load init value from DOM
            ctrl.$render()
           
    }

]