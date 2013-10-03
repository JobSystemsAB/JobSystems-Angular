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

  window.app.directive('contenteditable', function($timeout, $rootScope) {
    return {
      require: 'ngModel',
      link: function(scope, elm, attrs, ctrl) {
        elm.bind('blur', function() {
          return scope.$apply(function() {
            return ctrl.$setViewValue(elm.html().replace('<span class="ng-scope">', '').replace('</span>', ''));
          });
        });
        ctrl.$render = function() {
          attrs.$set('contenteditable', $rootScope.isAdmin);
          return elm.html(ctrl.$viewValue);
        };
        return ctrl.$render();
      }
    };
  });

  window.app.directive('compile', function($compile, $timeout) {
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
  });

}).call(this);
