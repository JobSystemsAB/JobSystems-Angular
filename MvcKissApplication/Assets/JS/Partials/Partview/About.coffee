window.app.controller 'AboutController', 

['$scope', 'TextService',
( $scope,   TextService) ->

    # STATIC DATA

    $scope.text-files = ['about-title', 'about-short', 'read-more']

    # LOAD DATA

    TextService.getTexts('AboutController', 'sv')
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
]