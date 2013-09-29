window.app.controller 'ServicesController', 

['$scope', 'TextService', 'CategoryService', 'AlertService',
( $scope,   TextService,   CategoryService,   AlertService) ->

    # STATIC DATA

    $scope.text-files = ['services-title', 'services-text']
    
    # LOAD DATA

    TextService.getTexts('ServicesController', 'sv')
        .success (data, status, headers, config) ->
            $scope.textsOriginal = data
            $scope.texts = _.groupBy $scope.textsOriginal, (text) -> 
                text.elementId
        .error (data, status, headers, config) ->
            AlertService.addAlert 'error', 'Fel: ' + status

    CategoryService.getAll()
        .success (data, status, headers, config) ->
            $scope.categories = _.filter data, (item) ->
                item.parentId == null
        .error (data, status, headers, config) ->
            AlertService.addAlert 'error', 'Fel: ' + status
    
    # SAVE DATA

    $scope.save = ->

        TextService.saveTexts($scope.textsOriginal)
            .success (data, status, headers, config) ->
                console.log status
            .error (data, status, headers, config) ->
                console.log status

        CategoryService.saveCategories($scope.categories)
            .success (data, status, headers, config) ->
                console.log status
            .error (data, status, headers, config) ->
                console.log status

]