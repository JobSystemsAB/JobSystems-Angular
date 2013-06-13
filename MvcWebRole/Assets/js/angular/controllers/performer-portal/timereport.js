(function() {
  window.PerformerTimereportController = function($scope, $rootScope, $http) {
    $scope.assignments = [];
    $http({
      method: 'GET',
      url: 'api/performer/5/Assigments'
    }).success(function(data, status) {
      $scope.status = status;
      return $scope.assignments = data;
    }).error(function(data, status) {
      $scope.data = data || "Request failed";
      return $scope.status = status;
    });
    return $scope.dateOptions = {
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
  };

}).call(this);
