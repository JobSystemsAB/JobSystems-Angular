window.app.controller 'EmployeeViewController', 

['$scope', '$routeParams', 'Employee', 
( $scope,   $routeParams,   Employee) ->


     # -- INIT

    $scope.input = {}

    # -- METHOD

    $scope.save = ->
        if $scope.isNotNew()
            $scope.input.$update()
        else
            $scope.input = new Category $scope.input
            $scope.input.$save()
            console.log $scope.input

    $scope.delete = ->
        $scope.input.$remove()

    $scope.isNotNew = ->
        $scope.input.id != '0'

    # -- DATA

    $scope.input.id = $routeParams.CategoryId
    if $scope.isNotNew()
        $scope.input = Category.get { id: $scope.input.id }


]