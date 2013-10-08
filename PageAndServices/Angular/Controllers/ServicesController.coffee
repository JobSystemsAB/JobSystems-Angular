window.app.controller 'ServicesController', 

['$scope', '$state', 'TextService', 'CategoryService', 'AlertService',
( $scope,   $state,   TextService,   CategoryService,   AlertService) ->

    # STATIC DATA

    $scope.text-files = ['services-title', 'services-text']
    
    # LOAD DATA

    TextService.getAllByControllerAndLanguage('ServicesController', 'sv')
        .success (data, status, headers, config) ->
            $scope.textsOriginal = data
            $scope.texts = _.groupBy $scope.textsOriginal, (text) -> 
                text.elementId
        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Misslyckades att hämta texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'

    CategoryService.getAll()
        .success (data, status, headers, config) ->
            $scope.categories = _.filter data, (item) ->
                item.parentId == null
        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Misslyckades att hämta tjänsterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'

    
    # SAVE DATA

    $scope.save = ->

        TextService.postAll($scope.textsOriginal)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Texter sparade.'
            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Misslyckades att spara texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'

        CategoryService.postAll($scope.categories)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Tjänster sparade.'
            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Misslyckades att spara tjänsterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'

    # GO TO SERVICE PAGE
    
    $scope.goToService = (serviceId, serviceUrl) ->
        $state.go serviceUrl, { 'serviceId': serviceId }

]