(function() {
  window.app.service('AlertService', [
    '$http', '$rootScope', '$timeout', function($http, $rootScope, $timeout) {
      this.closeAlert = function(index) {
        return $rootScope.alerts.splice(index, 1);
      };
      return this.addAlert = function(type, message) {
        if ($rootScope.alerts === void 0) {
          $rootScope.alerts = [];
        }
        $rootScope.alerts.push({
          'type': type,
          'msg': message
        });
        return $timeout(function() {
          return $rootScope.alerts.splice(0, 1);
        }, 10000);
      };
    }
  ]);

}).call(this);
