(function() {
  window.app.controller('AnimalIndexController', [
    '$scope', '$http', 'CustomerPrivate', 'MissionPet', 'Pet', function($scope, $http, CustomerPrivate, MissionPet, Pet) {
      var autocomplete, input;

      $scope.output = {};
      $scope.input = {};
      $scope.input.mission = {};
      $scope.input.mission.address = {};
      $scope.input.mission.startDate = new Date();
      $scope.input.mission.startTime = new Date(2000, 1, 1, 12, 0, 0, 0);
      $scope.validate = {};
      $scope.firstTime = true;
      $scope.output.pets = Pet.query();
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
        var customer;

        $scope.input.customer.address = $scope.input.mission.address;
        customer = new CustomerPrivate($scope.input.customer);
        console.log("Creating Customer");
        return customer.$save(function(data) {
          console.log("Customer created ", data.id);
          return $scope.createMission(data.id);
        }, function(err) {
          return console.log("error");
        });
      };
      $scope.createMission = function(customerId) {
        var missionPet;

        $scope.input.mission.customerId = customerId;
        missionPet = new MissionPet($scope.input.mission);
        return missionPet.$save(function(data) {
          return console.log(data);
        }, function(err) {
          return console.log("error");
        });
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
