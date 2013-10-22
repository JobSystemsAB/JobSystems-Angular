(function() {
  window.app.controller('AdminTestimonialsController', [
    '$scope', '$modal', 'TestimonialService', 'AlertService', function($scope, $modal, TestimonialService, AlertService) {
      var ModalInstanceCtrl;

      TestimonialService.getAllByLanguage('sv').success(function(data, status, headers, config) {
        return $scope.testimonials = data;
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('danger', 'Failed to load all testimonials');
      });
      $scope.gridOptions = {
        data: 'testimonials',
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
            field: 'text',
            displayName: 'Text'
          }, {
            field: 'name',
            displayName: 'Name'
          }, {
            field: 'language',
            displayName: 'Language'
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
        return $scope.selected = selected;
      };
      $scope.save = function() {
        $scope.newTestimonial.language = 'sv';
        $scope.newTestimonial.enabled = true;
        return TestimonialService.post($scope.newTestimonial).success(function(data, status, headers, config) {
          $scope.testimonials.push(data);
          $scope.newTestimonial = {};
          return AlertService.addAlert('success', 'Successfully saved the new testimonial.');
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Failed to save the new testimonial');
        });
      };
      $scope.update = function(testimonial) {
        return TestimonialService.put(testimonial).success(function(data, status, headers, config) {
          return AlertService.addAlert('success', 'Successfully updated the testimonial.');
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Failed to update the testimonial');
        });
      };
      return $scope["delete"] = function(testimonial) {
        return TestimonialService["delete"](testimonial.id).success(function(data, status, headers, config) {
          AlertService.addAlert('success', 'Successfully deleted the testimonial.');
          return $scope.testimonials = _.reject($scope.testimonials, function(temp) {
            return temp.id === testimonial.id;
          });
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Failed to delete the testimonial');
        });
      };
    }
  ]);

}).call(this);
