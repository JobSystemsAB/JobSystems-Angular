(function() {
  describe('Testing Home-Index-Controller', function() {
    var $scope, ctrl;

    $scope = null;
    ctrl = null;
    beforeEach(module('HomeApp'));
    beforeEach(inject(function($rootScope, $controller) {
      $scope = $rootScope.$new();
      return ctrl = $controller('HomeIndexController', {
        $scope: $scope,
        someService: mockService
      });
    }));
    it('should start with foo and bar populated', function() {
      expect($scope.foo).toEqual('foo');
      return expect($scope.bar).toEqual('bar');
    });
    it('should add !!! to foo when test1() is called', function() {
      $scope.foo = 'x';
      $scope.test1();
      return expect($scope.foo).toEqual('x!!!');
    });
    it('should update baz when bar is changed', function() {
      $scope.bar = 'test';
      $scope.$apply();
      return expect($scope.baz).toEqual('testbaz');
    });
    it('should update fizz asynchronously when test2() is called', function() {
      $scope.test2();
      return expect($scope.fizz).toEqual('weee');
    });
    return it('should make a call to someService.someAsyncCall() in test()', function() {
      spyOn(mockService, 'someAsyncCall').andCallThrough();
      $scope.test2();
      return expect(mockService.someAsyncCall).toHaveBeenCalled();
    });
  });

}).call(this);
