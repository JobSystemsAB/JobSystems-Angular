window.app.controller 'EmployeeController', 

['$scope', 'Employee', 
( $scope,   Employee) ->


    # -- DATA

    $scope.employees = Employee.query()

    # -- METHOD

    $scope.delete = (employee) ->
        employee.$remove()
        $scope.employees = _.filter $scope.employees, (emp) ->
            return emp.id != employee.id

]