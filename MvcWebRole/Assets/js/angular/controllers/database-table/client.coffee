window.DatabaseTableClientController = ($scope, $rootScope, Client) ->
    $scope.clients = Client.query()

    # Sorting of the table
    # Default sorting option 'id'
    $scope.orderOption = 'id'
    $scope.sort = (newOrderOption) ->
        $scope.orderOption = newOrderOption

    # Remove a client
    $scope.delete = (id) ->
        # Remove from database
        client = _.find $scope.clients, (client) ->
            client.id == id

        client.$delete(
            (data) ->
                # Remove from collection
                $scope.clients = _.filter $scope.clients, (client) ->
                    client.id != id

                $rootScope.$broadcast 'infoMessage', "Kund borttagen"
                $scope.close()
            , (err) ->
                $rootScope.$broadcast 'infoMessage', err.status + ": " + err.data.ExceptionMessage )

    # Save or uppdate a client
    $scope.save = ->
        if $scope.currentClient.id
            $scope.currentClient.$update(
                (data) ->
                    $rootScope.$broadcast 'infoMessage', "Kund uppdaterad"
                    $scope.close()
                , (err) ->
                    $rootScope.$broadcast 'infoMessage', err.status + ": " + err.data.ExceptionMessage )
        else
            $scope.currentClient.$save( 
                (data) ->
                    $scope.clients.push $scope.currentClient
                    $rootScope.$broadcast 'infoMessage', "Kund sparad"
                    $scope.close()
                , (err) ->
                    $rootScope.$broadcast 'infoMessage', err.status + ": " + err.data.ExceptionMessage )

    # Open popup with client info
    $scope.open = (id) ->
        # Get client from collection if id is defined
        # Else create a new one
        if id 
            $scope.currentClient = _.find $scope.currentClient, (client) ->
                client.id == id
        else
            $scope.currentClient = new Client()

        $scope.shouldBeOpen = true

    # Close popup with client info
    $scope.close = ->
        $scope.shouldBeOpen = false

    # Popup options
    $scope.opts = 
        backdropFade: true
        dialogFade: true