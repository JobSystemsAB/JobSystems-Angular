window.app.controller 'PriceController', 

['$scope', 'AlertService', 'TextService',
( $scope,   AlertService,   TextService) ->

    # STATIC DATA

    $scope.text-files = ['price-title', 'price-short', 'price-more']

    # LOAD DATA

    TextService.getAllByControllerAndLanguage('PriceController', 'sv')
        .success (data, status, headers, config) ->
            $scope.textsOriginal = data
            $scope.texts = _.groupBy $scope.textsOriginal, (text) -> 
                text.elementId
        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Misslyckades att hämta texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'
    
    # SAVE DATA

    $scope.save = ->

        TextService.postAll($scope.textsOriginal)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Texter sparade.'
            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Misslyckades att spara texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'

]   