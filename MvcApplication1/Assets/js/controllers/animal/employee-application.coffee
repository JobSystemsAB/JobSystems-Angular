# This type of controller declaration doesnt bloat the global namespace and also is minification-safe
window.app.controller 'EmployeeApplicationController', ['$scope','$http','Pet', ($scope, $http, Pet) ->

    ## -- CONSTRUCTOR

    $scope.output = {}

    $scope.input = {}
    $scope.input.employee = {}
    $scope.input.employee.petIds = []
    $scope.input.employee.address = {}

    ## -- INITIALIZING

    input = document.getElementById 'google-address-search'
    autocomplete = new google.maps.places.Autocomplete input

    ## -- VARIABLES

    $scope.output.pets = Pet.query()

    ## -- FRONT END METHODS

    $scope.order = ->
        $http
            url: "/api/employees/CreatePet"
            data: $scope.input.employee
            method: "POST"
        .success (status, data, headers, config) -> 
            console.log "done"    
        .error (status, data, headers, config) -> 
            console.log "fail"

    $scope.load = ->
        $http
            url: "/api/employees/login"
            data: $scope.input.login
            method: "POST"
        .success (status, data, headers, config) -> 
           $scope.input.employee = status    
        .error (status, data, headers, config) -> 
            console.log "fail"  

    ## -- HELPER METHODS

    $scope.removePet = (id) ->
        $scope.input.employee.petIds = _.filter $scope.input.employee.petIds, (petId) ->
            petId != id

    $scope.addPet = (id) ->
        if !$scope.containsPet id
            $scope.input.employee.petIds.push id
        else
            $scope.removePet id

    $scope.containsPet = (id) ->
        _.contains $scope.input.employee.petIds, id

    $scope.getAddressType = (address_components, type) ->
        temp = _.find address_components, (component) ->
            return _.contains component.types, type
        if temp
            return temp.long_name
        else
            return null

    ## -- LISTENER

    google.maps.event.addListener autocomplete, 'place_changed', ->
        place = autocomplete.getPlace()

        $scope.input.employee.address.streetNumber = $scope.getAddressType place.address_components, 'street_number'
        $scope.input.employee.address.street = $scope.getAddressType place.address_components, 'route'
        $scope.input.employee.address.postalCode = $scope.getAddressType place.address_components, 'postal_code'
        $scope.input.employee.address.postalTown = $scope.getAddressType place.address_components, 'postal_town'
        $scope.input.employee.address.country = $scope.getAddressType place.address_components, 'country'
        $scope.input.employee.address.area = $scope.getAddressType place.address_components, 'administrative_area_level_1'
        $scope.input.employee.address.latitude = place.geometry.location.jb
        $scope.input.employee.address.longitude = place.geometry.location.kb
]