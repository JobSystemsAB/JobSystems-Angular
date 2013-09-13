describe 'Testing Home-Index-Controller', ->
    
    # -- Mocks
    httpBackend = null

    # -- Controller
    ctrl = null

    # -- Scope
    $scope = null

    # -- Data

    # -- Load

    beforeEach ->
        this.addMatchers
            toEqualData: (expect) ->
                return angular.equals expect, this.actual

    beforeEach module 'HomeApp'
    
    beforeEach inject ($rootScope, $controller, $httpBackend) ->
        $scope = $rootScope.$new()

        httpBackend = $httpBackend
        httpBackend.expectGET('/api/category').respond(
            [   { parentId: null, name: 'test1' } , 
                { parentId: 1,    name: 'test2' } ])

        ctrl = $controller('HomeIndexController', { $scope: $scope })


    # -- Unload
    
    afterEach ->
        httpBackend.verifyNoOutstandingExpectation()
        httpBackend.verifyNoOutstandingRequest()


    # -- Statements

    it 'should start and empty output dictionary', ->
        expect($scope.output).toEqual({})
        httpBackend.flush()

    it 'should make a call to Category.query()', ->        
        expect($scope.output.categories).toEqualData(undefined)
        httpBackend.flush()
        expect($scope.output.categories).toEqualData([{parentId: null, name: 'test1'}])

    ##it 'should alert when recieving an error from Category.query()', ->
    ##    httpBackend.flush()
        
        


    ###

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

    ###