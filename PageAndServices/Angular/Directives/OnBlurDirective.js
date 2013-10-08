(function() {
  window.app.directive('onBlur', function() {
    return {
      restrict: 'A',
      link: function(scope, elm, attrs) {
        return elm.bind('blur', function() {
          return scope.$apply(attrs.onBlur);
        });
      }
    };
  });

}).call(this);
