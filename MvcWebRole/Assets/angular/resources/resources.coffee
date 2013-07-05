angular.module('services', ['ngResource'])

    .factory('Administrator', ['$resource', ($resource) ->
        $resource '/api/administrator/:id', { id: '@id' }, { update: { method: 'PUT' } }])

    .factory('Performer', ['$resource', ($resource) ->
        $resource 'api/performer/:id', { id: '@id' }, { update: { method: 'PUT' } }])

    .factory('Assignment', ['$resource', ($resource) ->
        $resource 'api/assignment/:id', { id: '@id' }, { update: { method: 'PUT' } }])
    
    .factory('PerformerTimeReport', ['$resource', ($resource) ->
        $resource 'api/performertimereport/:id', { id: '@id' }, { update: { method: 'PUT' } }])
   
    .factory('PerformerTimeFree', ['$resource', ($resource) ->
        $resource 'api/performertimefree/:id', { id: '@id' }, { update: { method: 'PUT' } }])

    .factory('Client', ['$resource', ($resource) ->
        $resource 'api/client/:id', { id: '@id' }, { update: { method: 'PUT' } }])