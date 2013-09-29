﻿window.app.controller 'BookNowController', 

['$scope', 'TextService',
( $scope,   TextService) ->

    # STATIC DATA

    $scope.text-files = ['book-now-button']

    # LOAD DATA

    TextService.getTexts('BookNowController', 'sv')
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