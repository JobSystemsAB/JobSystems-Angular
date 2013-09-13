window.app.service('AlertService', [ '$http', '$rootScope', ($http, $rootScope) ->
    
    this.addAlert = (type, message) ->
        if $rootScope.alerts == undefined
            $rootScope.alerts = []

        $rootScope.alerts.push { 'type': type, 'msg': message}

    this.closeAlert = (index) ->
        $rootScope.alerts.splice index, 1 
    
])