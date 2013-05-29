window.DatabaseTableAssignmentController = ($scope, $rootScope, Assignment, Client, Performer) ->
    
    $scope.assignments = Assignment.query()
    $scope.clients = Client.query()
    $scope.performers = Performer.query()

    # Sorting of the table
    # Default sorting option 'id'
    $scope.orderOption = 'id'
    $scope.sort = (newOrderOption) ->
        $scope.orderOption = newOrderOption

    # Remove an assignment
    $scope.delete = (id) ->
        # Remove from database
        assignment = _.find $scope.assignments, (assignment) ->
            assignment.id == id

        assignment.$delete(
            (data) ->
                # Remove from collection
                $scope.assignments = _.filter $scope.assignments, (assignment) ->
                    assignment.id != id

                $rootScope.$broadcast 'infoMessage', "Uppdrag borttaget"
                $scope.close()
            , (err) ->
                $rootScope.$broadcast 'infoMessage', err.status + ": " + err.data.ExceptionMessage )

    # Save or uppdate an assignment
    $scope.save = ->
        if $scope.currentAssignment.id
            $scope.currentAssignment.$update(
                (data) ->
                    $rootScope.$broadcast 'infoMessage', "Uppdrag uppdaterat"
                    $scope.close()
                , (err) ->
                    $rootScope.$broadcast 'infoMessage', err.status + ": " + err.data.ExceptionMessage )
        else
            $scope.currentAssignment.$save(
                (data) ->
                    $scope.assignments.push $scope.currentAssignment
                    $rootScope.$broadcast 'infoMessage', "Uppdrag sparat"
                    $scope.close()
                , (err) ->
                    $rootScope.$broadcast 'infoMessage', err.status + ": " + err.data.ExceptionMessage )

    # Open popup with assignment info
    $scope.open = (id) ->
        # Get assignment from collection if id is defined
        # Else create a new one

        if id
            $scope.currentAssignment = _.find $scope.assignments, (assignment) ->
                assignment.id == id
        else
            $scope.currentAssignment = new Assignment()

        $scope.shouldBeOpen = true

    # Close popup with assignment info
    $scope.close = () ->
        $scope.shouldBeOpen = false

    # Popup options
    $scope.opts = 
        backdropFade: true
        dialogFade: true