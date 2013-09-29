window.app.controller 'HomeBookingPageController', 

['$scope', '$stateParams', 'CategoryService', 'GoogleMapsService', 'CompanyCustomer', 'Mission', 'PrivateCustomer',
( $scope,   $stateParams,   CategoryService,   GoogleMapsService,   CompanyCustomer,   Mission,   PrivateCustomer) ->

    # METHOD: GET IS COMPANY CUSTOMER
    
    $scope.isCompanyCustomer = ->
        $scope.customer.type == 'company'
    
    # METHOD: SAVE MISSION
    
    $scope.saveMission = ->
        
        $scope.mission.date = $scope.selectedEvent.start
        $scope.mission.extras = angular.toJson _.map $scope.inputs, (input) ->
            return { 'id': input.id, 'value': input.value }

        mission = new Mission $scope.mission

        mission.$save(
            (data) ->
                console.log data
            , (error) ->
                console.log error
        )
    
    # METHOD: SAVE ORDER
    
    $scope.order = ->
        customer = null
        if $scope.isCompanyCustomer()
            customer = new CompanyCustomer $scope.customer
        else
            customer = new PrivateCustomer $scope.customer
        
        customer.$save(
            (data) ->
                $scope.mission.customerId = data.id
            , (error) ->
                console.log error
        )
    
    # METHOD: LOAD CATEGORY TREE
    
    CategoryService.getTree()
        .success (data, status, headers, config) ->
            $scope.categories = data
            if $stateParams.serviceId
                $scope.category1 = _.find $scope.categories.children, (child) ->
                    child.data.id = $stateParams.serviceId
                $scope.getInputs()
            console.log status
        .error (data, status, headers, config) ->
            console.log status
    
    # METHOD: LOAD EXTRA INPUTS
    
    $scope.getInputs = ->
        CategoryService.getCategoryInputs($scope.category1.data.id)
            .success (data, status, headers, config) ->
                $scope.inputs = data
                console.log status
            .error (data, status, headers, config) ->
                console.log status
    
    # METHOD: LOAD CALENDAR EVENTS
    
    $scope.loadEvents = ->
        todayDate = new Date()
        startDate = $scope.myCalendar.fullCalendar('getDate')
        startMonth = startDate.getMonth()
        
        result = []
        while startDate.getMonth() == startMonth
            if startDate > todayDate
                result.push { title: '08:00', start: startDate.toLocaleDateString() + " 08:00:00" }
                result.push { title: '12:00', start: startDate.toLocaleDateString() + " 12:00:00" }
                result.push { title: '17:00', start: startDate.toLocaleDateString() + " 17:00:00" }
            
            startDate.setDate startDate.getDate() + 1

        $scope.eventSources[0].events = result
    
    # GOOGLE ADDRESS LISTENER
    
    google.maps.event.addListener autocomplete, 'place_changed', ->
        place = autocomplete.getPlace()

        $scope.mission.address.latitude = place.geometry.location.lat()
        $scope.mission.address.longitude = place.geometry.location.lng()
        
        $scope.mission.address.streetNumber = GoogleMapsService.getAddressType place.address_components, 'street_number'
        $scope.mission.address.street = GoogleMapsService.getAddressType place.address_components, 'route'
        $scope.mission.address.postalCode = GoogleMapsService.getAddressType place.address_components, 'postal_code'
        $scope.mission.address.postalTown = GoogleMapsService.getAddressType place.address_components, 'postal_town'
        $scope.mission.address.country = GoogleMapsService.getAddressType place.address_components, 'country'
        $scope.mission.address.area = GoogleMapsService.getAddressType place.address_components, 'administrative_area_level_1'
    
    # STATIC DATA

    $scope.mission = { description: '' }
    $scope.customer = { type: 'private' }
    
    # CALENDAR STATIC DATA
    
    $scope.uiConfig = 
        calendar:
            height: 250,
            editable: true,
            header:
                left: ''
                center: 'title'
                right: 'today prev,next'
            viewRender: ->
                $scope.loadEvents()
            eventClick: (event) ->
                $scope.selectedEvent = event
                $scope.$apply()

    $scope.eventSources = [{
        events: []
        color: '#0CB45D'   
        textColor: 'white' 
    }]
    
    # GOOGLE ADDRESS STATIC DATA
    
    google_address_search = document.getElementById 'google-address-search'
    autocomplete = new google.maps.places.Autocomplete google_address_search
    
]