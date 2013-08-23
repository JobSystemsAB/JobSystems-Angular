window.app.controller 'SubcategoryController', 

['$scope', 'Subcategory', 
( $scope,   Subcategory) ->


    # -- DATA

    $scope.subcategories = Subcategory.query()

    # -- METHOD

    $scope.delete = (subcategory) ->
        subcategory.$remove()
        $scope.subcategories = _.filter $scope.subcategories, (sub) ->
            return sub.id != subcategory.id

]