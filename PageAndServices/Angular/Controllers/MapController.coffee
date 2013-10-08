window.app.controller 'MapController', 

['$scope', 'TextService',
( $scope,   TextService) ->

    # STATIC DATA

    $scope.text-files = ['map-title', 'map-address', 'map-phone-number', 'map-email']

    google.maps.visualRefresh = true

    angular.extend $scope,
        center:
            latitude: 59.344679
            longitude: 18.071171
        markers: [ { latitude: 59.344679, longitude: 18.071171 }]
        zoom: 15

    # LOAD DATA

    TextService.getAllByControllerAndLanguage('MapController', 'sv')
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