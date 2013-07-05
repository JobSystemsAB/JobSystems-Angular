window.PerformerTimereportController = ($scope, $rootScope, $http, PerformerTimeReport) ->

    $scope.assignments = []
    
    $scope.input = {}
    $scope.input.timereport = {}
    $scope.input.timereport.performerId = 3
    #$scope.input.timereport.performerId = 5

    $http
        method: 'GET'
        url: 'api/performer/' + $scope.input.timereport.performerId + '/Assigments'
    .
    success (data, status) ->
        $scope.status = status
        $scope.assignments = data
    .
    error (data, status) ->
        $scope.data = data || "Request failed"
        $scope.status = status

    $scope.dateOptions = 
        monthNames: ['Januari','Februari','Mars','April','Maj','Juni','Juli','Augusti','September','Oktober','November','December']
        monthNamesShort: ['Jan','Feb','Mar','Apr','Maj','Jun','Jul','Aug','Sep','Okt','Nov','Dec']
        dayNamesShort: ['Sön','Mån','Tis','Ons','Tor','Fre','Lör']
        dayNames: ['Söndag','Måndag','Tisdag','Onsdag','Torsdag','Fredag','Lördag']
        dayNamesMin: ['Sö','Må','Ti','On','To','Fr','Lö']
        weekHeader: 'Ve'
        dateFormat: 'yy-mm-dd'
        firstDay: 1
        isRTL: false

    $scope.changeAssignment = ->
        if $scope.input.timereport.assignmentId
            $http
                method: 'GET'
                url: 'api/performer/TimeReports?performerId=' + $scope.input.timereport.performerId + '&assignmentId=' + $scope.input.timereport.assignmentId
            .success (data, status) ->
                $scope.timereports = data
            .error (data, status) ->
                console.log 'failed!'
        else
            $scope.timereports = null

    $scope.createTimereport = ->
        
        inputData = new TimeReport($scope.input.timereport)

        inputData.$save(
            (data) ->
                if !$scope.timereports
                    $scope.timereports = []
                $scope.timereports.push data
            , (err) ->
                console.log 'error' )