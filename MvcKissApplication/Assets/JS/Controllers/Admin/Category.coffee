window.app.controller 'CategoryController', 

['$scope', 'Category', 
( $scope,   Category) ->


    # -- DATA

    $scope.categories = Category.query()

    # -- METHOD

    $scope.delete = (category) ->
        category.$remove()
        $scope.categories = _.filter $scope.categories, (cat) ->
            return cat.id != category.id

]