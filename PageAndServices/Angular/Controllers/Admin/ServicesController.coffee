window.app.controller 'AdminServicesController', 

['$scope', 'CategoryService', 'AlertService',
( $scope,   CategoryService,   AlertService) ->

    # LOAD CATEGORIES

    $scope.loadTree = ->
        CategoryService.getTree()
            .success (data, status, headers, config) ->
                $scope.categoryTree = data

            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Failed to load all services.'

    $scope.loadTree()

    # CHANGE SELECTED

    $scope.changeSelected = (selected) ->
        $scope.service.parent = selected
        $scope.selected = selected
    $scope.service = {}

        # INCREASE ORDER
    
    $scope.orderUp = ->
        $scope.selected.order += 1

    # DECREASE ORDER
    
    $scope.orderDown = ->
        $scope.selected.order -= 1

    # CREATE CATEGORY

    $scope.create = ->
        
        parentId = null
        if $scope.service.parent
            parentId = $scope.service.parent.id

        CategoryService.post(
            description: $scope.service.description
            name: $scope.service.name
            parentId: parentId
            salary: $scope.service.salary
            order: 0
        )
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'New service saved.'
                $scope.loadTree()

            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Service was not able to be saved.'

    # UPDATE CATEGORY

    $scope.update = ->
        
        CategoryService.put($scope.selected)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Service updated.'
            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Service was not able to be updated.'

    # DELETE A CATEGORY

    $scope.delete = ->
        
        CategoryService.delete($scope.selected.id)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'New service saved.'
                $scope.loadTree()
            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Service was not able to be saved.'
        

]