(function() {
  window.app.controller('HomeApplicationController', [
    '$scope', '$stateParams', 'CategoryService', 'GoogleMapsService', 'CompanyCustomer', 'Mission', 'PrivateCustomer', function($scope, $stateParams, CategoryService, GoogleMapsService, CompanyCustomer, Mission, PrivateCustomer) {
      $scope.category = [];
      CategoryService.getTree().success(function(data, status, headers, config) {
        return $scope.categories = data;
      });
      return $scope.categoryClicked = function(child, level) {
        $scope.category[level] = child;
        $scope.category[level + 1] = null;
        return $scope.category[level + 2] = null;
      };
    }
  ]);

}).call(this);
