(function() {
  describe('Testing Administrator-Service', function() {
    var httpBackend, service;

    service = null;
    httpBackend = null;
    beforeEach(function() {
      module('HomeApp');
      return inject(function($httpBackend, AdministratorService) {
        httpBackend = $httpBackend;
        return service = AdministratorService;
      });
    });
    afterEach(function() {
      httpBackend.verifyNoOutstandingExpectation();
      return httpBackend.verifyNoOutstandingRequest();
    });
    it('should have an exciteText function', function() {
      return expect(angular.isFunction(service.exciteText)).toBe(true);
    });
    it('should make text exciting', function() {
      var result;

      result = service.exciteText('bar');
      return expect(result).toBe('bar!!!');
    });
    return it('should send the msg and return the response.', function() {
      var returnData, returnedPromise, test;

      returnData = {
        excited: true
      };
      httpBackend.expectGET('somthing.json?msg=wee').respond(returnData);
      test = {
        handler: function() {
          return {};
        }
      };
      spyOn(test, 'handler');
      returnedPromise = svc.sendMessage('wee');
      returnedPromise.then(test.handler);
      httpBackend.flush();
      return expect(test.handler).toHaveBeenCalledWith(returnData);
    });
  });

}).call(this);
