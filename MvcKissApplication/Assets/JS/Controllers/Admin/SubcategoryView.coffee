window.app.controller 'SubcategoryViewController', 

['$scope', '$routeParams', 'Subcategory', 
( $scope,   $routeParams,   Subcategory) ->


    # -- INIT

    $scope.input = {}

    # -- METHOD

    $scope.save = ->
        if $scope.isNotNew()
            $scope.input.$update()
        else
            $scope.input = new Subcategory $scope.input
            $scope.input.$save()
            console.log $scope.input

    $scope.delete = ->
        $scope.input.$remove()

    $scope.isNotNew = ->
        $scope.input.id != '0'

    # -- DATA

    $scope.input.id = $routeParams.subcategoryId
    if $scope.isNotNew()
        $scope.input = Subcategory.get { id: $scope.input.id }


]