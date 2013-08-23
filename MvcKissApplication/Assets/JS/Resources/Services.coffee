window.app.service('AdministratorService', [ '$http', ($http) ->
    
    this.getAdministrator = (email, password) ->
        $http
            url: "/api/administrator/getlogin?email=" + email + "&password=" + password
            method: "GET"
    
])

window.app.service('CategoryService', [ '$http', ($http) ->
    
    this.getSubcategories = (categoryId) ->
        $http
            url: "/api/category/" + categoryId + "/subcategories"
            method: "GET"

    this.getCategoryInputs = (categoryId) ->
        $http
            url: "/api/category/" + categoryId + "/categoryinputs"
            method: "GET"
    
])

window.app.service('CustomerService', [ '$http', ($http) ->
    
    this.getCustomer = (email, password) ->
        $http
            url: "/api/customer/getlogin?email=" + email + "&password=" + password
            method: "GET"
    
])

window.app.service('GoogleMapsService', [ '$http', ($http) ->
    
    this.getAddressType = (address_components, type) ->
        temp = _.find address_components, (component) ->
            return _.contains component.types, type
        if temp
            return temp.long_name
        else
            return null

])

window.app.service('MissionService', [ '$http', ($http) ->
    
    this.connectCategory = (missionId, categoryId) ->
        $http
            url: "/api/mission/" + missionId + "/connectcategory"
            data: { 'missionId': missionId, 'categoryId': categoryId  }
            method: "POST"
    
    this.connectSubcategory = (missionId, subcategoryId) ->
        $http
            url: "/api/mission/" + missionId + "/connectsubcategory"
            data: { 'missionId': missionId, 'subcategoryId': subcategoryId  }
            method: "POST"

    this.connectSubsubcategory = (missionId, subsubcategoryId) ->
        $http
            url: "/api/mission/" + missionId + "/connectsubsubcategory"
            data: { 'missionId': missionId, 'subsubcategoryId': subsubcategoryId  }
            method: "POST"

    this.connectCustomer = (missionId, customerId) ->
        $http
            url: "/api/mission/" + missionId + "/connectcustomer"
            data: { 'missionId': missionId, 'customerId': customerId  }
            method: "POST"

    this.connectEmployee = (missionId, employeeId) ->
        $http
            url: "/api/mission/" + missionId + "/connectemployee"
            data: { 'missionId': missionId, 'employeeId': employeeId  }
            method: "POST"

])

window.app.service('SubcategoryService', [ '$http', ($http) ->
    
    this.getSubsubcategories = (subcategoryId) ->
        $http
            url: "/api/subcategory/" + subcategoryId + "/subsubcategory"
            method: "GET"
    
])
