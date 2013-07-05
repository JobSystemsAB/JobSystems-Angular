(function() {
  window.app.controller('AnimalIndexController', [
    '$scope', '$http', 'Customer', 'Mission', function($scope, $http, Customer, Mission) {
      var autocomplete, input;

      $scope.input = {};
      $scope.input.mission = {};
      $scope.input.mission.address = {};
      $scope.input.mission.date = new Date();
      $scope.validate = {};
      $scope.firstTime = true;
      $scope.dateOptions = {
        monthNames: ['Januari', 'Februari', 'Mars', 'April', 'Maj', 'Juni', 'Juli', 'Augusti', 'September', 'Oktober', 'November', 'December'],
        monthNamesShort: ['Jan', 'Feb', 'Mar', 'Apr', 'Maj', 'Jun', 'Jul', 'Aug', 'Sep', 'Okt', 'Nov', 'Dec'],
        dayNamesShort: ['Sön', 'Mån', 'Tis', 'Ons', 'Tor', 'Fre', 'Lör'],
        dayNames: ['Söndag', 'Måndag', 'Tisdag', 'Onsdag', 'Torsdag', 'Fredag', 'Lördag'],
        dayNamesMin: ['Sö', 'Må', 'Ti', 'On', 'To', 'Fr', 'Lö'],
        weekHeader: 'Ve',
        dateFormat: 'yy-mm-dd',
        firstDay: 1,
        isRTL: false
      };
      $scope.getAddressType = function(address_components, type) {
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
      $scope.validate.address = function() {
        return $scope.input.mission.address.area === "Stockholms län";
      };
      $scope.order = function() {
        var customer, mission;

        customer = new Customer($scope.input.customer);
        return mission = new Mission($scope.input.mission);
      };
      $scope.load = function() {
        return $http({
          url: "/api/customers/login",
          data: $scope.input.login,
          method: "POST"
        }).success(function(status, data, headers, config) {
          return $scope.input.customer = status;
        }).error(function(status, data, headers, config) {
          console.log(data);
          return console.log(status);
        });
      };
      input = document.getElementById('google-address-search');
      autocomplete = new google.maps.places.Autocomplete(input);
      return google.maps.event.addListener(autocomplete, 'place_changed', function() {
        var place;

        place = autocomplete.getPlace();
        $scope.input.mission.address.streetNumber = $scope.getAddressType(place.address_components, 'street_number');
        $scope.input.mission.address.street = $scope.getAddressType(place.address_components, 'route');
        $scope.input.mission.address.postalCode = $scope.getAddressType(place.address_components, 'postal_code');
        $scope.input.mission.address.postalTown = $scope.getAddressType(place.address_components, 'postal_town');
        $scope.input.mission.address.country = $scope.getAddressType(place.address_components, 'country');
        $scope.input.mission.address.area = $scope.getAddressType(place.address_components, 'administrative_area_level_1');
        $scope.input.mission.address.latitude = place.geometry.location.jb;
        return $scope.input.mission.address.longitude = place.geometry.location.kb;
      });
    }
  ]);

}).call(this);
