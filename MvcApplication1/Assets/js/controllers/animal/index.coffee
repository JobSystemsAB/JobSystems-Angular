# This type of controller declaration doesnt bloat the global namespace and also is minification-safe
window.app.controller 'AnimalIndexController', ['$scope','$http','Customer','Mission', ($scope, $http, Customer, Mission) ->

    ## -- CONSTRUCTOR

    $scope.input = {}
    $scope.input.mission = {}
    $scope.input.mission.address = {}
    $scope.input.mission.date = new Date()

    $scope.validate = {}

    ## -- VARIABLES

    $scope.firstTime = true;

    # options for the date
    $scope.dateOptions = 
        monthNames: ['Januari','Februari','Mars','April','Maj','Juni','Juli','Augusti','September','Oktober','November','December']
        monthNamesShort: ['Jan','Feb','Mar','Apr','Maj','Jun','Jul','Aug','Sep','Okt','Nov','Dec']
        dayNamesShort: ['Sön','Mån','Tis','Ons','Tor','Fre','Lör']
        dayNames: ['Söndag','Måndag','Tisdag','Onsdag','Torsdag','Fredag','Lördag']
        dayNamesMin: ['Sö','Må','Ti','On','To','Fr','Lö']
        weekHeader: 'Ve'
        dateFormat: 'yy-mm-dd'
        firstDay: 1
        isRTL: false

    ## -- HELPER METHODS

    # get info from google address components
    $scope.getAddressType = (address_components, type) ->
        temp = _.find address_components, (component) ->
            return _.contains component.types, type
        if temp
            return temp.long_name
        else
            return null

    ## -- FRONT END METHODS

    # validate given address
    $scope.validate.address = ->
        return $scope.input.mission.address.area == "Stockholms län"

    # order button klick
    $scope.order = ->
        customer = new Customer($scope.input.customer)
        mission = new Mission($scope.input.mission)

    $scope.load = ->
        $http
            url: "/api/customers/login"
            data: $scope.input.login
            method: "POST"
        .success (status, data, headers, config) -> 
           $scope.input.customer = status    
        .error (status, data, headers, config) -> 
            console.log data
            console.log status    

    ## -- INITIALIZING

    input = document.getElementById 'google-address-search'
    autocomplete = new google.maps.places.Autocomplete input

    ## -- LISTENER

    # address changed on google search
    google.maps.event.addListener autocomplete, 'place_changed', ->
        place = autocomplete.getPlace()

        $scope.input.mission.address.streetNumber = $scope.getAddressType place.address_components, 'street_number'
        $scope.input.mission.address.street = $scope.getAddressType place.address_components, 'route'
        $scope.input.mission.address.postalCode = $scope.getAddressType place.address_components, 'postal_code'
        $scope.input.mission.address.postalTown = $scope.getAddressType place.address_components, 'postal_town'
        $scope.input.mission.address.country = $scope.getAddressType place.address_components, 'country'
        $scope.input.mission.address.area = $scope.getAddressType place.address_components, 'administrative_area_level_1'
        $scope.input.mission.address.latitude = place.geometry.location.jb
        $scope.input.mission.address.longitude = place.geometry.location.kb

]