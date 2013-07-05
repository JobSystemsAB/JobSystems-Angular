(function() {
  angular.module('services', ['ngResource']).factory('Administrator', [
    '$resource', function($resource) {
      return $resource('/api/administrators/:id', {
        id: '@id'
      }, {
        update: {
          method: 'PUT'
        }
      });
    }
  ]).factory('Employee', [
    '$resource', function($resource) {
      return $resource('api/employees/:id', {
        id: '@id'
      }, {
        update: {
          method: 'PUT'
        }
      });
    }
  ]).factory('Customer', [
    '$resource', function($resource) {
      return $resource('api/customers/:id', {
        id: '@id'
      }, {
        update: {
          method: 'PUT'
        }
      });
    }
  ]).factory('Mission', [
    '$resource', function($resource) {
      return $resource('api/customermissions/:id', {
        id: '@id'
      }, {
        update: {
          method: 'PUT'
        }
      });
    }
  ]).factory('Pet', [
    '$resource', function($resource) {
      return $resource('api/pets/:id', {
        id: '@id'
      }, {
        update: {
          method: 'PUT'
        }
      });
    }
  ]);

}).call(this);
