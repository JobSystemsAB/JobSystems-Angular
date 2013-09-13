(function() {
  window.app.controller('CategoryController', [
    '$scope', '$http', '$routeParams', 'CategoryService', 'Mission', 'MissionService', 'Category', 'CustomerService', 'PrivateCustomer', 'CompanyCustomer', 'GoogleMapsService', function($scope, $http, $routeParams, CategoryService, Mission, MissionService, Category, CustomerService, PrivateCustomer, CompanyCustomer, GoogleMapsService) {
      var autocomplete, google_address_search;

      $scope.getCustomer = function() {
        return CustomerService.getCustomer($scope.input.customer.email, $scope.input.customer.password).success(function(data, status, headers, config) {
          return $scope.input.customer = data;
        }).error(function(data, status, headers, config) {
          return console.log(status);
        });
      };
      $scope.isCompanyCustomer = function() {
        return $scope.input.customer.type === 'company';
      };
      $scope.saveMission = function() {
        var mission;

        mission = new Mission($scope.input.mission);
        return mission.$save(function(data) {
          return console.log(data);
        }, function(error) {
          return console.log(error);
        });
      };
      $scope.order = function() {
        var customer;

        customer = null;
        if ($scope.isCompanyCustomer()) {
          customer = new ComapnyCustomer($scope.input.customer);
        } else {
          customer = new PrivateCustomer($scope.input.customer);
        }
        return customer.$save(function(data) {
          return $scope.input.mission.customerId = data.id;
        }, function(error) {
          return console.log(error);
        });
      };
      $scope.output = {};
      $scope.input = {};
      $scope.input.customer = {};
      $scope.input.mission = {};
      $scope.input.mission.address = {};
      $scope.input.mission.description = "";
      $scope.input.customer.type = "private";
      $scope.uiConfig = {
        calendar: {
          height: 450,
          editable: true,
          header: {
            left: '',
            center: 'title',
            right: 'today prev,next'
          }
        }
      };
      $scope.eventSources = [];
      CategoryService.getTree().success(function(data, status, headers, config) {
        return $scope.categories = data;
      }).error(function(data, status, headers, config) {
        return console.log(status);
      });
      google_address_search = document.getElementById('google-address-search');
      autocomplete = new google.maps.places.Autocomplete(google_address_search);
      return google.maps.event.addListener(autocomplete, 'place_changed', function() {
        var place;

        place = autocomplete.getPlace();
        $scope.input.mission.address.latitude = place.geometry.location.lat();
        $scope.input.mission.address.longitude = place.geometry.location.lng();
        $scope.input.mission.address.streetNumber = GoogleMapsService.getAddressType(place.address_components, 'street_number');
        $scope.input.mission.address.street = GoogleMapsService.getAddressType(place.address_components, 'route');
        $scope.input.mission.address.postalCode = GoogleMapsService.getAddressType(place.address_components, 'postal_code');
        $scope.input.mission.address.postalTown = GoogleMapsService.getAddressType(place.address_components, 'postal_town');
        $scope.input.mission.address.country = GoogleMapsService.getAddressType(place.address_components, 'country');
        return $scope.input.mission.address.area = GoogleMapsService.getAddressType(place.address_components, 'administrative_area_level_1');
      });
    }
  ]);

}).call(this);
