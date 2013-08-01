window.app.service('EmployeeService', [ '$http', ($http) ->
    
    return 
    {
        login: (data) ->
            $http    
                url: "/api/employees/login"
                data: data
                method: "POST"
            .success (status, data, headers, config) -> 
                return { sucess: true, status: status, data: data, headers: headers, config: config }
            .error (status, data, headers, config) -> 
                return { sucess: false, status: status, data: data, headers: headers, config: config }

        getAllPet: ->
            $http
                url: "/api/employees/GetAllPet"
                method: "GET"
            .success (status, data, headers, config) -> 
                return { sucess: true, status: status, data: data, headers: headers, config: config }
            .error (status, data, headers, config) -> 
                return { sucess: false, status: status, data: data, headers: headers, config: config }

        createPet: (data) ->
            $http
                url: "/api/employees/CreatePet"
                data: data
                method: "POST"
            .success (status, data, headers, config) -> 
                return { sucess: true, status: status, data: data, headers: headers, config: config }
            .error (status, data, headers, config) -> 
                return { sucess: false, status: status, data: data, headers: headers, config: config }
    }

])

window.app.service('CustomerService', [ '$http', ($http) ->
    
    return 
    {
        login: (data) ->
            $http    
                url: "/api/customers/login"
                data: data
                method: "POST"
            .success (status, data, headers, config) -> 
                return { sucess: true, status: status, data: data, headers: headers, config: config }
            .error (status, data, headers, config) -> 
                return { sucess: false, status: status, data: data, headers: headers, config: config }
    }

])