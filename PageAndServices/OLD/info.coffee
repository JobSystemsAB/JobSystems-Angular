window.InfoController = ($scope, $timeout) ->

    $scope.infos = []

    $scope.currentTime = ->
        now = new Date()

        hour = String now.getHours()
        minute = String now.getMinutes()
        second = String now.getSeconds()

        if hour.length < 2
            hour = "0" + hour
        if minute.length < 2
            minute = "0" + minute
        if second.length < 2
            second = "0" + second

        return hour + ":" + minute + ":" + second

    $scope.add = (message) ->
        $scope.infos.push
            message: message,
            time: $scope.currentTime()

    $scope.remove = ->
        $scope.infos.pop()

    $scope.$on 'infoMessage', (e, args) ->
        $scope.add args
        $timeout $scope.remove, 5000