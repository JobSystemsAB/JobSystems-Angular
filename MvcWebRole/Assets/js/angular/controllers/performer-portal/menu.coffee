window.PerformerMenuController = ($scope, $rootScope, $location) ->

    $scope.menuOptions = [
        { name: "Tidsrapport", destination: "/timereport", icon: "icon-time" }
        { name: "Profil", destination: "/profile", icon: "icon-user" }
    ]

    $scope.location = $location

    $scope.navigate = (destination) ->
        $location.path destination

    $scope.logOut = ->

        localStorage.setItem 'auth.accessToken', ""
        localStorage.setItem 'auth.userId', ""
        localStorage.setItem 'auth.username', ""
        localStorage.setItem 'auth.loggedIn', false

        $rootScope.auth.loggedIn = false
        $rootScope.auth.username = ""
        $rootScope.auth.userId = ""
        $rootScope.auth.accessToken = ""
    
        $location.path 'login'