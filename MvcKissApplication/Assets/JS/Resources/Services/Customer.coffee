window.app.service('CustomerService', [ '$http', ($http) ->
    
    this.getCustomer = (email, password) ->
        $http
            url: "/api/customer/getlogin?email=" + email + "&password=" + password
            method: "GET"
    
])