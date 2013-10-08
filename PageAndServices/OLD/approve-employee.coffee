# CoffeeScript
window.app.controller 'ApproveEmployeeController', ['$scope','$http', ($scope, $http) ->

    ## -- CONSTRUCTOR

    ## -- VARIABLES

    $http
        url: "/api/employees/GetAllPet"
        method: "GET"
    .success (status, data, headers, config) -> 
        $scope.employees = status
        $scope.addAlert "Din ansökan är nu skickad", "success"
    .error (status, data, headers, config) -> 
        $scope.addAlert "Misslyckades skicka ansökan, prova igen eller vänligen kontakta oss", "error"

    ## -- INTERNAL METHODS

    ## -- EXTERNAL METHODS

    ## -- INITIALIZE

    ## -- LISTENERS

]