(function() {
  angular.module('services', ['ngResource']).factory('Administrator', [
    '$resource', function($resource) {
      return $resource('api/administrator/:id', {
        id: '@id'
      }, {
        update: {
          method: 'PUT'
        }
      });
    }
  ]).factory('Performer', [
    '$resource', function($resource) {
      return $resource('api/performer/:id', {
        id: '@id'
      }, {
        update: {
          method: 'PUT'
        }
      });
    }
  ]).factory('Assignment', [
    '$resource', function($resource) {
      return $resource('api/assignment/:id', {
        id: '@id'
      }, {
        update: {
          method: 'PUT'
        }
      });
    }
  ]).factory('TimeReport', [
    '$resource', function($resource) {
      return $resource('api/timereport/:id', {
        id: '@id'
      }, {
        update: {
          method: 'PUT'
        }
      });
    }
  ]).factory('Client', [
    '$resource', function($resource) {
      return $resource('api/client/:id', {
        id: '@id'
      }, {
        update: {
          method: 'PUT'
        }
      });
    }
  ]);

}).call(this);
