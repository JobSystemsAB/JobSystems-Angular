(function() {
  window.app.controller('HomeBookingPageController', [
    '$scope', '$stateParams', 'CategoryService', 'GoogleMapsService', 'CompanyCustomer', 'Mission', 'PrivateCustomer', function($scope, $stateParams, CategoryService, GoogleMapsService, CompanyCustomer, Mission, PrivateCustomer) {
      var autocomplete, google_address_search;

      $scope.isCompanyCustomer = function() {
        return $scope.customer.type === 'company';
      };
      $scope.saveMission = function() {
        var mission;

        $scope.mission.date = $scope.selectedEvent.start;
        $scope.mission.extras = angular.toJson(_.map($scope.inputs, function(input) {
          return {
            'id': input.id,
            'value': input.value
          };
        }));
        mission = new Mission($scope.mission);
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
          customer = new CompanyCustomer($scope.customer);
        } else {
          customer = new PrivateCustomer($scope.customer);
        }
        return customer.$save(function(data) {
          return $scope.mission.customerId = data.id;
        }, function(error) {
          return console.log(error);
        });
      };
      CategoryService.getTree().success(function(data, status, headers, config) {
        $scope.categories = data;
        if ($stateParams.serviceId) {
          $scope.category1 = _.find($scope.categories.children, function(child) {
            return child.data.id = $stateParams.serviceId;
          });
          $scope.getInputs();
        }
        return console.log(status);
      }).error(function(data, status, headers, config) {
        return console.log(status);
      });
      $scope.getInputs = function() {
        return CategoryService.getCategoryInputs($scope.category1.data.id).success(function(data, status, headers, config) {
          $scope.inputs = data;
          return console.log(status);
        }).error(function(data, status, headers, config) {
          return console.log(status);
        });
      };
      $scope.loadEvents = function() {
        var result, startDate, startMonth, todayDate;

        todayDate = new Date();
        startDate = $scope.myCalendar.fullCalendar('getDate');
        startMonth = startDate.getMonth();
        result = [];
        while (startDate.getMonth() === startMonth) {
          if (startDate > todayDate) {
            result.push({
              title: '08:00',
              start: startDate.toLocaleDateString() + " 08:00:00"
            });
            result.push({
              title: '12:00',
              start: startDate.toLocaleDateString() + " 12:00:00"
            });
            result.push({
              title: '17:00',
              start: startDate.toLocaleDateString() + " 17:00:00"
            });
          }
          startDate.setDate(startDate.getDate() + 1);
        }
        return $scope.eventSources[0].events = result;
      };
      google.maps.event.addListener(autocomplete, 'place_changed', function() {
        var place;

        place = autocomplete.getPlace();
        $scope.mission.address.latitude = place.geometry.location.lat();
        $scope.mission.address.longitude = place.geometry.location.lng();
        $scope.mission.address.streetNumber = GoogleMapsService.getAddressType(place.address_components, 'street_number');
        $scope.mission.address.street = GoogleMapsService.getAddressType(place.address_components, 'route');
        $scope.mission.address.postalCode = GoogleMapsService.getAddressType(place.address_components, 'postal_code');
        $scope.mission.address.postalTown = GoogleMapsService.getAddressType(place.address_components, 'postal_town');
        $scope.mission.address.country = GoogleMapsService.getAddressType(place.address_components, 'country');
        return $scope.mission.address.area = GoogleMapsService.getAddressType(place.address_components, 'administrative_area_level_1');
      });
      $scope.mission = {
        description: ''
      };
      $scope.customer = {
        type: 'private'
      };
      $scope.uiConfig = {
        calendar: {
          height: 250,
          editable: true,
          header: {
            left: '',
            center: 'title',
            right: 'today prev,next'
          },
          viewRender: function() {
            return $scope.loadEvents();
          },
          eventClick: function(event) {
            $scope.selectedEvent = event;
            return $scope.$apply();
          }
        }
      };
      $scope.eventSources = [
        {
          events: [],
          color: '#0CB45D',
          textColor: 'white'
        }
      ];
      google_address_search = document.getElementById('google-address-search');
      return autocomplete = new google.maps.places.Autocomplete(google_address_search);
    }
  ]);

}).call(this);
