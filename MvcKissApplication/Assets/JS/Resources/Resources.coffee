angular.module('services', ['ngResource'])

    .factory('Administrator', ['$resource', ($resource) ->
        $resource '/api/administrator/:id', { id: '@id' }, { update: { method: 'PUT' } }])

    .factory('Category', ['$resource', ($resource) ->
        $resource '/api/category/:id', { id: '@id' }, { update: { method: 'PUT' } }])

    .factory('CompanyCustomer', ['$resource', ($resource) ->
        $resource '/api/companycustomer/:id', { id: '@id' }, { update: { method: 'PUT' } }])

    .factory('Customer', ['$resource', ($resource) ->
        $resource '/api/customer/:id', { id: '@id' }, { update: { method: 'PUT' } }])

    .factory('Employee', ['$resource', ($resource) ->
        $resource '/api/employee/:id', { id: '@id' }, { update: { method: 'PUT' } }])

    .factory('Mission', ['$resource', ($resource) ->
        $resource '/api/mission/:id', { id: '@id' }, { update: { method: 'PUT' } }])
    
    .factory('PrivateCustomer', ['$resource', ($resource) ->
        $resource '/api/privatecustomer/:id', { id: '@id' }, { update: { method: 'PUT' } }])

    .factory('Subcategory', ['$resource', ($resource) ->
        $resource '/api/subcategory/:id', { id: '@id' }, { update: { method: 'PUT' } }])
        
    .factory('Subsubcategory', ['$resource', ($resource) ->
        $resource '/api/subsubcategory/:id', { id: '@id' }, { update: { method: 'PUT' } }])
        
    .factory('WorkShift', ['$resource', ($resource) ->
        $resource '/api/workshift/:id', { id: '@id' }, { update: { method: 'PUT' } }])