﻿window.app.service('EmployeeService', 

[ '$http', 
(  $http) ->
    
    this.baseUrl = "/api/employee"

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

    this.login = (email, password) ->
        $http
            url: this.baseUrl + "/getlogin?email=" + email + "&password=" + password
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