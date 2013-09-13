(function() {
  describe('Testing Home-Index-Controller', function() {
    var $scope, ctrl, httpBackend;

    httpBackend = null;
    ctrl = null;
    $scope = null;
    beforeEach(function() {
      return this.addMatchers({
        toEqualData: function(expect) {
          return angular.equals(expect, this.actual);
        }
      });
    });
    beforeEach(module('HomeApp'));
    beforeEach(inject(function($rootScope, $controller, $httpBackend) {
      $scope = $rootScope.$new();
      httpBackend = $httpBackend;
      httpBackend.expectGET('/api/category').respond([
        {
          parentId: null,
          name: 'test1'
        }, {
          parentId: 1,
          name: 'test2'
        }
      ]);
      return ctrl = $controller('HomeIndexController', {
        $scope: $scope
      });
    }));
    afterEach(function() {
      httpBackend.verifyNoOutstandingExpectation();
      return httpBackend.verifyNoOutstandingRequest();
    });
    it('should start and empty output dictionary', function() {
      expect($scope.output).toEqual({});
      return httpBackend.flush();
    });
    return it('should make a call to Category.query()', function() {
      expect($scope.output.categories).toEqualData(void 0);
      httpBackend.flush();
      return expect($scope.output.categories).toEqualData([
        {
          parentId: null,
          name: 'test1'
        }
      ]);
    });
    /*
    
    it 'should start with foo and bar populated', ->
        expect($scope.foo).toEqual('foo')
        expect($scope.bar).toEqual('bar')
    
    it 'should add !!! to foo when test1() is called', ->
        $scope.foo = 'x'
        $scope.test1()
        expect($scope.foo).toEqual('x!!!')
    
    it 'should update baz when bar is changed', ->
        $scope.bar = 'test'
        $scope.$apply()
        expect($scope.baz).toEqual('testbaz')
    
    it 'should update fizz asynchronously when test2() is called', ->
        $scope.test2()
        expect($scope.fizz).toEqual('weee')
    
    it 'should make a call to someService.someAsyncCall() in test()', ->
        spyOn(mockService, 'someAsyncCall').andCallThrough()
        $scope.test2()
        expect(mockService.someAsyncCall).toHaveBeenCalled();
    */

  });

}).call(this);
