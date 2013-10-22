window.app.controller 'AdminServiceInputsController', 

['$scope', 'CategoryService', 'CategoryInputService', 'AlertService',
( $scope,   CategoryService,   CategoryInputService,   AlertService) ->

    # GET DATA

    CategoryService.getAll()
        .success (data, status, headers, config) ->
            $scope.categories = _.filter data, (item) ->
                item.parentId == null
        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Failed to load all services.'

    CategoryInputService.getAll()
        .success (data, status, headers, config) ->
            $scope.inputs = data
            $scope.inputsGrouped = _.groupBy data, 'categoryId'

            console.log $scope.inputsGrouped
        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Failed to load all service inputs.'

    # CREATE INPUT

    $scope.create = ->
        CategoryInputService.post($scope.newInput)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'New input saved.'

                $scope.inputs.push data
                $scope.inputsGrouped = _.groupBy $scope.inputs, 'categoryId'

            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Failed to save new input.'

    # UPDATE INPUT
    
    $scope.update = (input) ->
        CategoryInputService.put(input)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Input updated.'

            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Failed to save new input.'

    # DELETE INPUT
    
    $scope.delete = (inputId) ->
        CategoryInputService.delete(inputId)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Input removed.'

                $scope.inputs = _.reject $scope.inputs, (input) ->
                    input.id == inputId
                $scope.inputsGrouped = _.groupBy $scope.inputs, 'categoryId'

            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Failed to save new input.'

]