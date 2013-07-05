(function() {
  window.PerformerMenuController = function($scope, $rootScope, $location) {
    $scope.menuOptions = [
      {
        name: "Tidsrapport",
        destination: "/timereport",
        icon: "icon-time"
      }, {
        name: "Profil",
        destination: "/profile",
        icon: "icon-user"
      }, {
        name: "Tillgänglighet",
        destination: "/timefree",
        icon: "icon-wrench"
      }
    ];
    $scope.location = $location;
    $scope.navigate = function(destination) {
      return $location.path(destination);
    };
    return $scope.logOut = function() {
      localStorage.setItem('auth.accessToken', "");
      localStorage.setItem('auth.userId', "");
      localStorage.setItem('auth.username', "");
      localStorage.setItem('auth.loggedIn', false);
      $rootScope.auth.loggedIn = false;
      $rootScope.auth.username = "";
      $rootScope.auth.userId = "";
      $rootScope.auth.accessToken = "";
      return $location.path('login');
    };
  };

}).call(this);
