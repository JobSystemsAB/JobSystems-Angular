window.app.controller 'AdminTestimonialsController', 

['$scope', '$modal', 'TestimonialService', 'AlertService',
( $scope,   $modal,   TestimonialService,   AlertService) ->

    # LOAD DATA

    TestimonialService.getAllByLanguage('sv')
        .success (data, status, headers, config) ->
            $scope.testimonials = data
        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Failed to load all testimonials'

    # GRID OPTIONS

    $scope.gridOptions = 
        data: 'testimonials'
        enableColumnResize: true
        enableRowSelection: true
        enableSorting: true
        multiSelect: false
        showGroupPanel: true
        afterSelectionChange: (data) ->
            $scope.open(data.entity)
        columnDefs: [
            { field: 'text', displayName: 'Text' }
            { field: 'name', displayName: 'Name' }
            { field: 'language', displayName: 'Language' }
        ]

    # OPEN MODAL

    $scope.open = (selected) ->
        modalInstance = $modal.open
            templateUrl: 'myModalContent.html'
            controller: ModalInstanceCtrl
            resolve:
                selected: ->
                    return angular.copy selected

        modalInstance.result.then (selected) ->
            $scope.selected = selectedItem;
        , ->
            console.log 'Modal dismissed at: ' + new Date()
    
    # MODAL CONTROLLER

    ModalInstanceCtrl = ($scope, $modalInstance, selected) ->
        $scope.selected = selected

    # SAVE

    $scope.save = ->
        $scope.newTestimonial.language = 'sv'
        $scope.newTestimonial.enabled = true

        TestimonialService.post($scope.newTestimonial)
            .success (data, status, headers, config) ->
                $scope.testimonials.push data
                $scope.newTestimonial = {}
                AlertService.addAlert 'success', 'Successfully saved the new testimonial.'
            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Failed to save the new testimonial'

    # UPDATE

    $scope.update = (testimonial) ->
        TestimonialService.put(testimonial)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Successfully updated the testimonial.'
            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Failed to update the testimonial'

    # DELETE

    $scope.delete = (testimonial) ->
        TestimonialService.delete(testimonial.id)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Successfully deleted the testimonial.'
                $scope.testimonials = _.reject $scope.testimonials, (temp) ->
                    temp.id == testimonial.id
            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Failed to delete the testimonial'

]