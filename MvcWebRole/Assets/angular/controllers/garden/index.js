(function() {
  window.GardenIndexController = function($scope, $http, Performer) {
    var autocomplete, input;

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
    input = document.getElementById('google-address-search');
    autocomplete = new google.maps.places.Autocomplete(input);
    google.maps.event.addListener(autocomplete, 'place_changed', function() {
      var place;

      place = autocomplete.getPlace();
      $scope.inputForm.assignment.address.streetNumber = $scope.getAddressType(place.address_components, 'street_number');
      $scope.inputForm.assignment.address.street = $scope.getAddressType(place.address_components, 'route');
      $scope.inputForm.assignment.address.postalCode = $scope.getAddressType(place.address_components, 'postal_code');
      $scope.inputForm.assignment.address.postalTown = $scope.getAddressType(place.address_components, 'postal_town');
      return $scope.inputForm.assignment.address.country = $scope.getAddressType(place.address_components, 'country');
    });
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
    $scope.inputForm = {};
    $scope.inputForm.selectedTasks = [];
    $scope.inputForm.selectedPerformers = [];
    $scope.inputForm.assignment = {};
    $scope.inputForm.assignment.address = {};
    $scope.inputForm.customer = {};
    $scope.inputForm.assignment.date = new Date();
    $scope.inputForm.login = false;
    $scope.inputForm.assignment.times = 1;
    $scope.inputForm.assignment.duration = 1;
    $scope.inputForm.assignment.toolsAvailable = true;
    $scope.inputForm.customer.type = 1;
    $http({
      url: "/api/knowledge/Category?categoryId=1",
      method: "GET"
    }).success(function(status, data, headers, config) {
      return $scope.tasks = status;
    });
    $scope.removeTask = function(taskId) {
      return $scope.inputForm.selectedTasks = _.filter($scope.inputForm.selectedTasks, function(listTaskId) {
        return listTaskId !== taskId;
      });
    };
    $scope.addTask = function(taskId) {
      if (!$scope.containsTask(taskId)) {
        return $scope.inputForm.selectedTasks.push(taskId);
      } else {
        return $scope.removeTask(taskId);
      }
    };
    $scope.containsTask = function(taskId) {
      return _.contains($scope.inputForm.selectedTasks, taskId);
    };
    $scope.performers = Performer.query();
    $scope.removePerformer = function(performerId) {
      return $scope.inputForm.selectedPerformers = _.filter($scope.inputForm.selectedPerformers, function(listedPerformerId) {
        return listedPerformerId !== performerId;
      });
    };
    $scope.addPerformer = function(performerId) {
      if (!$scope.containsPerformer(performerId)) {
        return $scope.inputForm.selectedPerformers.push(performerId);
      } else {
        return $scope.removePerformer(performerId);
      }
    };
    $scope.containsPerformer = function(performerId) {
      return _.contains($scope.inputForm.selectedPerformers, performerId);
    };
    $scope.previewPerformer = function(performer) {
      return $scope.selectedPerformer = performer;
    };
    $scope.closePreview = function() {
      return $scope.selectedPerformer = null;
    };
    $scope.performerIsSelected = function(performerId) {
      return _.contains($scope.selectedPerformers, performerId);
    };
    $scope.getAge = function(dateString) {
      var age, birthDate, m, today;

      if (!dateString) {
        return 0;
      }
      today = new Date();
      birthDate = new Date(dateString);
      age = today.getFullYear() - birthDate.getFullYear();
      m = today.getMonth() - birthDate.getMonth();
      if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        age--;
      }
      return age;
    };
    $scope.getDate = function(dateTimeString) {
      if (!dateTimeString) {
        return "";
      }
      return dateTimeString.split('T')[0];
    };
    return $scope.order = function() {
      return console.log($scope.inputForm);
    };
  };

}).call(this);
