window.GardenPerformersOverviewCtrl = ($scope, $rootScope, Performer) ->

    $scope.performers = Performer.query()

    $scope.getAge = (dateString) ->

        if !dateString
            return 0

        today = new Date()
        birthDate = new Date(dateString)
        age = today.getFullYear() - birthDate.getFullYear()
        m = today.getMonth() - birthDate.getMonth()
        if m < 0 || (m == 0 && today.getDate() < birthDate.getDate())
            age--;

        return age

    $scope.getDate = (dateTimeString) ->
        
        if !dateTimeString
            return ""

        return dateTimeString.split('T')[0]
