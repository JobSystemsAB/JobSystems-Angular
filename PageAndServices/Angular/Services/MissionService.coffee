window.app.service('MissionService', 

[ '$http', 
(  $http) ->
    
    this.baseUrl = "/api/mission"

    this.delete = (id) ->
        $http
            utl: this.baseUrl + "/" + id
            method: "DELETE"

    this.get = (id) ->
        $http
            url: this.baseUrl + "/" + id
            method: "GET"

    this.getAll = ->
        $http
            url: this.baseUrl
            method: "GET"

    this.getEmployed = ->
        $http
            url: this.baseUrl + "/employed"
            method: "GET"

    this.getUnemployed = ->
        $http
            url: this.baseUrl + "/unemployed"
            method: "GET"

    this.getDisabled = ->
        $http
            url: this.baseUrl + "/disabled"
            method: "GET"

    this.post = (model) ->
        $http
            url: this.baseUrl
            method: "POST"
            data: model

    this.put = (model) ->
        $http
            url:this.baseUrl
            method: "PUT"
            data: model

])