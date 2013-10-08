window.app.controller 'HomeBookingController', 

['$scope', '$stateParams', '$http', 'CategoryService', 'GoogleMapsService', 'TextService', 'AlertService', 'MissionService', 'PrivateCustomerService', 'CompanyCustomerService',
( $scope,   $stateParams,   $http,   CategoryService,   GoogleMapsService,   TextService,   AlertService,   MissionService,   PrivateCustomerService,   CompanyCustomerService) ->

    # INIT

    
    $scope.category = []

    # METHOD: GET IS COMPANY CUSTOMER
    
    $scope.isCompanyCustomer = ->
        $scope.customer.type == 'company'

    # METHOD: SAVE MISSION
    
    $scope.saveMission = ->
        
        $scope.getAddress()

        $scope.mission.date = $scope.selectedEvent.start
        $scope.mission.extras = angular.toJson _.map $scope.inputs, (input) ->
            return { 'id': input.id, 'value': input.value }

        MissionService.post $scope.mission
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Uppdrag skapades.'
            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Misslyckades skapa uppdraget, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'

    # METHOD: SAVE ORDER
    
    $scope.order = ->
        if $scope.isCompanyCustomer()
            CompanyCustomerService.post($scope.customer)
                .success (data, status, headers, config) ->
                    AlertService.addAlert 'success', 'Kund skapad.'
                .error (data, status, headers, config) ->
                    AlertService.addAlert 'danger', 'Misslyckades skapa kund, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'

        else
            PrivateCustomerService.post($scope.customer)
                .success (data, status, headers, config) ->
                    AlertService.addAlert 'success', 'Kund skapad.'
                .error (data, status, headers, config) ->
                    AlertService.addAlert 'danger', 'Misslyckades skapa kund, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'
    
    # METHOD: LOAD CATEGORY TREE

    CategoryService.getTree()
        .success (data, status, headers, config) ->
            $scope.categories = data
            if $stateParams.serviceId
                $scope.category[1] = _.find $scope.categories.children, (child) ->
                    child.data.id = $stateParams.serviceId
                $scope.getInputs()

        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Misslyckades med att hämta kategorier, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'

    # LOAD TEXTS

    TextService.getAllByControllerAndLanguage('HomeBookingPageController', 'sv')
        .success (data, status, headers, config) ->
            $scope.textsOriginal = data
            $scope.texts = _.groupBy $scope.textsOriginal, (text) -> 
                text.elementId
        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Misslyckades med att hämta texter, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'

    # METHOD: LOAD EXTRA INPUTS
    
    $scope.getInputs = ->
        CategoryService.getInputs($scope.category[1].data.id)
            .success (data, status, headers, config) ->
                $scope.inputs = data
            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Misslyckades med att hämta extra informationsfält, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'
    
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

    # METHOD: SAVE CHANGES

    $scope.save = ->

        TextService.postAll($scope.textsOriginal)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Texter sparade.'
            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Misslyckades att spara texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'

    # GOOGLE ADDRESS LISTENER
    
    $scope.getAddress = ->
        place = $scope.mission.fullAddress

        $scope.mission.address.latitude = place.geometry.location.lat()
        $scope.mission.address.longitude = place.geometry.location.lng()
        
        $scope.mission.address.streetNumber = GoogleMapsService.getAddressType place.address_components, 'street_number'
        $scope.mission.address.street = GoogleMapsService.getAddressType place.address_components, 'route'
        $scope.mission.address.postalCode = GoogleMapsService.getAddressType place.address_components, 'postal_code'
        $scope.mission.address.postalTown = GoogleMapsService.getAddressType place.address_components, 'postal_town'
        $scope.mission.address.country = GoogleMapsService.getAddressType place.address_components, 'country'
        $scope.mission.address.area = GoogleMapsService.getAddressType place.address_components, 'administrative_area_level_1'

        console.log $scope.mission.address
    
    ###
    google.maps.event.addListener $scope.autocomplete, 'place_changed', ->
        place = $scope.autocomplete.getPlace()

        $scope.mission.address.latitude = place.geometry.location.lat()
        $scope.mission.address.longitude = place.geometry.location.lng()
        
        $scope.mission.address.streetNumber = GoogleMapsService.getAddressType place.address_components, 'street_number'
        $scope.mission.address.street = GoogleMapsService.getAddressType place.address_components, 'route'
        $scope.mission.address.postalCode = GoogleMapsService.getAddressType place.address_components, 'postal_code'
        $scope.mission.address.postalTown = GoogleMapsService.getAddressType place.address_components, 'postal_town'
        $scope.mission.address.country = GoogleMapsService.getAddressType place.address_components, 'country'
        $scope.mission.address.area = GoogleMapsService.getAddressType place.address_components, 'administrative_area_level_1'
    ###
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
    
    #$scope.google_address_search = document.getElementById 'google-address-search'
    #$scope.autocomplete = new google.maps.places.Autocomplete $scope.google_address_search
    
    # DIBS
    
    $scope.dibs = ->

        $scope.dibsInput = {}

        $scope.dibsInput.test = "1"

        $scope.dibsInput.merchant = "90151568"
        $scope.dibsInput.currency = "SEK"
        $scope.dibsInput.orderId = "213455"
        $scope.dibsInput.amount = "375"
        $scope.dibsInput.language = "sv_SE"

        $scope.dibsInput.billingFirstName = "John"
        $scope.dibsInput.billingLastName = "Doe"
        $scope.dibsInput.billingAddress = "Danderydsgatan 28"
        $scope.dibsInput.billingPostalCode = "11426"
        $scope.dibsInput.billingPostalPlace = "Stockholm"
        $scope.dibsInput.billingEmail = "misael@jobsystems.se"
        $scope.dibsInput.billingMobile = "+46704333005"

        $scope.dibsInput.oiTypes = "QUANTITY;UNITCODE;DESCRIPTION;AMOUNT;ITEMID;VATAMOUNT"
        $scope.dibsInput.oiNames = "Items;UnitCode;Description;Amount;ItemId;VatAmount"
        $scope.dibsInput.oiRow1 = "1;pcs;ACME Rocket Roller skates\; ultra fast;100;98;25"
        $scope.dibsInput.oiRow2 = "1;pcs;ACME Band Aid;100;99;25"
        $scope.dibsInput.oiRow3 = "1;pcs;Some description;100;45;25"

        $scope.dibsInput.acceptReturnUrl = "https://yourdomain.com/acceptReturnUrl"
        $scope.dibsInput.cancelReturnUrl = "https://yourdomain.com/cancelReturnUrl"
        $scope.dibsInput.callbackUrl = "https://yourdomain.com/callbackUrl"

        console.log angular.toJson $scope.dibsInput

        delete $http.defaults.headers.common['X-Requested-With']
        $http.defaults.headers.common = { "Access-Control-Request-Headers": "accept, origin, authorization" }
        $http
            url: "https://sat1.dibspayment.com/dibspaymentwindow/entrypoint"
            method: "POST"
            data: $scope.dibsInput
        .success (data, status, headers, config) ->
            console.log "yay", data, status, headers, config
        .error (data, status, headers, config) ->
            console.log "nay", data, status, headers, config


        $http
            url: "https://sat1.dibspayment.com/dibspaymentwindow/entrypoint"
            method: "JSONP"
            data: $scope.dibsInput
        .success (data, status, headers, config) ->
            console.log "yay", data, status, headers, config
        .error (data, status, headers, config) ->
            console.log "nay", data, status, headers, config
    
]