window.app.controller 'TitleWindowController', 

['$scope', '$state', '$stateParams', 'TextService',
( $scope,   $state,   $stateParams,   TextService) ->

    # STATIC DATA

    $scope.text-files = ['title-window-text', 'title-window-book-text', 'title-window-button']

    # PARAM DATA

    $scope.currentCategoryId = $stateParams.serviceId

    # LOAD DATA

    TextService.getTexts('TitleWindowController', 'sv')
        .success (data, status, headers, config) ->
            $scope.textsOriginal = data
            $scope.texts = _.groupBy $scope.textsOriginal, (text) -> 
                text.elementId
        .error (data, status, headers, config) ->
            console.log status
    
    # SAVE DATA

    $scope.save = ->

        TextService.saveTexts($scope.textsOriginal)
            .success (data, status, headers, config) ->
                console.log status
            .error (data, status, headers, config) ->
                console.log status

    # GO TO BOOKING PAGE

    $scope.goToBooking = ->
        $state.go 'book', { serviceId: $scope.currentCategoryId }

]