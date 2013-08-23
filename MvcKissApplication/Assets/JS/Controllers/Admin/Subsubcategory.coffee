window.app.controller 'SubsubcategoryController', 

['$scope', 'Subsubcategory', 
( $scope,   Subsubcategory) ->


    # -- DATA

    $scope.subsubcategories = Subsubcategory.query()

    # -- METHOD

    $scope.delete = (subsubcategory) ->
        subsubcategory.$remove()
        $scope.subsubcategories = _.filter $scope.subsubcategories, (sub) ->
            return sub.id != subsubcategory.id

]