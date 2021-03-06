﻿window.app.service('CompanyCustomerService', 

[ '$http', 
(  $http) ->
    
    this.baseUrl = "/api/companycustomer"

    this.delete = (id) ->
        $http
            url: this.baseUrl + "/" + id
            method: "DELETE"

    this.get = (id) ->
        $http
            url: this.baseUrl + "/" + id
            method: "GET"

    this.getAll = ->
        $http
            url: this.baseUrl
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