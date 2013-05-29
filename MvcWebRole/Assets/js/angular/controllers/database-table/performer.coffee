window.DatabaseTablePerformerController = ($scope, $rootScope, Performer) ->
    
    $scope.performers = Performer.query()

    $scope.dateOptions = 
        changeYear: true
        changeMonth: true
        yearRange: '1900:-0'

    # Sorting of the table
    # Default sorting option 'id'
    $scope.orderOption = 'id'
    $scope.sort = (newOrderOption) ->
        $scope.orderOption = newOrderOption

    # Remove a performer
    $scope.delete = (id) ->
        # Remove from database
        performer = _.find $scope.performers, (performer) ->
            performer.id == id
 
        performer.$delete(
            (data) ->
                # Remove from collection
                $scope.performers = _.filter $scope.performers, (performer) ->
                    performer.id != id

                $rootScope.$broadcast 'infoMessage', "Uförare borttagen"
                $scope.close()
            , (err) ->
                $rootScope.$broadcast 'infoMessage', err.status + ": " + err.data.ExceptionMessage )

    # Save or uppdate a performer
    $scope.save = ->

        $scope.currentPerformer.password = String CryptoJS.SHA3 $scope.currentPerformer.password, { outputLength: 256 }

        if $scope.currentPerformer.id
            $scope.currentPerformer.$update( 
                (data) ->
                    $rootScope.$broadcast 'infoMessage', "Utförare uppdaterad"
                    $scope.close()
                (err) ->
                    $rootScope.$broadcast 'infoMessage', err.status + ": " + err.data.ExceptionMessage )
        else
            $scope.currentPerformer.$save( 
                (data) ->
                    $scope.performers.push $scope.currentPerformer
                    $rootScope.$broadcast 'infoMessage', "Utförare sparad"
                    $scope.close()
                (err) ->
                    $rootScope.$broadcast 'infoMessage', err.status + ": " + err.data.ExceptionMessage )
    
    # Open popup with performer info
    $scope.open = (id) ->
        # Get performer from collection if id is defined
        # Else create a new one
        if id
            $scope.currentPerformer = _.find $scope.performers, (performer) ->
                performer.id == id
        else
            $scope.currentPerformer = new Performer()

        $scope.shouldBeOpen = true

    # Close popup with administrator info
    $scope.close = ->
        $scope.shouldBeOpen = false

    # Popup options
    $scope.opts =
        backdropFade: true
        dialogFade: true