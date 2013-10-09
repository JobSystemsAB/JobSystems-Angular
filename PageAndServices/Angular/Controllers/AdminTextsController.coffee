window.app.controller 'AdminTextsController', 

['$scope', 'TextService', 'AlertService',
( $scope,   TextService,   AlertService) ->

    $scope.tinymceOptions =
        plugins: [
            "advlist autolink lists link image charmap print preview hr anchor pagebreak"
            "searchreplace wordcount visualblocks visualchars code fullscreen"
            "insertdatetime media nonbreaking save table contextmenu directionality"
            "emoticons template paste textcolor"]

    # LOAD TEXTS

    TextService.getAllByLanguage('sv')
        .success (data, status, headers, config) ->
            $scope.texts = _.groupBy data, (text) -> 
                text.controllerName
            console.log $scope.texts 
        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Could not load texts.'

    # SELECT TEXT

    $scope.select = (text) ->
        $scope.selected = text

    # UPDATE TEXT

    $scope.update = ->
        TextService.put($scope.selected)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Updated the text.'
            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Could not save the text.'

    # GET UNIQUE ELEMENT ID

    $scope.unique = (controller) ->
        ids = _.map controller, (text) ->
            text.elementId
        return _.unique(ids).length

]