window.app.controller 'MissionsController', 

['$scope','$http', 'Mission',
( $scope,  $http,   Mission) ->


    $scope.output.missionsNew = Mission.query()


]