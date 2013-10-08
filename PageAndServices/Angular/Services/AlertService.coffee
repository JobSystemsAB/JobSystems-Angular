window.app.service('AlertService', 

[ '$http', '$rootScope', '$timeout', 
(  $http,   $rootScope,   $timeout) ->
    
    this.closeAlert = (index) ->
        $rootScope.alerts.splice index, 1 

    this.addAlert = (type, message) ->
        if $rootScope.alerts == undefined
            $rootScope.alerts = []

        $rootScope.alerts.push { 'type': type, 'msg': message}
        
        $timeout ->
            $rootScope.alerts.splice 0, 1
        , 10000
    
])