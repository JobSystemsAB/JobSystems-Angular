window.app.controller 'AdministratorController', 

['$scope', 'Administrator', 
( $scope,   Administrator) ->


    # -- DATA
    
    $scope.administrators = Administrator.query()

    # -- METHOD

    $scope.delete = (administrator) ->
        administrator.$remove()
        $scope.administrators = _.filter $scope.administrators, (admin) ->
            return admin.id != administrator.id

]