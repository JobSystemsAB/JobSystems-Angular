(function() {
  window.app.controller('EmployeeApplicationController', [
    '$scope', '$http', 'Pet', function($scope, $http, Pet) {
      var autocomplete, input;

      $scope.output = {};
      $scope.input = {};
      $scope.input.employee = {};
      $scope.input.employee.petIds = [];
      $scope.input.employee.address = {};
      $scope.alerts = [];
      input = document.getElementById('google-address-search');
      autocomplete = new google.maps.places.Autocomplete(input);
      $scope.output.pets = Pet.query();
      $scope.order = function() {
        return $http({
          url: "/api/employees/CreatePet",
          data: $scope.input.employee,
          method: "POST"
        }).success(function(status, data, headers, config) {
          return $scope.addAlert("Din ansökan är nu skickad", "success");
        }).error(function(status, data, headers, config) {
          return $scope.addAlert("Misslyckades skicka ansökan, prova igen eller vänligen kontakta oss", "error");
        });
      };
      $scope.load = function() {
        return $http({
          url: "/api/employees/login",
          data: $scope.input.login,
          method: "POST"
        }).success(function(status, data, headers, config) {
          $scope.input.employee = status;
          return $scope.addAlert("Lyckades logga in och hämta din information", "success");
        }).error(function(status, data, headers, config) {
          return $scope.addAlert("Inloggningen misslyckades", "error");
        });
      };
      $scope.addAlert = function(msg, type) {
        return $scope.alerts.push({
          'msg': msg,
          'type': type
        });
      };
      $scope.closeAlert = function(index) {
        return $scope.alerts.splice(index, 1);
      };
      $scope.removePet = function(id) {
        return $scope.input.employee.petIds = _.filter($scope.input.employee.petIds, function(petId) {
          return petId !== id;
        });
      };
      $scope.addPet = function(id) {
        if (!$scope.containsPet(id)) {
          return $scope.input.employee.petIds.push(id);
        } else {
          return $scope.removePet(id);
        }
      };
      $scope.containsPet = function(id) {
        return _.contains($scope.input.employee.petIds, id);
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
      return google.maps.event.addListener(autocomplete, 'place_changed', function() {
        var place;

        place = autocomplete.getPlace();
        $scope.input.employee.address.streetNumber = $scope.getAddressType(place.address_components, 'street_number');
        $scope.input.employee.address.street = $scope.getAddressType(place.address_components, 'route');
        $scope.input.employee.address.postalCode = $scope.getAddressType(place.address_components, 'postal_code');
        $scope.input.employee.address.postalTown = $scope.getAddressType(place.address_components, 'postal_town');
        $scope.input.employee.address.country = $scope.getAddressType(place.address_components, 'country');
        $scope.input.employee.address.area = $scope.getAddressType(place.address_components, 'administrative_area_level_1');
        $scope.input.employee.address.latitude = place.geometry.location.jb;
        return $scope.input.employee.address.longitude = place.geometry.location.kb;
      });
    }
  ]);

}).call(this);
