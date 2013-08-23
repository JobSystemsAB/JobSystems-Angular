window.app.controller 'AdministratorViewController', 

['$scope', '$routeParams', 'Administrator', 
( $scope,   $routeParams,   Administrator) ->


    # -- INIT

    $scope.input = {}

    # -- METHOD

    $scope.save = ->
        if $scope.isNotNew()
            $scope.input.$update()
        else
            $scope.input = new Administrator $scope.input
            $scope.input.$save()
            console.log $scope.input

    $scope.delete = ->
        $scope.input.$remove()

    $scope.isNotNew = ->
        $scope.input.id != '0'

    # -- DATA

    $scope.input.id = $routeParams.administratorId
    if $scope.isNotNew()
        $scope.input = Administrator.get { id: $scope.input.id }


]