window.app.controller 'HomeIndexController', 

['$scope', 'Category', 'AlertService', 'TextService',
( $scope,   Category,   AlertService,   TextService) ->

    # -- INIT

    $scope.output = {}

    Category.query(
        (data) ->
            $scope.output.categories = _.filter data, (item) ->
                item.parentId == null

        , (error) ->
            AlertService.addAlert('error', 'Fel: ' + error.status)

    )

    TextService.getTexts('HomeIndexController', 'sv')
        .success (data, status, headers, config)  ->
            $scope.texts = _.groupBy data, (iter) ->
                return iter.elementId
        .error (data, status, headers, config)  ->
            AlertService.addAlert('error', 'Fel: ' + error.status)


    # -- GOOGLE MAPS INIT

    google.maps.visualRefresh = true

    angular.extend $scope,
        center:
            latitude: 59.344679
            longitude: 18.071171
        markers: [ { latitude: 59.344679, longitude: 18.071171 }]
        zoom: 15

]