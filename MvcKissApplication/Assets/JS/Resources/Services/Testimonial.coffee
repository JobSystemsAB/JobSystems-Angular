window.app.service('TestimonialService', [ '$http', ($http) ->
    
    this.getTestimonials = (language) ->
        $http
            url: "/api/testimonial?language=" + language 
            method: "GET"

    this.saveTestimonials = (testimonials) ->
        $http
            url: "/api/testimonial/saveTestimonials" 
            method: "POST"
            data: testimonials

])