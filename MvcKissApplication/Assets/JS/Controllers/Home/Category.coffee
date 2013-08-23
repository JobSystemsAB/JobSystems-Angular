# This type of controller declaration doesnt bloat the global namespace and also is minification-safe

window.app.controller 'CategoryController', 

['$scope', '$http', '$routeParams', 'Mission', 'MissionService', 'Category', 'CategoryService', 'Subcategory', 'SubcategoryService', 'CustomerService', 'PrivateCustomer', 'CompanyCustomer', 'GoogleMapsService', 
( $scope,   $http,   $routeParams,   Mission,   MissionService,   Category,   CategoryService,   Subcategory,   SubcategoryService,   CustomerService,   PrivateCustomer,   CompanyCustomer,   GoogleMapsService) ->

    # -- FRONT METHODS

    $scope.updateSubcategory = ->
        $scope.output.subcategories = []
        $scope.output.subsubcategories = []
        CategoryService.getSubcategories($scope.input.mission.categoryId)
            .success (data, status, headers, config) ->
                $scope.output.subcategories = data

        CategoryService.getCategoryInputs($scope.input.mission.categoryId)
            .success (data, status, headers, config) ->
                $scope.output.inputs = data

    $scope.updateSubsubcategory = ->
        $scope.output.subsubcategories = []
        SubcategoryService.getSubsubcategories($scope.input.mission.subcategoryId)
            .success (data, status, headers, config) ->
                $scope.output.subsubcategories = data

    $scope.getCustomer = ->
        CustomerService.getCustomer($scope.input.customer.email, $scope.input.customer.password)
            .success (data, status, headers, config) ->
                $scope.input.customer = data

    $scope.isCompanyCustomer = ->
        $scope.input.customer.type == 'company'

    $scope.hasSubcategory = ->
        $scope.output.subcategories && $scope.output.subcategories.length > 0

    $scope.hasSubsubcategory = ->
        $scope.output.subsubcategories && $scope.output.subsubcategories.length > 0

    $scope.connect = ->

        if $scope.result.customer.id && $scope.result.mission.id

            MissionService.connectCustomer $scope.result.mission.id, $scope.result.customer.id

        if $scope.result.mission.id
        
            if $scope.input.mission.subsubcategoryId
                MissionService.connectSubsubcategory $scope.result.mission.id, $scope.input.mission.subsubcategoryId
            else if $scope.input.mission.subcategoryId
                MissionService.connectSubcategory $scope.result.mission.id, $scope.input.mission.subcategoryId
            else
                MissionService.connectCategory $scope.result.mission.id, $scope.input.mission.categoryId

    $scope.order = ->
        
        if $scope.input.customer.type == 'private'
            $scope.result.customer = new PrivateCustomer $scope.input.customer
        else
            $scope.result.customer = new ComapnyCustomer $scope.input.customer

        $scope.result.mission = new Mission $scope.input.mission

        $scope.$watch 'result.mission.id', $scope.connect
        $scope.$watch 'result.customer.id', $scope.connect

        $scope.result.customer.$save()
        $scope.result.mission.$save()

        ###
    $scope.order = ->

        if $scope.input.customer.type == 'private'
            $scope.result.customer = new PrivateCustomer $scope.input.customer
        else
            $scope.result.customer = new ComapnyCustomer $scope.input.customer
        
        $scope.result.customer.$save(
            (data) ->
                $scope.result.mission = new Mission $scope.input.mission
                $scope.result.mission.$save(
                    (data) ->

                        MissionService.connectCustomer $scope.result.mission.id, $scope.result.customer.id

                        if $scope.input.subsubcategoryId
                            MissionService.connectSubsubcategory $scope.result.mission.id, $scope.input.subsubcategoryId
                        else if $scope.input.subcategoryId
                            MissionService.connectSubcategory $scope.result.mission.id, $scope.input.subcategoryId
                        else
                            MissionService.connectSubcategory $scope.result.mission.id, $scope.input.categoryId
                    (err) ->
                        console.log "error save mission"
                )        
            , (err) ->
                console.log "error save customer"
        )
          ###  

        #$scope.customerObject.$save(
        #    (data) ->
        #        console.log "Customer created ", data.id
        #        $scope.createMission data.id            
        #    , (err) ->
        #        console.log "error" )

    # -- INIT

    $scope.result = {}
    $scope.output = {}
    $scope.input = {}
    $scope.input.customer = {}
    $scope.input.mission = {}
    $scope.input.mission.address = {}

    $scope.input.mission.description = ""
    $scope.input.customer.type = "private"

    $scope.output.categories = Category.query ->
        $scope.input.mission.categoryId = $routeParams.categoryId
        $scope.updateSubcategory()

    # -- GOOGLE MAPS INIT

    google.maps.visualRefresh = true;

    angular.extend $scope,
        center:
            latitude: 59.32893
            longitude: 18.06491
        markers: []
        zoom: 12

    # -- GOOGLE JAVASCRIPT - Possible to make more Angular?

    google_address_search = document.getElementById 'google-address-search'
    autocomplete = new google.maps.places.Autocomplete google_address_search

    ## -- LISTENERS

    google.maps.event.addListener autocomplete, 'place_changed', ->
        place = autocomplete.getPlace()

        $scope.input.mission.address.latitude = place.geometry.location.lat()
        $scope.input.mission.address.longitude = place.geometry.location.lng()

        position = 
            latitude: $scope.input.mission.address.latitude
            longitude: $scope.input.mission.address.longitude

        $scope.markers = [ position ]
        $scope.center = position
        $scope.zoom = 16

        $scope.input.mission.address.streetNumber = GoogleMapsService.getAddressType place.address_components, 'street_number'
        $scope.input.mission.address.street = GoogleMapsService.getAddressType place.address_components, 'route'
        $scope.input.mission.address.postalCode = GoogleMapsService.getAddressType place.address_components, 'postal_code'
        $scope.input.mission.address.postalTown = GoogleMapsService.getAddressType place.address_components, 'postal_town'
        $scope.input.mission.address.country = GoogleMapsService.getAddressType place.address_components, 'country'
        $scope.input.mission.address.area = GoogleMapsService.getAddressType place.address_components, 'administrative_area_level_1'

        
]   