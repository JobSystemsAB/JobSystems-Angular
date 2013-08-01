# This type of controller declaration doesnt bloat the global namespace and also is minification-safe
window.app.controller 'AnimalIndexController', ['$scope','$http','CustomerPrivate','MissionPet','Pet', ($scope, $http, CustomerPrivate, MissionPet, Pet) ->

    ## -- CONSTRUCTOR

    $scope.output = {}

    $scope.input = {}
    $scope.input.mission = {}
    $scope.input.mission.address = {}
    $scope.input.mission.startDate = new Date()
    $scope.input.mission.startTime = new Date(2000, 1, 1, 12, 0, 0, 0)

    $scope.validate = {}

    ## -- VARIABLES

    $scope.firstTime = true;
    $scope.output.pets = Pet.query()

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

    $scope.getAddressType = (address_components, type) ->
        temp = _.find address_components, (component) ->
            return _.contains component.types, type
        if temp
            return temp.long_name
        else
            return null

    ## -- FRONT END METHODS

    $scope.validate.address = ->
        return $scope.input.mission.address.area == "Stockholms län"

    $scope.order = ->
        $scope.input.customer.address = $scope.input.mission.address
        customer = new CustomerPrivate($scope.input.customer)

        console.log "Creating costumer"

        customer.$save(
            (data) ->
                console.log "Customer created ", data.id
                $scope.createMission data.id            
            , (err) ->
                console.log "error" )
        
    $scope.createMission = (customerId) ->
        $scope.input.mission.customerId = customerId
        missionPet = new MissionPet($scope.input.mission)

        missionPet.$save(
            (data) ->
                console.log data            
            , (err) ->
                console.log "error" )
        

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