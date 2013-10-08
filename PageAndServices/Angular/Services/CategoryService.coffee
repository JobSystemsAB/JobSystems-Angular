window.app.service('CategoryService', 

[ '$http', 
(  $http) ->
    
    this.baseUrl = "/api/category"

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

    this.getTree = ->
        $http
            url: this.baseUrl + '/gettree'
            method: "GET"

    this.getInputs = (id) ->
        $http
            url: this.baseUrl + '/' + id + '/categoryinputs'
            method: "GET"

    this.post = (model) ->
        $http
            url: this.baseUrl
            method: "POST"
            data: model

    this.postAll = (models) ->
        $http
            url: "/api/category/savecategories"
            method: "POST"
            data: models

    this.put = (model) ->
        $http
            url:this.baseUrl
            method: "PUT"
            data: model

])