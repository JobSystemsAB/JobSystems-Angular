﻿# This type of controller declaration doesnt bloat the global namespace and also is minification-safe

window.app.controller 'CategoryController', 

['$scope', '$http', '$routeParams', 'CategoryService', 'Mission', 'MissionService', 'Category', 'CustomerService', 'PrivateCustomer', 'CompanyCustomer', 'GoogleMapsService', 
( $scope,   $http,   $routeParams,   CategoryService,   Mission,   MissionService,   Category,   CustomerService,   PrivateCustomer,   CompanyCustomer,   GoogleMapsService) ->

    # -- FRONT METHODS

    # Get existing customer
    $scope.getCustomer = ->
        CustomerService.getCustomer($scope.input.customer.email, $scope.input.customer.password)
            .success (data, status, headers, config) ->
                $scope.input.customer = data
            .error (data, status, headers, config) ->
                console.log status

    # Check if it is company customer
    $scope.isCompanyCustomer = ->
        $scope.input.customer.type == 'company'

    # Save mission information
    $scope.saveMission = ->
        
        mission = new Mission $scope.input.mission
        mission.$save(
            (data) ->
                console.log data
            , (error) ->
                console.log error
        )

    # Send order
    $scope.order = ->
        customer = null
        if $scope.isCompanyCustomer()
            customer = new ComapnyCustomer $scope.input.customer
        else
            customer = new PrivateCustomer $scope.input.customer
        
        customer.$save(
            (data) ->
                $scope.input.mission.customerId = data.id
            , (error) ->
                console.log error
        )
        

    # -- INIT

    $scope.output = {}
    $scope.input = {}
    $scope.input.customer = {}
    $scope.input.mission = {}
    $scope.input.mission.address = {}

    $scope.input.mission.description = ""
    $scope.input.customer.type = "private"

    # Calendar config
    $scope.uiConfig = 
        calendar:
            height: 450,
            editable: true,
            header:
                left: '',
                center: 'title',
                right: 'today prev,next'

    $scope.eventSources = []

    # Get tree information
    CategoryService.getTree()
        .success (data, status, headers, config) ->
            $scope.categories = data
        .error (data, status, headers, config) ->
            console.log status

    # -- GOOGLE JAVASCRIPT - Possible to make more Angular?

    google_address_search = document.getElementById 'google-address-search'
    autocomplete = new google.maps.places.Autocomplete google_address_search

    ## -- LISTENERS

    google.maps.event.addListener autocomplete, 'place_changed', ->
        place = autocomplete.getPlace()

        $scope.input.mission.address.latitude = place.geometry.location.lat()
        $scope.input.mission.address.longitude = place.geometry.location.lng()
        
        $scope.input.mission.address.streetNumber = GoogleMapsService.getAddressType place.address_components, 'street_number'
        $scope.input.mission.address.street = GoogleMapsService.getAddressType place.address_components, 'route'
        $scope.input.mission.address.postalCode = GoogleMapsService.getAddressType place.address_components, 'postal_code'
        $scope.input.mission.address.postalTown = GoogleMapsService.getAddressType place.address_components, 'postal_town'
        $scope.input.mission.address.country = GoogleMapsService.getAddressType place.address_components, 'country'
        $scope.input.mission.address.area = GoogleMapsService.getAddressType place.address_components, 'administrative_area_level_1'

        
]   