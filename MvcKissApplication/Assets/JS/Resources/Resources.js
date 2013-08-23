(function() {
  angular.module('services', ['ngResource']).factory('Administrator', [
    '$resource', function($resource) {
      return $resource('/api/administrator/:id', {
        id: '@id'
      }, {
        update: {
          method: 'PUT'
        }
      });
    }
  ]).factory('Category', [
    '$resource', function($resource) {
      return $resource('/api/category/:id', {
        id: '@id'
      }, {
        update: {
          method: 'PUT'
        }
      });
    }
  ]).factory('CompanyCustomer', [
    '$resource', function($resource) {
      return $resource('/api/companycustomer/:id', {
        id: '@id'
      }, {
        update: {
          method: 'PUT'
        }
      });
    }
  ]).factory('Customer', [
    '$resource', function($resource) {
      return $resource('/api/customer/:id', {
        id: '@id'
      }, {
        update: {
          method: 'PUT'
        }
      });
    }
  ]).factory('Employee', [
    '$resource', function($resource) {
      return $resource('/api/employee/:id', {
        id: '@id'
      }, {
        update: {
          method: 'PUT'
        }
      });
    }
  ]).factory('Mission', [
    '$resource', function($resource) {
      return $resource('/api/mission/:id', {
        id: '@id'
      }, {
        update: {
          method: 'PUT'
        }
      });
    }
  ]).factory('PrivateCustomer', [
    '$resource', function($resource) {
      return $resource('/api/privatecustomer/:id', {
        id: '@id'
      }, {
        update: {
          method: 'PUT'
        }
      });
    }
  ]).factory('Subcategory', [
    '$resource', function($resource) {
      return $resource('/api/subcategory/:id', {
        id: '@id'
      }, {
        update: {
          method: 'PUT'
        }
      });
    }
  ]).factory('Subsubcategory', [
    '$resource', function($resource) {
      return $resource('/api/subsubcategory/:id', {
        id: '@id'
      }, {
        update: {
          method: 'PUT'
        }
      });
    }
  ]).factory('WorkShift', [
    '$resource', function($resource) {
      return $resource('/api/workshift/:id', {
        id: '@id'
      }, {
        update: {
          method: 'PUT'
        }
      });
    }
  ]);

}).call(this);
