window.app.controller 'HomeBookingController', 

['$scope', '$state', '$stateParams', '$http', 'CategoryService', 'GoogleMapsService', 'TextService', 'AlertService', 'MissionService', 'PrivateCustomerService', 'CompanyCustomerService',
( $scope,   $state,   $stateParams,   $http,   CategoryService,   GoogleMapsService,   TextService,   AlertService,   MissionService,   PrivateCustomerService,   CompanyCustomerService) ->

    # INIT

    $scope.isAdmin = false
    $scope.category = []
    
    $scope.controllerName = 'homebooking' + $stateParams.serviceName
    $scope.currentLang = 'sv'
    
    $scope.textsOriginal = [
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'title-text', text: 'title-text' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'book-title', text: 'book-title' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'book-description', text: 'book-description' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'about-title', text: 'about-title' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'about-description', text: 'about-description' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'calendar-title', text: 'calendar-title' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'calendar-description', text: 'calendar-description' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'book-button', text: 'book-button' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'category-first', text: 'category-first' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'category-second', text: 'category-second' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'category-third', text: 'category-third' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'mission-description', text: 'mission-description' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'input-title', text: 'input-title' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'input-description', text: 'input-description' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'input-organisationNumber-description', text: 'input-organisationNumber-description' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'input-companyName-description', text: 'input-companyName-description' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'input-firstName-description', text: 'input-firstName-description' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'input-lastName-description', text: 'input-lastName-description' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'input-personalNumber-description', text: 'input-personalNumber-description' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'input-propertyName-description', text: 'input-propertyName-description' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'input-emailAddress-description', text: 'input-emailAddress-description' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'input-phoneNumber-description', text: 'input-phoneNumber-description' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'input-fullAddress-description', text: 'input-fullAddress-description' }
    ]

    # UNITE TEXTS

    $scope.uniteTexts = (data) ->
        originalGroup = _.groupBy $scope.textsOriginal, (text) -> 
                text.elementId
        dataGroup = _.groupBy data, (text) -> 
                text.elementId

        _.each dataGroup, (val, key) ->
            originalGroup[key] = val

        $scope.texts = originalGroup
        $scope.textsOriginal = _.map originalGroup, (val, key) ->
            val[0]

    # METHOD: GET IS COMPANY CUSTOMER
    
    $scope.isCompanyCustomer = ->
        $scope.customer.type == 'company'

    # METHOD: SAVE MISSION
    
    $scope.saveMission = ->

        $scope.mission.categoryIds = _.map $scope.category, (cat) ->
            cat.data.id
        $scope.mission.date = $scope.selectedEvent.start
        $scope.mission.extras = angular.toJson _.map $scope.inputs, (input) ->
            return { 'id': input.id, 'value': input.value }

        MissionService.postContact($scope.mission)
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
                    $scope.mission.customerId = data.id
                    $scope.saveMission()
                .error (data, status, headers, config) ->
                    AlertService.addAlert 'danger', 'Misslyckades skapa kund, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'

        else
            PrivateCustomerService.post($scope.customer)
                .success (data, status, headers, config) ->
                    AlertService.addAlert 'success', 'Kund skapad.'
                    $scope.mission.customerId = data.id
                    $scope.saveMission()
                .error (data, status, headers, config) ->
                    AlertService.addAlert 'danger', 'Misslyckades skapa kund, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'
    
   
    # LOAD DATA

    TextService.getAllByControllerAndLanguage($scope.controllerName, 'sv')
        .success (data, status, headers, config) ->
            $scope.uniteTexts data
        .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Misslyckades att hämta texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'
   
    CategoryService.getTree()
        .success (data, status, headers, config) ->
            $scope.categories = data
            if $stateParams.serviceName
                $scope.category[1] = _.find $scope.categories.children, (child) ->
                    child.data.url == $stateParams.serviceName
                $scope.getInputs()

        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Misslyckades med att hämta kategorier, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'
    
    $scope.getInputs = ->
        CategoryService.getInputs($scope.category[1].data.id)
            .success (data, status, headers, config) ->
                $scope.inputs = data
            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Misslyckades med att hämta extra informationsfält, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'
    
    $scope.goToBooking = (category) ->
        console.log category
        $state.go 'book', { serviceName: category.data.url }

    # METHOD: LOAD CALENDAR EVENTS
    
    $scope.loadEvents = (view) ->
        todayDate = new Date()
        startDate = view.calendar.getDate()
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

        if place && place.geometry

            $scope.mission.address = {}
            $scope.mission.address.position = {}

            $scope.mission.address.position.latitude = place.geometry.location.lat()
            $scope.mission.address.position.longitude = place.geometry.location.lng()
        
            $scope.mission.address.streetNumber = GoogleMapsService.getAddressType place.address_components, 'street_number'
            $scope.mission.address.street = GoogleMapsService.getAddressType place.address_components, 'route'
            $scope.mission.address.postalCode = GoogleMapsService.getAddressType place.address_components, 'postal_code'
            $scope.mission.address.postalTown = GoogleMapsService.getAddressType place.address_components, 'postal_town'
            $scope.mission.address.country = GoogleMapsService.getAddressType place.address_components, 'country'
            $scope.mission.address.area = GoogleMapsService.getAddressType place.address_components, 'administrative_area_level_1'
    
    # STATIC DATA
    
    $scope.mission = 
        description: ''
        hours: 0
    $scope.customer = { type: 'private' }

    $scope.$watch 'mission.fullAddress', ->
         $scope.getAddress()
    
    # CALENDAR STATIC DATA
    
    $scope.uiConfig = 
        calendar:
            height: 500,
            editable: true,
            header:
                left: ''
                center: 'title'
                right: 'today prev,next'
            viewRender: (view, element) ->
                $scope.loadEvents(view)
            eventClick: (event) ->
                $scope.selectedEvent = event
                $scope.$apply()
    
    $scope.eventSources = [{
        events: []
        color: '#0CB45D'   
        textColor: 'white' 
    }]
    
    # SELECT CATEGORY

    $scope.select = (categoryNr, categoryObject) ->
        $scope.category[categoryNr] = categoryObject

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