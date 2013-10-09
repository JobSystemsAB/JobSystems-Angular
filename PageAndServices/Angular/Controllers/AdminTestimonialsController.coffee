window.app.controller 'AdminTestimonialsController', 

['$scope', 'TestimonialService', 'AlertService',
( $scope,   TestimonialService,   AlertService) ->

    # LOAD DATA

    TestimonialService.getAllByLanguage('sv')
        .success (data, status, headers, config) ->
            $scope.testimonials = data
        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Failed to load all testimonials'

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

    $scope.update = (testimonial) ->
        TestimonialService.put(testimonial)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Successfully updated the testimonial.'
            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Failed to update the testimonial'

    $scope.delete = (testimonial) ->
        TestimonialService.delete(testimonial.id)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Successfully deleted the testimonial.'
                $scope.testimonials = _.reject $scope.testimonials, (temp) ->
                    temp.id == testimonial.id
            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Failed to delete the testimonial'

]