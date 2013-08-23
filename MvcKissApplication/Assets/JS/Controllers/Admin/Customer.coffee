window.app.controller 'CustomerController', 

['$scope', 'Customer'
( $scope,   Customer) ->


    # -- DATA

    $scope.customers = Customer.query()

    # -- METHOD

    $scope.delete = (customer) ->
        customer.$remove()
        $scope.customers = _.filter $scope.customers, (cus) ->
            return cus.id != customer.id

]