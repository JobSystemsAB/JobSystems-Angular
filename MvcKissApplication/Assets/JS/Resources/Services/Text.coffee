window.app.service('TextService', [ '$http', ($http) ->
    
    this.getTexts = (controllerName, language) ->
        $http
            url: "/api/text/getpagetexts?controllerName=" + controllerName + "&language=" + language
            method: "GET"

    this.getTextsByLanguage = (language) ->
        $http
            url: "/api/text/getlangtexts?language=" + language
            method: "GET"

    this.saveTexts = (texts) ->
        $http
            url: "/api/text/savetexts"
            method: "POST"
            data: texts
    
])