window.DatabaseTableTimeReportController = ($scope, $rootScope, TimeReport, Assignment, Performer) ->

    $scope.timeReports = TimeReport.query()
    $scope.assignments = Assignment.query()
    $scope.performers = Performer.query()

    # Sorting of the table
    # Default sorting option 'id'
    $scope.orderOption = 'id'
    $scope.sort = (newOrderOption) ->
        $scope.orderOption = newOrderOption

    # Remove a time report
    $scope.delete = (id) ->
        
        # Remove from database
        timeReport = _.find $scope.timeReports, (timeReport) ->
            timeReport.id == id

        timeReport.$delete(
            (data) ->
                # Remove from collection
                $scope.timeReports = _.filter $scope.timeReports, (timeReport) ->
                    timeReport.id != id
                $rootScope.$broadcast 'infoMessage', "Tidrapport borttagen"
                $scope.close()
            , (err) ->
                $rootScope.$broadcast 'infoMessage', err.status + ": " + err.data.ExceptionMessage )

    # Save or uppdate a time report
    $scope.save = ->
        
        if $scope.currentTimeReport.id
            
            $scope.currentTimeReport.$update(
                (data) ->
                    $rootScope.$broadcast 'infoMessage', "Tidrapport uppdaterad"
                    $scope.close()
                (err) ->
                    $rootScope.$broadcast 'infoMessage', err.status + ": " + err.data.ExceptionMessage )

        else
            $scope.currentTimeReport.$save(
                (data) ->
                    $scope.timeReports.push $scope.currentTimeReport
                    $rootScope.$broadcast 'infoMessage', "Tidrapport sparad"
                    $scope.close()
                (err) ->
                    $rootScope.$broadcast 'infoMessage', err.status + ": " + err.data.ExceptionMessage )

    # Open popup with time report info
    $scope.open = (id) ->
        # Get time report from collection if id is defined
        # Else create a new one
        if id
            $scope.currentTimeReport = _.find $scope.timeReports, (timeReport) ->
                timeReport.id == id
        else
            $scope.currentTimeReport = new TimeReport()

        $scope.shouldBeOpen = true;

    # Close popup with time report info
    $scope.close = ->
        $scope.shouldBeOpen = false;

    # Popup options
    $scope.opts = 
        backdropFade: true
        dialogFade: true