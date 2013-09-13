window.app.controller 'LoginController', 

['$scope', 'AdministratorService', 
( $scope,   AdministratorService) ->


    $scope.tryToLogin = ->
        AdministratorService.getAdministrator($scope.input.email, $scope.input.password)
            .success (data, status, headers, config) ->
                console.log 'worked!'


]