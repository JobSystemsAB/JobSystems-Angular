window.app.controller 'TestimonialsController', 

['$scope', 'TextService', 'TestimonialService',
( $scope,   TextService,   TestimonialService) ->

    # STATIC DATA

    $scope.text-files = ['testimonials-title']

    # LOAD DATA

    TextService.getTexts('TestimonialsController', 'sv')
        .success (data, status, headers, config) ->
            $scope.textsOriginal = data
            $scope.texts = _.groupBy $scope.textsOriginal, (text) -> 
                text.elementId
            console.log status
        .error (data, status, headers, config) ->
            console.log status

    TestimonialService.getTestimonials('sv')
        .success (data, status, headers, config) ->
            $scope.testimonials = data
            console.log status
        .error (data, status, headers, config) ->
            console.log status

    # SAVE DATA

    $scope.save = ->
        
        TextService.saveTexts($scope.textsOriginal)
            .success (data, status, headers, config) ->
                console.log status
            .error (data, status, headers, config) ->
                console.log status

        TestimonialService.saveTestimonials($scope.testimonials)
            .success (data, status, headers, config) ->
                console.log status
            .error (data, status, headers, config) ->
                console.log status



]