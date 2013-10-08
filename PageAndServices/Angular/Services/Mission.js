(function() {
  window.app.service('MissionService', [
    '$http', function($http) {
      this.connectCategories = function(missionId, categoryIds) {
        return $http({
          url: "/api/mission/" + missionId + "/connectcategories",
          data: {
            'missionId': missionId,
            'categoryIds': categoryIds
          },
          method: "POST"
        });
      };
      this.connectCustomer = function(missionId, customerId) {
        return $http({
          url: "/api/mission/" + missionId + "/connectcustomer",
          data: {
            'missionId': missionId,
            'customerId': customerId
          },
          method: "POST"
        });
      };
      this.connectEmployee = function(missionId, employeeId) {
        return $http({
          url: "/api/mission/" + missionId + "/connectemployee",
          data: {
            'missionId': missionId,
            'employeeId': employeeId
          },
          method: "POST"
        });
      };
      this.getEmployed = function() {
        return $http({
          url: "/api/mission/employed",
          method: "GET"
        });
      };
      this.getUnemployed = function() {
        return $http({
          url: "/api/mission/unemployed",
          method: "GET"
        });
      };
      return this.getDisabled = function() {
        return $http({
          url: "/api/mission/disabled",
          method: "GET"
        });
      };
    }
  ]);

}).call(this);
