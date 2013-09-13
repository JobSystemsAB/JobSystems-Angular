(function() {
  window.app.service('TextService', [
    '$http', function($http) {
      return this.getTexts = function(controllerName, language) {
        return $http({
          url: "/api/text/getpagetext?controllerName=" + controllerName + "&language=" + language,
          method: "GET"
        });
      };
    }
  ]);

}).call(this);
