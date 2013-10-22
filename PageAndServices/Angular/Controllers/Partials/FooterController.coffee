window.app.controller 'FooterController', 

['$scope', '$state', 'CategoryService', 'AlertService',
( $scope,   $state,   CategoryService,   AlertService) ->

    # GET ALL CATEGORIES

    CategoryService.getAll()
        .success (data, status, headers, config) ->
            $scope.categories = _.filter data, (item) ->
                item.parentId == null
        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Misslyckades att hämta tjänsterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'

    # GO TO SERVICE

    $scope.goToService = (serviceId) ->
        $state.go 'service', { 'serviceId': serviceId }

]