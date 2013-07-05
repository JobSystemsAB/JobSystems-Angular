window.PerformerTimefreeController = ($scope, CalendarService, PerformerTimeFree) ->

    # -- METHODS -- #

    $scope.resetTimes = ->
        $scope.times = [
            { id: 0, text: '08:00 - 12:00', checked: false }
            { id: 1, text: '13:00 - 16:00', checked: false }
            { id: 2, text: '17:00 - 20:00', checked: false }
        ]

    $scope.checkTime = (id) ->
        $scope.times[id].checked = !$scope.times[id].checked
        $scope.save()

    $scope.save = ->
        data = {}
        data.performerId = 5
        data.day = CalendarService.getDate()
        data.morning = $scope.times[0].checked
        data.afternoon = $scope.times[1].checked
        data.evening = $scope.times[2].checked

        performerTimeFree = new PerformerTimeFree data
        performerTimeFree.$save(
            (data) ->
                console.log data
            , (err) ->
                console.log err )

        #CalendarService.saveTimes(data)

    $scope.$on 'CalendarService.update', ( event, date ) ->
        $scope.resetTimes()
        $scope.input.date = CalendarService.getDate()

    $scope.$on 'CalendarService.ready', ( event) ->
        CalendarService.getFreeTimes(5)

    # -- INIT -- #
    
    $scope.input = {}
    $scope.input.date = CalendarService.getDate()

    $scope.resetTimes()