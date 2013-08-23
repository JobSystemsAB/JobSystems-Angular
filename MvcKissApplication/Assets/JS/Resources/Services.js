(function() {
  window.app.service('AdministratorService', [
    '$http', function($http) {
      return this.getAdministrator = function(email, password) {
        return $http({
          url: "/api/administrator/getlogin?email=" + email + "&password=" + password,
          method: "GET"
        });
      };
    }
  ]);

  window.app.service('CategoryService', [
    '$http', function($http) {
      this.getSubcategories = function(categoryId) {
        return $http({
          url: "/api/category/" + categoryId + "/subcategories",
          method: "GET"
        });
      };
      return this.getCategoryInputs = function(categoryId) {
        return $http({
          url: "/api/category/" + categoryId + "/categoryinputs",
          method: "GET"
        });
      };
    }
  ]);

  window.app.service('CustomerService', [
    '$http', function($http) {
      return this.getCustomer = function(email, password) {
        return $http({
          url: "/api/customer/getlogin?email=" + email + "&password=" + password,
          method: "GET"
        });
      };
    }
  ]);

  window.app.service('GoogleMapsService', [
    '$http', function($http) {
      return this.getAddressType = function(address_components, type) {
        var temp;

        temp = _.find(address_components, function(component) {
          return _.contains(component.types, type);
        });
        if (temp) {
          return temp.long_name;
        } else {
          return null;
        }
      };
    }
  ]);

  window.app.service('MissionService', [
    '$http', function($http) {
      this.connectCategory = function(missionId, categoryId) {
        return $http({
          url: "/api/mission/" + missionId + "/connectcategory",
          data: {
            'missionId': missionId,
            'categoryId': categoryId
          },
          method: "POST"
        });
      };
      this.connectSubcategory = function(missionId, subcategoryId) {
        return $http({
          url: "/api/mission/" + missionId + "/connectsubcategory",
          data: {
            'missionId': missionId,
            'subcategoryId': subcategoryId
          },
          method: "POST"
        });
      };
      this.connectSubsubcategory = function(missionId, subsubcategoryId) {
        return $http({
          url: "/api/mission/" + missionId + "/connectsubsubcategory",
          data: {
            'missionId': missionId,
            'subsubcategoryId': subsubcategoryId
          },
          method: "POST"
        });
      };
      this.connectCustomer = function(missionId, customerId) {
        return $http({
          url: "/api/mission/" + missionId + "/connectcustomer",
          data: {
            'missionId': missionId,
            'customerId': customerId
          },
          method: "POST"
        });
      };
      return this.connectEmployee = function(missionId, employeeId) {
        return $http({
          url: "/api/mission/" + missionId + "/connectemployee",
          data: {
            'missionId': missionId,
            'employeeId': employeeId
          },
          method: "POST"
        });
      };
    }
  ]);

  window.app.service('SubcategoryService', [
    '$http', function($http) {
      return this.getSubsubcategories = function(subcategoryId) {
        return $http({
          url: "/api/subcategory/" + subcategoryId + "/subsubcategory",
          method: "GET"
        });
      };
    }
  ]);

}).call(this);
