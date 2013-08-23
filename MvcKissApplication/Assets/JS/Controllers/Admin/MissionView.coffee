window.app.controller 'MissionViewController', 

['$scope', '$routeParams', 'Mission', 'Category', 'CategoryService', 'SubcategoryService', 
( $scope,   $routeParams,   Mission,   Category,   CategoryService,   SubcategoryService) ->


     # -- INIT

    $scope.input = {}
    $scope.input.inputs = {}
    $scope.output = {}

    # -- METHOD

    $scope.updateSubcategory = ->
        $scope.output.subcategories = []
        $scope.output.subsubcategories = []
        CategoryService.getSubcategories($scope.input.categoryId)
            .success (data, status, headers, config) ->
                $scope.output.subcategories = data

        CategoryService.getCategoryInputs($scope.input.categoryId)
            .success (data, status, headers, config) ->
                $scope.output.inputs = data

    $scope.updateSubsubcategory = ->
        $scope.output.subsubcategories = []
        SubcategoryService.getSubsubcategories($scope.input.subcategoryId)
            .success (data, status, headers, config) ->
                $scope.output.subsubcategories = data

    $scope.inputsToJson = ->
        return angular.toJson _.map $scope.output.inputs, (input) ->
            return { name: input.name, value: input.value }

    $scope.save = ->
        if $scope.isNotNew()
            $scope.input.$update()
        else
            $scope.input = new Mission $scope.input
            $scope.input.$save()
            console.log $scope.input

    $scope.delete = ->
        $scope.input.$remove()

    $scope.isNotNew = ->
        $scope.input.id != '0'

    $scope.hasSubcategory = ->
        $scope.output.subcategories && $scope.output.subcategories.length > 0

    $scope.hasSubsubcategory = ->
        $scope.output.subsubcategories && $scope.output.subsubcategories.length > 0

    # -- DATA

    $scope.input.id = $routeParams.missionId
    if $scope.isNotNew()
        $scope.input = Mission.get { id: $scope.input.id }

    $scope.output.categories = Category.query()

]