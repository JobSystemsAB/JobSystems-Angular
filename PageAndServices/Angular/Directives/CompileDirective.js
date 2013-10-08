(function() {
  window.app.directive('compile', [
    '$compile', '$timeout', function($compile, $timeout) {
      return function(scope, elm, attrs) {
        return scope.$watch(function(scope) {
          return scope.$eval(attrs.compile);
        }, function(value) {
          elm.html(_.unescape(_.unescape(value)));
          return $timeout(function() {
            var template;

            template = $compile(elm.contents());
            return template(scope);
          }, 200);
        });
      };
    }
  ]);

}).call(this);
