window.GardenInputFormCtrl = ($scope, Performer) ->

    $scope.tasks = [
        { name: "Beskärning", value: 1 }
        { name: "Gräsklippning", value: 2 }
        { name: "Ogräskämpning", value: 3 }
        { name: "Upprusning av trädgård", value: 4 }
        { name: "Lövkrattning", value: 5 }
        { name: "Plantering", value: 6 }
        { name: "Bortforsling av trädgårdsavfall", value: 7 }
    ]

    $scope.selectedTasks = []

    $scope.removeTask = (value) ->
        $scope.selectedTasks = _.filter $scope.selectedTasks, (task) ->
            task.value != value

    $scope.addTask = (task) ->
        if !_.contains $scope.selectedTasks, task
            $scope.selectedTasks.push task

    





    $scope.performers = Performer.query()

    $scope.selectedPerformers = []

    $scope.addPerformer = (performerId) ->
        if !_.contains $scope.selectedPerformers, performerId
            $scope.selectedPerformers.push performerId
        else
            $scope.selectedPerformers = _.filter $scope.selectedPerformers, (listedPerformerId) ->
                listedPerformerId != performerId

    $scope.performerIsSelected = (performerId) ->
        _.contains $scope.selectedPerformers, performerId

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
