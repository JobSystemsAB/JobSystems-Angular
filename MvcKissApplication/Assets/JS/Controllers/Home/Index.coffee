window.app.controller 'HomeIndexController', 

['$scope','$http', 'Category', 
( $scope,  $http,   Category) ->

    # -- INIT

    $scope.output = {}

    $scope.output.categories = Category.query()



]