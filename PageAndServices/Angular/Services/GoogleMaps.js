(function() {
  window.app.service('GoogleMapsService', [
    '$http', function($http) {
      return this.getAddressType = function(address_components, type) {
        var temp;

        temp = _.find(address_components, function(component) {
          return _.contains(component.types, type);
        });
        if (temp) {
          return temp.long_name;
        } else {
          return null;
        }
      };
    }
  ]);

}).call(this);
