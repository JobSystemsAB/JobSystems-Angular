window.app.controller 'SubsubcategoryViewController', 

['$scope', '$routeParams', 'Subsubcategory', 
( $scope,   $routeParams,   Subsubcategory) ->


    # -- INIT

    $scope.input = {}

    # -- METHOD

    $scope.save = ->
        if $scope.isNotNew()
            $scope.input.$update()
        else
            $scope.input = new Subsubcategory $scope.input
            $scope.input.$save()
            console.log $scope.input

    $scope.delete = ->
        $scope.input.$remove()

    $scope.isNotNew = ->
        $scope.input.id != '0'

    # -- DATA

    $scope.input.id = $routeParams.subsubcategoryId
    if $scope.isNotNew()
        $scope.input = Subsubcategory.get { id: $scope.input.id }


]