window.app.controller 'HomeApplicationController', 

['$scope', '$routeParams', 'CategoryService', 'GoogleMapsService', 'TextService', 'AlertService', 'MissionService',
( $scope,   $routeParams,   CategoryService,   GoogleMapsService,   TextService,   AlertService,   MissionService) ->

    # INIT

    $scope.isAdmin = true
    $scope.category = []

    $scope.controllerName = 'homeapplication'
    $scope.currentLang = 'sv'

    $scope.textsOriginal = [
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'input-text', text: 'input-text' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'employee-description', text: 'employee-description' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'video-text', text: 'video-text' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'button', text: 'button' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'input-firstName-description', text: 'input-firstName-description' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'input-lastName-description', text: 'input-lastName-description' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'input-phoneNumber-description', text: 'input-phoneNumber-description' }
        { controllerName: $scope.controllerName, language: $scope.currentLang, elementId: 'input-emailAddress-description', text: 'input-emailAddress-description' }
    ]

    # UNITE TEXTS

    $scope.uniteTexts = (data) ->
        originalGroup = _.groupBy $scope.textsOriginal, (text) -> 
                text.elementId
        dataGroup = _.groupBy data, (text) -> 
                text.elementId

        _.each dataGroup, (val, key) ->
            originalGroup[key] = val

        $scope.texts = originalGroup
        $scope.textsOriginal = _.map originalGroup, (val, key) ->
            val[0]

    # GET DATA

    CategoryService.getTree()
        .success (data, status, headers, config) ->
            $scope.categories = data
        .error (data, status, headers, config) ->
            AlertService.addAlert 'danger', 'Misslyckades med att hämta kategorier. Vänligen kontakta kundtjänst om problemet kvarstår.'
            
    TextService.getAllByControllerAndLanguage($scope.controllerName, 'sv')
        .success (data, status, headers, config) ->
            $scope.uniteTexts data
        .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Misslyckades att hämta texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.'
            
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

        TextService.postAll($scope.textsOriginal)
            .success (data, status, headers, config) ->
                AlertService.addAlert 'success', 'Texter sparade.'
            .error (data, status, headers, config) ->
                AlertService.addAlert 'danger', 'Misslyckades att spara texterna, prova igen och kontakta en tekniker om problemet kvarstår.'



]