window.app.controller 'TitleWindowController', 

['$scope', '$state', '$stateParams', 'AlertService', 'TextService',
( $scope,   $state,   $stateParams,   AlertService,   TextService) ->

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
            AlertService.addAlert 'danger', 'Misslyckades att hämta texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'

    
    # SAVE DATA

    $scope.save = ->

        TextService.saveTexts($scope.textsOriginal)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Texter sparade.'
            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Misslyckades att spara texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'


    # GO TO BOOKING PAGE

    $scope.goToBooking = ->
        $state.go 'book', { serviceId: $scope.currentCategoryId }

]