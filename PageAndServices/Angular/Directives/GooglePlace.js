(function() {
  window.app.directive('googleplace', function() {
    return {
      require: 'ngModel',
      replace: true,
      link: function(scope, element, attrs, model) {
        var options;

        options = {
          types: []
        };
        scope.gPlace = new google.maps.places.Autocomplete(element[0], options);
        return google.maps.event.addListener(scope.gPlace, 'place_changed', function() {
          return scope.$apply(function() {
            console.log(element.val());
            console.log(element);
            return model.$setViewValue(scope.gPlace.getPlace());
          });
        });
      }
    };
  });

}).call(this);
