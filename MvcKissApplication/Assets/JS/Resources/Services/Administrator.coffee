window.app.service('AdministratorService', [ '$http', ($http) ->
    
    this.getAdministrator = (email, password) ->
        $http
            url: "/api/administrator/getlogin?email=" + email + "&password=" + password
            method: "GET"
    
])