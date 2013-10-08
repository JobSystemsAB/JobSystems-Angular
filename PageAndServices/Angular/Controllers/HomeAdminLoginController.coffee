window.app.controller 'HomeAdminLoginController', 

['$scope', '$rootScope', '$timeout', 'AdministratorService', 'AlertService',
( $scope,   $rootScope,   $timeout,   AdministratorService,   AlertService ) ->

    $scope.admin = { email: '', password: '' }

    $scope.tryLogin = ->
        AdministratorService.login($scope.admin.email, $scope.admin.password)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Inloggad som ' + $scope.admin.email + '. Du vidarebefordras till startsidan. Notera att alla ändringar påverkar sidan live.' 
                console.log data.authToken
                $rootScope.isAdmin = true

                $timeout ->
                    $state.go 'index', { }
                , 2500

            .error (data, status, headers, config) ->
                if status == 404
                    AlertService.addAlert 'danger', 'Inloggning misslyckades, vänligen kontrollera användarnamn och lösenord.'
                else
                    AlertService.addAlert 'danger', 'Inloggning misslyckades, vänligen prova igen eller ta kontakt med en tekniker.'
                
]