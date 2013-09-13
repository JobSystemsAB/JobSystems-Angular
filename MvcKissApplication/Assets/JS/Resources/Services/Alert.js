(function() {
  window.app.service('AlertService', [
    '$http', '$rootScope', function($http, $rootScope) {
      this.addAlert = function(type, message) {
        if ($rootScope.alerts === void 0) {
          $rootScope.alerts = [];
        }
        return $rootScope.alerts.push({
          'type': type,
          'msg': message
        });
      };
      return this.closeAlert = function(index) {
        return $rootScope.alerts.splice(index, 1);
      };
    }
  ]);

}).call(this);
