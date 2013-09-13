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

  window.app.directive('contenteditable', function($timeout, $compile) {
    return {
      require: 'ngModel',
      link: function(scope, elm, attrs, ctrl) {
        elm.on('blur', function() {
          return scope.$apply(attrs.ngModel + ' = "' + elm.html().replace(/"/g, '\\"') + '"');
        });
        ctrl.$render = function(value) {
          elm.html(value);
          return $compile(elm.contents())(scope);
        };
        return $timeout(ctrl.$render(), 200);
      }
    };
    /*
    window.app.directive('compile', ($compile) ->
    # directive factory creates a link function
    return (scope, element, attrs) ->
        scope.$watch(
            (scope) -> 
                # watch the 'compile' expression for changes
                return scope.$eval attrs.compile
            ,
            (value) -> 
                # when the 'compile' expression changes
                # assign it into the current DOM
                element.html value
                
                # compile the new DOM and link it to the current
                # scope.
                # NOTE: we only compile .childNodes so that
                # we don't get into infinite loop compiling ourselves
                $compile(element.contents())(scope)
        );
    );
    */

    /*
    window.app.directive 'adminBindHtml', ($timeout) ->
    return {
        link: (scope, tElement, tAttrs) ->
            refresh = ->
                scope.$apply tAttrs.adminBindHtml + ' = "' + tElement.html().replace(/"/g, '\\"') + '"'
                $timeout refresh, 200
                
            scope.$watch tAttrs.adminBindHtml, (val, oldVal) ->
                if val != oldVal && tElement.html() != val
                    tElement.html scope.$eval tAttrs.adminBindHtml
                    
            $timeout refresh, 200
    }
    */

  });

}).call(this);
