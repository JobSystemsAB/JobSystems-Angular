window.app.controller 'AlertController', 

['$scope', 'AlertService', 
( $scope,   AlertService) ->

    $scope.closeAlert = (index) ->
        AlertService.closeAlert index, 1

]