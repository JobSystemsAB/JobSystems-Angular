window.PerformerTimereportController = ($scope, $rootScope, $http) ->

    $scope.assignments = []

    $http
        method: 'GET'
        url: 'api/performer/5/Assigments'
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