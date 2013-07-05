app = angular.module 'AdminApp', ['services', 'ui.bootstrap', 'ui.date']

app.config ($routeProvider, $locationProvider) ->

    $routeProvider.when '/login',
        templateUrl: 'Assets/angular/partials/admin/login.html'
        controller: 'AdminLoginController'

    $routeProvider.when '/administrators', 
        templateUrl: 'Assets/angular/partials/database/administrator.html'
        controller: 'DatabaseAdministratorController'

    $routeProvider.when '/performers', 
        templateUrl: 'Assets/angular/partials/database/performer.html'
        controller: 'DatabasePerformerController'

    $routeProvider.when '/assignments',
        templateUrl: 'Assets/angular/partials/database/assignment.html'
        controller: 'DatabaseAssignmentController'

    $routeProvider.when '/timereports',
        templateUrl: 'Assets/angular/partials/database/timereport.html'
        controller: 'DatabasePerformerTimeReportController'

    $routeProvider.when '/clients',
        templateUrl: 'Assets/angular/partials/database/client.html'
        controller: 'DatabaseClientController'

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
        if next.templateUrl != "Assets/angular/partials/admin/login.html"
          # not going to #login, we should redirect now
          $location.path "/login"