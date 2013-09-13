window.app.controller 'MissionController', 

['$scope', 'Mission', 'MissionService'
( $scope,   Mission,   MissionService) ->

    # -- INIT

    $scope.missions = {}

    # -- DATA

    $scope.missions = MissionService.getEmployed()
        .success (data, status) ->
            $scope.employed = data

    $scope.missions = MissionService.getUnemployed()
        .success (data, status) ->
            $scope.unemployed = data

    $scope.missions = MissionService.getDisabled()
        .success (data, status) ->
            $scope.disabled = data

    # -- METHOD

    $scope.delete = (mission) ->
        mission.$remove()
        $scope.missions = _.filter $scope.missions, (mis) ->
            return mis.id != mission.id


]