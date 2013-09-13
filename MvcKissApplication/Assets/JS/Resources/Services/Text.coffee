window.app.service('TextService', [ '$http', ($http) ->
    
    this.getTexts = (controllerName, language) ->
        $http
            url: "/api/text/getpagetext?controllerName=" + controllerName + "&language=" + language
            method: "GET"
    
])