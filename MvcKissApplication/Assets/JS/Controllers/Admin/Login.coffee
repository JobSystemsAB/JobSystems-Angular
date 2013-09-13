window.app.controller 'LoginController', 

['$scope', 'EmployeeService', 
( $scope,   EmployeeService) ->


    $scope.tryToLogin = ->
        EmployeeService.getEmployee($scope.input.email, $scope.input.password)
            .success (data, status, headers, config) ->
                console.log 'worked!'


]