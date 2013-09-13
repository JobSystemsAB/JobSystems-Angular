(function() {
  window.app.controller('ApplicationController', [
    '$scope', '$http', 'Category', 'CategoryService', 'Employee', 'EmployeeService', function($scope, $http, Category, CategoryService, Employee, EmployeeService) {
      $scope.output = {};
      $scope.input = {};
      $scope.input.employee = {};
      CategoryService.getTree().success(function(data, status, headers, config) {
        return $scope.categories = data;
      });
      $scope.output.inputClarificationText = {
        1: 'Förnamn',
        2: 'Efternamn',
        3: 'Telefonnummer',
        4: 'Epost'
      };
      $scope.clearInputClarification = function() {
        return $scope.output.inputClarifications = '';
      };
      $scope.getInputClarification = function(id) {
        return $scope.output.inputClarifications = $scope.output.inputClarificationText[id];
      };
      $scope.categoryClicked = function(category) {
        return _.each($scope.categories.children, function(child) {
          if (child.data.id !== category.data.id) {
            child.data.checked = false;
            return _.each(child.children, function(child2) {
              child2.data.checked = false;
              return _.each(child2.children, function(child3) {
                return child3.data.checked = false;
              });
            });
          } else {
            child.data.checked = true;
            return _.each(child.children, function(child2) {
              return child2.data.checked = _.find(child2.children, function(child3) {
                return child3.data.checked === true;
              });
            });
          }
        });
      };
      return $scope.send = function() {
        var ans, cat1, cat2, cat3, employee, temp;

        cat1 = _.filter($scope.categories.children, function(child) {
          return child.data.checked;
        });
        cat2 = [];
        _.each(cat1, function(cat) {
          var found;

          found = _.filter(cat.children, function(child) {
            return child.data.checked;
          });
          return _.each(found, function(iter) {
            return cat2.push(iter);
          });
        });
        cat3 = [];
        _.each(cat2, function(cat) {
          var found;

          found = _.filter(cat.children, function(child) {
            return child.data.checked;
          });
          return _.each(found, function(iter) {
            return cat3.push(iter);
          });
        });
        ans = [];
        temp = _.map(cat1, function(cat) {
          return cat.data.id;
        });
        _.each(temp, function(iter) {
          return ans.push(iter);
        });
        temp = _.map(cat2, function(cat) {
          return cat.data.id;
        });
        _.each(temp, function(iter) {
          return ans.push(iter);
        });
        temp = _.map(cat3, function(cat) {
          return cat.data.id;
        });
        _.each(temp, function(iter) {
          return ans.push(iter);
        });
        employee = new Employee($scope.input.employee);
        return employee.$save(function(data) {
          return EmployeeService.connectCategories(employee.id, ans);
        }, function(error) {
          return console.log(error);
        });
      };
    }
  ]);

}).call(this);
