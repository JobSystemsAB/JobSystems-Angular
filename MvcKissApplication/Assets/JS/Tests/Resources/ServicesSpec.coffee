describe 'Testing Administrator-Service', ->
    service = null
    httpBackend = null


    beforeEach ->
    
        module 'HomeApp'
    
        inject ($httpBackend, AdministratorService) ->
            httpBackend = $httpBackend
            service = AdministratorService
    
    afterEach ->
        httpBackend.verifyNoOutstandingExpectation()
        httpBackend.verifyNoOutstandingRequest()


    it 'should have an exciteText function', -> 
        expect(angular.isFunction(service.exciteText)).toBe true
  
    it 'should make text exciting', ->
        result = service.exciteText 'bar'
        expect(result).toBe 'bar!!!'

    it 'should send the msg and return the response.', ->
        returnData = { excited: true }
        httpBackend.expectGET('somthing.json?msg=wee').respond returnData
        
        test = { handler: -> {} }
        spyOn test, 'handler'
    
        returnedPromise = svc.sendMessage 'wee'
        returnedPromise.then test.handler
        httpBackend.flush()
    
        expect(test.handler).toHaveBeenCalledWith returnData