(function() {
  window.app.controller('AdminEmployeesController', [
    '$scope', '$modal', 'AlertService', 'EmployeeService', function($scope, $modal, AlertService, EmployeeService) {
      var ModalInstanceCtrl;

      EmployeeService.getAll().success(function(data, status, headers, config) {
        return $scope.employees = data;
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('danger', 'Failed to load all services.');
      });
      $scope.gridOptions = {
        data: 'employees',
        enableColumnResize: true,
        enableRowSelection: true,
        enableSorting: true,
        multiSelect: false,
        showGroupPanel: true,
        afterSelectionChange: function(data) {
          return $scope.open(data.entity);
        },
        columnDefs: [
          {
            field: 'firstName',
            displayName: 'First name'
          }, {
            field: 'lastName',
            displayName: 'Last Name'
          }, {
            field: 'emailAddress',
            displayName: 'Email'
          }, {
            field: 'phoneNumber',
            displayName: 'Phone'
          }, {
            field: 'created',
            displayName: 'Created'
          }, {
            field: 'updated',
            displayName: 'Updated'
          }, {
            field: 'enabled',
            displayName: 'Enabled'
          }
        ]
      };
      $scope.open = function(selected) {
        var modalInstance;

        modalInstance = $modal.open({
          templateUrl: 'myModalContent.html',
          controller: ModalInstanceCtrl,
          resolve: {
            selected: function() {
              return angular.copy(selected);
            }
          }
        });
        return modalInstance.result.then(function(selected) {
          return $scope.selected = selectedItem;
        }, function() {
          return console.log('Modal dismissed at: ' + new Date());
        });
      };
      return ModalInstanceCtrl = function($scope, $modalInstance, selected) {
        return $scope.selected = selected;
      };
    }
  ]);

}).call(this);
