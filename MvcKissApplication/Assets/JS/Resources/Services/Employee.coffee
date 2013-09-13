window.app.service('EmployeeService', [ '$http', ($http) ->
    
    this.connectCategories = (employeeId, categoryIds) ->
        $http
            url: "/api/employee/" + employeeId + "/ConnectCategory"
            data: 
                'employeeId': employeeId
                'categoryIds': categoryIds
            method: "POST"

    this.getEmployee = (email, password) ->
        $http
            url: "/api/employee/getlogin?email=" + email + "&password=" + password
            method: "GET"
    
    
])