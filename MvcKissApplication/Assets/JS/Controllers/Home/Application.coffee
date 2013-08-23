window.app.controller 'HomeIndexController', 

['$scope','$http', 'Category', 'Subcategory', 'Subsubcategory', 
( $scope,  $http,   Category,   Subcategory,   Subsubcategory) ->

    # -- INIT

    $scope.output = {}
    $scope.input = {}

    # -- DATA

    $scope.category = Category.query()
    $scope.subcategory = Subcategory.query()
    $scope.subsubcategory = Subsubcategory.query()

]