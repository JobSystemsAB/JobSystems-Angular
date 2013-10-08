(function() {
  window.app.directive('onFocus', function() {
    return {
      restrict: 'A',
      link: function(scope, elm, attrs) {
        return elm.bind('focus', function() {
          return scope.$apply(attrs.onFocus);
        });
      }
    };
  });

}).call(this);
