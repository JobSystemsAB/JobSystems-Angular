window.app.controller 'BookNowController', 

['$scope', '$state', '$stateParams', 'TextService',
( $scope,   $state,   $stateParams,   TextService) ->

    # STATIC DATA

    $scope.text-files = ['book-now-button']

    # LOAD DATA

    TextService.getTexts('BookNowController', 'sv')
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

    $scope.goToBooking = ->
        $state.go 'book', { serviceId: $stateParams.serviceId }

]