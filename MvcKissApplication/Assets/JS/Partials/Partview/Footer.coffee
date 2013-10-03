window.app.controller 'FooterController', 

['$scope', '$state', 'TextService', 'CategoryService', 'AlertService',
( $scope,   $state,   TextService,   CategoryService,   AlertService) ->


    CategoryService.getAll()
        .success (data, status, headers, config) ->
            $scope.categories = _.filter data, (item) ->
                item.parentId == null
        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Misslyckades att hämta tjänsterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'

]