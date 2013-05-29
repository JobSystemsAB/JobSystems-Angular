window.AdminLoginController = ($scope, $rootScope, $location, $http) ->

    $scope.SignIn = ->

        hashPassword = String CryptoJS.SHA3 $scope.password, { outputLength: 256 }

        loginData = 
            username: $scope.username
            password: hashPassword

        $http
            url: "/api/administrator/login"
            data: loginData
            method: "POST"
        .success (status, data, headers, config) -> 

            localStorage.setItem 'auth.accessToken', status.accessToken
            localStorage.setItem 'auth.userId', status.id
            localStorage.setItem 'auth.username', status.username
            localStorage.setItem 'auth.loggedIn', true

            $rootScope.auth.loggedIn = true
            $rootScope.auth.username = status.username
            $rootScope.auth.userId = status.id
            $rootScope.auth.accessToken = status.accessToken

            $location.path "administrators"

        .error (status, data, headers, config) -> 
            $scope.$broadcast 'infoMessage', data + ": Inloggning misslyckades, vänligen prova igen"