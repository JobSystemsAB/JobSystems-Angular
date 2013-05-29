(function() {
  window.AdminMenuController = function($scope, $rootScope, $location) {
    if ($scope.auth.loggedIn) {
      $location.path('administrators');
    }
    $scope.menuOptions = [
      {
        name: "Admins",
        destination: "/administrators",
        icon: "icon-lock"
      }, {
        name: "Kunder",
        destination: "/clients",
        icon: "icon-briefcase"
      }, {
        name: "Tidsrapporter",
        destination: "/timereports",
        icon: "icon-time"
      }, {
        name: "Uppdrag",
        destination: "/assignments",
        icon: "icon-th-list"
      }, {
        name: "Utförare",
        destination: "/performers",
        icon: "icon-user"
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
