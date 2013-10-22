(function() {
  window.app.controller('AdminTextsController', [
    '$scope', '$modal', 'TextService', 'AlertService', function($scope, $modal, TextService, AlertService) {
      var ModalInstanceCtrl;

      $scope.tinymceOptions = {
        plugins: ["advlist autolink lists link image charmap print preview hr anchor pagebreak", "searchreplace wordcount visualblocks visualchars code fullscreen", "insertdatetime media nonbreaking save table contextmenu directionality", "emoticons template paste textcolor"]
      };
      TextService.getAllByLanguage('sv').success(function(data, status, headers, config) {
        $scope.textsUngrouped = data;
        return $scope.texts = _.groupBy(data, function(text) {
          return text.controllerName;
        });
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('danger', 'Failed to load all texts.');
      });
      $scope.gridOptions = {
        data: 'textsUngrouped',
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
            field: 'controllerName',
            displayName: 'Group'
          }, {
            field: 'elementId',
            displayName: 'Id'
          }, {
            field: 'language',
            displayName: 'Language'
          }, {
            field: 'text',
            displayName: 'Text'
          }, {
            field: 'created',
            displayName: 'Created'
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
      ModalInstanceCtrl = function($scope, $modalInstance, selected) {
        $scope.selected = selected;
        return $scope.tinymceOptions = {
          plugins: ["advlist autolink lists link image charmap print preview hr anchor pagebreak", "searchreplace wordcount visualblocks visualchars code fullscreen", "insertdatetime media nonbreaking save table contextmenu directionality", "emoticons template paste textcolor"]
        };
      };
      $scope.select = function(text) {
        return $scope.selected = text;
      };
      $scope.update = function() {
        return TextService.put($scope.selected).success(function(data, status, headers, config) {
          return AlertService.addAlert('success', 'Updated the text.');
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Could not save the text.');
        });
      };
      return $scope.unique = function(controller) {
        var ids;

        ids = _.map(controller, function(text) {
          return text.elementId;
        });
        return _.unique(ids).length;
      };
    }
  ]);

}).call(this);
