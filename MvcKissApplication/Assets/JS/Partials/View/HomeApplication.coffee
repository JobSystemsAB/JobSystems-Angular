window.app.controller 'HomeApplicationController', 

['$scope', '$stateParams', 'CategoryService', 'GoogleMapsService', 'CompanyCustomer', 'Mission', 'PrivateCustomer',
( $scope,   $stateParams,   CategoryService,   GoogleMapsService,   CompanyCustomer,   Mission,   PrivateCustomer) ->

    # INIT

    $scope.category = []

    # GET CATEGORIES

    CategoryService.getTree()
        .success (data, status, headers, config) ->
            $scope.categories = data

    # METHOD: CATEGORY CLICKED

    $scope.categoryClicked = (child, level) ->
        
        $scope.category[level] = child
        $scope.category[level + 1] = null
        $scope.category[level + 2] = null
        

]