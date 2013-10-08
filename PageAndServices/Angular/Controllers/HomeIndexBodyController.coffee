window.app.controller 'HomeIndexBodyController', 

['$scope', '$state', 'AlertService', 'CategoryService', 'TestimonialService', 'TextService',
( $scope,   $state,   AlertService,   CategoryService,   TestimonialService,   TextService) ->
    
    $scope.isAdmin = true

    # STATIC DATA

    google.maps.visualRefresh = true

    angular.extend $scope,
        center:
            latitude: 59.344679
            longitude: 18.071171
        markers: [ { latitude: 59.344679, longitude: 18.071171 }]
        zoom: 15

    # INIT TEXTS

    $scope.controllerName = 'homeindex'

    $scope.textsOriginal = [
        { controllerName: $scope.controllerName, language: 'sv', elementId: 'services-title', text: 'services-title' }
        { controllerName: $scope.controllerName, language: 'sv', elementId: 'services-text', text: 'services-text' }
        { controllerName: $scope.controllerName, language: 'sv', elementId: 'title-window-text', text: 'title-window-text' }
        { controllerName: $scope.controllerName, language: 'sv', elementId: 'title-window-button', text: 'title-window-button' }
        { controllerName: $scope.controllerName, language: 'sv', elementId: 'price-title', text: 'price-title' }
        { controllerName: $scope.controllerName, language: 'sv', elementId: 'price-short', text: 'price-short' }
        { controllerName: $scope.controllerName, language: 'sv', elementId: 'price-read-more', text: 'price-read-more' }
        { controllerName: $scope.controllerName, language: 'sv', elementId: 'why-title', text: 'why-title' }
        { controllerName: $scope.controllerName, language: 'sv', elementId: 'why-short', text: 'why-short' }
        { controllerName: $scope.controllerName, language: 'sv', elementId: 'why-read-more', text: 'why-read-more' }
        { controllerName: $scope.controllerName, language: 'sv', elementId: 'about-title', text: 'about-title' }
        { controllerName: $scope.controllerName, language: 'sv', elementId: 'about-short', text: 'about-short' }
        { controllerName: $scope.controllerName, language: 'sv', elementId: 'about-read-more', text: 'about-read-more' }
        { controllerName: $scope.controllerName, language: 'sv', elementId: 'map-title', text: 'map-title' }
        { controllerName: $scope.controllerName, language: 'sv', elementId: 'map-short', text: 'map-short' }
        { controllerName: $scope.controllerName, language: 'sv', elementId: 'map-address', text: 'map-address' }
        { controllerName: $scope.controllerName, language: 'sv', elementId: 'map-phone-number', text: 'map-phone-number' }
        { controllerName: $scope.controllerName, language: 'sv', elementId: 'map-email', text: 'map-email' }
        { controllerName: $scope.controllerName, language: 'sv', elementId: 'testimonials-title', text: 'testimonials-title' }
        { controllerName: $scope.controllerName, language: 'sv', elementId: 'book-now-button', text: 'book-now-button' }
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

    # LOAD DATA

    TextService.getAllByControllerAndLanguage($scope.controllerName, 'sv')
        .success (data, status, headers, config) ->
            $scope.uniteTexts data
        .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Misslyckades att hämta texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'
    
    TestimonialService.getAllByLanguage('sv')
        .success (data, status, headers, config) ->
            $scope.testimonials = data
        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Misslyckades att spara referenser, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'

    CategoryService.getAll()
        .success (data, status, headers, config) ->
            $scope.categories = _.filter data, (item) ->
                item.parentId == null
        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Misslyckades att hämta tjänsterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'

    # SAVE DATA

    $scope.save = ->
        TextService.postAll($scope.textsOriginal)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Texter sparade.'
            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Misslyckades att spara texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'

        CategoryService.postAll($scope.categories)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Tjänster sparade.'
            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Misslyckades att spara tjänsterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'

        TestimonialService.postAll($scope.testimonials)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Referenser sparades.'
            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Misslyckades att spara referenserna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'


    # GO TO BOOKING

    $scope.goToBooking = ->
        $state.go 'book', { serviceUrl: $state.current.data.serviceName }

    $scope.goToLanding = (categoryId, categoryUrl) ->
        $state.go 'service', { serviceName: categoryUrl }

]