window.app.controller 'MissionController', 

['$scope', 'Mission', 
( $scope,   Mission) ->


    # -- DATA

    $scope.missions = Mission.query()

    # -- METHOD

    $scope.delete = (mission) ->
        mission.$remove()
        $scope.missions = _.filter $scope.missions, (mis) ->
            return mis.id != mission.id


]