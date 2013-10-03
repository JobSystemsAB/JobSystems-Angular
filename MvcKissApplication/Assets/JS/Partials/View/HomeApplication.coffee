window.app.controller 'HomeApplicationController', 

['$scope', '$stateParams', 'CategoryService', 'GoogleMapsService', 'TextService', 'AlertService', 'CompanyCustomer', 'Mission', 'PrivateCustomer',
( $scope,   $stateParams,   CategoryService,   GoogleMapsService,   TextService,   AlertService,   CompanyCustomer,   Mission,   PrivateCustomer) ->

    # INIT

    $scope.category = []

    # GET CATEGORIES

    CategoryService.getTree()
        .success (data, status, headers, config) ->
            $scope.categories = data
        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Misslyckades med att hämta kategorier. Vänligen kontakta kundtjänst om problemet kvarstår.'
            

    # GET TEXTS

    TextService.getTexts('HomeApplicationController', 'sv')
        .success (data, status, headers, config) ->
            $scope.textsOriginal = data
            $scope.texts = _.groupBy $scope.textsOriginal, (text) -> 
                text.elementId
        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Misslyckades med att hämta texter. Vänligen kontakta kundtjänst om problemet kvarstår.'
            
    # METHOD: CATEGORY CLICKED

    $scope.categoryClicked = (child, level) ->
        
        if !child.data.checked
            child.data.checked = true
        else
            child.data.checked = false

        $scope.category[level] = child
        $scope.category[level + 1] = null
        $scope.category[level + 2] = null

        $scope.checkCategory $scope.category[1]

    # METHOD: UNCHECK CATEGORIES

    $scope.checkCategory = (topParent) ->
        
        _.each $scope.categories.children, (child) ->
            if child.data.id != topParent.data.id
                child.data.checked = false

                _.each child.children, (child2) ->
                    child2.data.checked = false

                    _.each child2.children, (child3) ->
                        child3.data.checked = false
            else
                child.data.checked = true

                _.each child.children, (child2) ->
                    if child2.children.length > 0
                        child2.data.checked = _.find child2.children, (child3) ->
                            child3.data.checked == true
        
    # METHOD: SAVE CHANGES

    $scope.save = ->

        TextService.saveTexts($scope.textsOriginal)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Texter sparade.'
            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Misslyckades att spara texterna, prova igen och kontakta en tekniker om problemet kvarstår.'



]