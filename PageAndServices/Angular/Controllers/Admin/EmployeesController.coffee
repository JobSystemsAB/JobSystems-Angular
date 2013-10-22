window.app.controller 'AdminEmployeesController', 

['$scope', '$modal', 'AlertService', 'EmployeeService',
( $scope,   $modal,   AlertService,   EmployeeService ) ->

    # LOAD DATA

    EmployeeService.getAll()
        .success (data, status, headers, config) ->
            $scope.employees = data
        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Failed to load all services.'

    # GRID OPTIONS

    $scope.gridOptions = 
        data: 'employees'
        enableColumnResize: true
        enableRowSelection: true
        enableSorting: true
        multiSelect: false
        showGroupPanel: true
        afterSelectionChange: (data) ->
            $scope.open(data.entity)
        columnDefs: [
            { field: 'firstName', displayName: 'First name' }
            { field: 'lastName', displayName: 'Last Name' }
            { field: 'emailAddress', displayName: 'Email' }
            { field: 'phoneNumber', displayName: 'Phone' }
            { field: 'created', displayName: 'Created' }
            { field: 'updated', displayName: 'Updated' }
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
              
]