(function() {
  window.app.service('TextService', [
    '$http', function($http) {
      this.getTexts = function(controllerName, language) {
        return $http({
          url: "/api/text/getpagetexts?controllerName=" + controllerName + "&language=" + language,
          method: "GET"
        });
      };
      this.getTextsByLanguage = function(language) {
        return $http({
          url: "/api/text/getlangtexts?language=" + language,
          method: "GET"
        });
      };
      return this.saveTexts = function(texts) {
        return $http({
          url: "/api/text/savetexts",
          method: "POST",
          data: texts
        });
      };
    }
  ]);

}).call(this);
