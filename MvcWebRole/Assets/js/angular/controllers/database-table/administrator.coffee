window.DatabaseTableAdministratorsController = ($scope, $rootScope, Administrator) ->
    
    $scope.administrators = Administrator.query()

    # Sorting of the table
    # Default sorting option 'id'
    $scope.orderOption = 'id'
    $scope.sort = (newOrderOption) ->
        $scope.orderOption = newOrderOption

    # Remove an administrator
    $scope.delete = (id) ->
        # Remove from database
        admin = _.find $scope.administrators, (admin) ->
            admin.id == id

        admin.$delete( 
            (data) ->
                # Remove from collection
                $scope.administrators = _.filter $scope.administrators, (admin) ->
                    admin.id != id

                $rootScope.$broadcast 'infoMessage', "Administrator borttagen" 
                $scope.close()
            , (err) ->
                $rootScope.$broadcast 'infoMessage', err.status + ": " + err.data.ExceptionMessage )

    # Save or uppdate an administrator
    $scope.save = ->

        if $scope.currentAdmin.newPassword != null && $scope.currentAdmin.newPassword != ''
            $scope.currentAdmin.newPassword = String CryptoJS.SHA3 $scope.currentAdmin.newPassword, { outputLength: 256 }

        if $scope.currentAdmin.id
            $scope.currentAdmin.$update(
                (data) ->
                    $rootScope.$broadcast 'infoMessage', "Administrator uppdaterad"
                    $scope.close()
                , (err) ->
                    $rootScope.$broadcast 'infoMessage', err.status + ": " + err.data.ExceptionMessage )
        else
            $scope.currentAdmin.$save(
                (data) ->
                    $scope.administrators.push $scope.currentAdmin
                    $rootScope.$broadcast 'infoMessage', "Administrator sparad"
                    $scope.close()
                , (err) ->
                    $rootScope.$broadcast 'infoMessage', err.status + ": " + err.data.ExceptionMessage )

    # Open popup with administrator info
    $scope.open = (id) ->
        # Get administrator from collection if id is defined
        # Else create a new one
        if id
            $scope.currentAdmin = _.find $scope.administrators, (admin) ->
                admin.id == id
        else
            $scope.currentAdmin = new Administrator()

        $scope.shouldBeOpen = true

    # Close popup with administrator info
    $scope.close = ->
        $scope.shouldBeOpen = false

    # Popup options
    $scope.opts = 
        backdropFade: true
        dialogFade: true