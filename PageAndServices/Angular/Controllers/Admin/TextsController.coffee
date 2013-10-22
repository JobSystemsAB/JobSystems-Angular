window.app.controller 'AdminTextsController', 

['$scope', '$modal', 'TextService', 'AlertService',
( $scope,   $modal,   TextService,   AlertService) ->

    $scope.tinymceOptions =
        plugins: [
            "advlist autolink lists link image charmap print preview hr anchor pagebreak"
            "searchreplace wordcount visualblocks visualchars code fullscreen"
            "insertdatetime media nonbreaking save table contextmenu directionality"
            "emoticons template paste textcolor"]

    # LOAD TEXTS

    TextService.getAllByLanguage('sv')
        .success (data, status, headers, config) ->
            $scope.textsUngrouped = data
            $scope.texts = _.groupBy data, (text) -> 
                text.controllerName
        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Failed to load all texts.'

    # GRID OPTIONS

    $scope.gridOptions = 
        data: 'textsUngrouped'
        enableColumnResize: true
        enableRowSelection: true
        enableSorting: true
        multiSelect: false
        showGroupPanel: true
        afterSelectionChange: (data) ->
            $scope.open(data.entity)
        columnDefs: [
            { field: 'controllerName', displayName: 'Group' }
            { field: 'elementId', displayName: 'Id' }
            { field: 'language', displayName: 'Language' }
            { field: 'text', displayName: 'Text' }
            { field: 'created', displayName: 'Created' }
            { field: 'enabled', displayName: 'Enabled' }
        ]

    # OPEN MODAL

    $scope.open = (selected) ->
        modalInstance = $modal.open
            templateUrl: 'myModalContent.html'
            controller: ModalInstanceCtrl
            resolve:
                selected: ->
                    return angular.copy selected

        modalInstance.result.then (selected) ->
            $scope.selected = selectedItem;
        , ->
            console.log 'Modal dismissed at: ' + new Date()
    
    # MODAL CONTROLLER

    ModalInstanceCtrl = ($scope, $modalInstance, selected) ->
        $scope.selected = selected

        $scope.tinymceOptions =
            plugins: [
                "advlist autolink lists link image charmap print preview hr anchor pagebreak"
                "searchreplace wordcount visualblocks visualchars code fullscreen"
                "insertdatetime media nonbreaking save table contextmenu directionality"
                "emoticons template paste textcolor"]

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