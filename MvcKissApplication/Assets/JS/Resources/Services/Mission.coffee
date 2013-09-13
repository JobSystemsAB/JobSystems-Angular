window.app.service('MissionService', [ '$http', ($http) ->
    
    this.connectCategories = (missionId, categoryIds) ->
        $http
            url: "/api/mission/" + missionId + "/connectcategories"
            data: 
                'missionId': missionId
                'categoryIds': categoryIds
            method: "POST"
    
    this.connectCustomer = (missionId, customerId) ->
        $http
            url: "/api/mission/" + missionId + "/connectcustomer"
            data: 
                'missionId': missionId
                'customerId': customerId
            method: "POST"

    this.connectEmployee = (missionId, employeeId) ->
        $http
            url: "/api/mission/" + missionId + "/connectemployee"
            data: 
                'missionId': missionId
                'employeeId': employeeId
            method: "POST"

    this.getEmployed = ->
        $http
            url: "/api/mission/employed"
            method: "GET"

    this.getUnemployed = ->
        $http
            url: "/api/mission/unemployed"
            method: "GET"

    this.getDisabled = ->
        $http
            url: "/api/mission/disabled"
            method: "GET"

])