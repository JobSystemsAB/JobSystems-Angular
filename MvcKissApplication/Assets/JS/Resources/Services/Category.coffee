window.app.service('CategoryService', [ '$http', ($http) ->
    
    this.getCategoryInputs = (categoryId) ->
        $http
            url: "/api/category/" + categoryId + "/categoryinputs"
            method: "GET"
    
    this.getAll = ->
        $http
            url: "/api/category"
            method: "GET"

    this.getTree = ->
        $http
            url: "/api/category/gettree"
            method: "GET"

    this.saveCategories = (categories) ->
        $http
            url: "/api/category/savecategories"
            method: "POST"
            data: categories

])