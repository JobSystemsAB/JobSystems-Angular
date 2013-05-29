app = angular.module 'AdminPortalApp', ['services', 'ui.bootstrap', 'ui.date']

app.config ($routeProvider, $locationProvider) ->

    $routeProvider.when '/login',
        templateUrl: 'Assets/js/angular/partials/admin-portal/login.html'

    $routeProvider.when '/administrators', 
        templateUrl: 'Assets/js/angular/partials/database-table/administrator.html'

    $routeProvider.when '/performers', 
        templateUrl: 'Assets/js/angular/partials/database-table/performer.html'

    $routeProvider.when '/assignments',
        templateUrl: 'Assets/js/angular/partials/database-table/assignment.html'

    $routeProvider.when '/timereports',
        templateUrl: 'Assets/js/angular/partials/database-table/timereport.html'

    $routeProvider.when '/clients',
        templateUrl: 'Assets/js/angular/partials/database-table/client.html'

    $routeProvider.otherwise
        redirectTo: '/404'

    #$locationProvider.html5Mode(true);

app.run ($rootScope, $location) ->

    $rootScope.auth =
        loggedIn: localStorage.getItem 'auth.loggedIn' == "true"
        username: localStorage.getItem 'auth.username'
        userId: parseInt localStorage.getItem 'auth.userId'
        accessToken: localStorage.getItem 'auth.accessToken'

    # Register listener to watch route changes
    $rootScope.$on "$routeChangeStart", (event, next, current) ->
      if !$rootScope.auth.loggedIn
        # no logged user, we should be going to #login
        if next.templateUrl != "Assets/js/angular/partials/admin-login.html"
          # not going to #login, we should redirect now
          $location.path "/login"