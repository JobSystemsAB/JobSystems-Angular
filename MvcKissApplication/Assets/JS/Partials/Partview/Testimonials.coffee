window.app.controller 'TestimonialsController', 

['$scope', 'AlertService', 'TextService', 'TestimonialService',
( $scope,   AlertService,   TextService,   TestimonialService) ->

    # STATIC DATA

    $scope.text-files = ['testimonials-title']

    # LOAD DATA

    TextService.getTexts('TestimonialsController', 'sv')
        .success (data, status, headers, config) ->
            $scope.textsOriginal = data
            $scope.texts = _.groupBy $scope.textsOriginal, (text) -> 
                text.elementId
        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Misslyckades att hämta texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'

    TestimonialService.getTestimonials('sv')
        .success (data, status, headers, config) ->
            $scope.testimonials = data
        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Misslyckades att spara referenser, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'

    # SAVE DATA

    $scope.save = ->
        
        TextService.saveTexts($scope.textsOriginal)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Tester sparades.'

            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Misslyckades att spara texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'


        TestimonialService.saveTestimonials($scope.testimonials)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Referenser sparades.'

            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Misslyckades att spara referenserna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'

]