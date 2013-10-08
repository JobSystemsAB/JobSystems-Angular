window.app.directive 'googleplace', ->
    return {
        require: 'ngModel'
        replace: true
        link: (scope, element, attrs, model) ->
            options =
                types: []
            
            scope.gPlace = new google.maps.places.Autocomplete(element[0], options);

            google.maps.event.addListener scope.gPlace, 'place_changed', ->
                scope.$apply ->
                    console.log element.val()
                    console.log element
                    model.$setViewValue scope.gPlace.getPlace()            
     }