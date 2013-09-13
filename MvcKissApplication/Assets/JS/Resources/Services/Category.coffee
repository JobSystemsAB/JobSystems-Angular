window.app.service('CategoryService', [ '$http', ($http) ->
    
    this.getCategoryInputs = (categoryId) ->
        $http
            url: "/api/category/" + categoryId + "/categoryinputs"
            method: "GET"
    
    this.getTree = ->
        $http
            url: "/api/category/gettree"
            method: "GET"

])