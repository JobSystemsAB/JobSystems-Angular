(function() {
  window.app.directive('contenteditable', [
    '$timeout', '$rootScope', function($timeout, $rootScope) {
      return {
        require: 'ngModel',
        link: function(scope, elm, attrs, ctrl) {
          elm.bind('blur', function() {
            return scope.$apply(function() {
              return ctrl.$setViewValue(_.unescape(elm.html().replace('<span class="ng-scope">', '').replace('</span>', '')));
            });
          });
          ctrl.$render = function() {
            attrs.$set('contenteditable', true);
            return elm.html(_.escape(ctrl.$viewValue));
          };
          return ctrl.$render();
        }
      };
    }
  ]);

}).call(this);
