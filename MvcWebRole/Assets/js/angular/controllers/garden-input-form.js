(function() {
  window.GardenInputFormCtrl = function($scope, Performer) {
    $scope.tasks = [
      {
        name: "Beskärning",
        value: 1
      }, {
        name: "Gräsklippning",
        value: 2
      }, {
        name: "Ogräskämpning",
        value: 3
      }, {
        name: "Upprusning av trädgård",
        value: 4
      }, {
        name: "Lövkrattning",
        value: 5
      }, {
        name: "Plantering",
        value: 6
      }, {
        name: "Bortforsling av trädgårdsavfall",
        value: 7
      }
    ];
    $scope.selectedTasks = [];
    $scope.removeTask = function(value) {
      return $scope.selectedTasks = _.filter($scope.selectedTasks, function(task) {
        return task.value !== value;
      });
    };
    $scope.addTask = function(task) {
      if (!_.contains($scope.selectedTasks, task)) {
        return $scope.selectedTasks.push(task);
      }
    };
    $scope.performers = Performer.query();
    $scope.selectedPerformers = [];
    $scope.addPerformer = function(performerId) {
      if (!_.contains($scope.selectedPerformers, performerId)) {
        return $scope.selectedPerformers.push(performerId);
      } else {
        return $scope.selectedPerformers = _.filter($scope.selectedPerformers, function(listedPerformerId) {
          return listedPerformerId !== performerId;
        });
      }
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
    return $scope.getDate = function(dateTimeString) {
      if (!dateTimeString) {
        return "";
      }
      return dateTimeString.split('T')[0];
    };
  };

}).call(this);
