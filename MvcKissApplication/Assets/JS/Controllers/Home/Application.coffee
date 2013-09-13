window.app.controller 'ApplicationController', 

['$scope','$http', 'Category', 'CategoryService', 'Employee', 'EmployeeService' 
( $scope,  $http,   Category,   CategoryService,   Employee,   EmployeeService) ->

    # -- INIT

    $scope.output = {}
    $scope.input = {}
    $scope.input.employee = {}

    # -- DATA

    CategoryService.getTree()
        .success (data, status, headers, config) ->
            $scope.categories = data

    $scope.output.inputClarificationText = 
        1: 'Förnamn'
        2: 'Efternamn'
        3: 'Telefonnummer'
        4: 'Epost'

    # -- FRONT METHODS

    $scope.clearInputClarification = ->
        $scope.output.inputClarifications = ''

    $scope.getInputClarification = (id) ->
        $scope.output.inputClarifications = $scope.output.inputClarificationText[id]

    $scope.categoryClicked = (category) ->
        
        _.each $scope.categories.children, (child) ->
            if child.data.id != category.data.id
                child.data.checked = false

                _.each child.children, (child2) ->
                    child2.data.checked = false

                    _.each child2.children, (child3) ->
                        child3.data.checked = false
            else
                child.data.checked = true

                _.each child.children, (child2) ->
                    child2.data.checked = _.find child2.children, (child3) ->
                        return child3.data.checked == true
    
    $scope.send = ->

        cat1 = _.filter $scope.categories.children, (child) ->
            child.data.checked

        cat2 = []
        _.each cat1, (cat) ->
            found = _.filter cat.children, (child) ->
                child.data.checked
            _.each found, (iter) ->
                cat2.push iter

        cat3 = []
        _.each cat2, (cat) ->
            found = _.filter cat.children, (child) ->
                child.data.checked
            _.each found, (iter) ->
                cat3.push iter

        ans = []
        temp = _.map cat1, (cat) ->
            cat.data.id
        _.each temp, (iter) ->
            ans.push iter
        temp = _.map cat2, (cat) ->
            cat.data.id
        _.each temp, (iter) ->
            ans.push iter
        temp = _.map cat3, (cat) ->
            cat.data.id
        _.each temp, (iter) ->
            ans.push iter

        employee = new Employee $scope.input.employee

        employee.$save(
            (data) ->
                EmployeeService.connectCategories employee.id, ans

            , (error) ->
                console.log error
        )
]