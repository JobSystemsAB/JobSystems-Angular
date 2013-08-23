window.app.controller 'CustomerViewController', 

['$scope', '$routeParams', 'PrivateCustomer', 'CompanyCustomer', 
( $scope,   $routeParams,   PrivateCustomer,   CompanyCustomer) ->


     # -- INIT

    $scope.input = {}

    # -- METHOD

    $scope.save = ->
        if $scope.isNotNew()
            $scope.input.$update()
        else
            if $scope.input.type == 'PrivateCustomer'
                $scope.input = new PrivateCustomer $scope.input
            else
                $scope.input = new CompanyCustomer $scope.input
            $scope.input.$save()
            console.log $scope.input

    $scope.delete = ->
        $scope.input.$remove()

    $scope.isNotNew = ->
        $scope.input.id != '0'

    $scope.isPrivate = ->
        $scope.input.type == 'PrivateCustomer'


    # -- DATA

    $scope.input.id = $routeParams.customerId
    $scope.input.type = $routeParams.customerType

    if $scope.isNotNew()
        if $scope.input.type == 'PrivateCustomer'
            $scope.input = PrivateCustomer.get { id: $scope.input.id }
        else
            $scope.input = CompanyCustomer.get { id: $scope.input.id }


]