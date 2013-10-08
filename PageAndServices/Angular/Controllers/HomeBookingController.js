(function() {
  window.app.controller('HomeBookingController', [
    '$scope', '$stateParams', '$http', 'CategoryService', 'GoogleMapsService', 'TextService', 'AlertService', 'MissionService', 'PrivateCustomerService', 'CompanyCustomerService', function($scope, $stateParams, $http, CategoryService, GoogleMapsService, TextService, AlertService, MissionService, PrivateCustomerService, CompanyCustomerService) {
      $scope.isAdmin = true;
      $scope.category = [];
      $scope.controllerName = 'homebooking';
      $scope.currentLang = 'sv';
      $scope.textsOriginal = [
        {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'book-title',
          text: 'book-title'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'book-description',
          text: 'book-description'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'calendar-description',
          text: 'calendar-description'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'book-button',
          text: 'book-button'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'category-first',
          text: 'category-first'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'category-second',
          text: 'category-second'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'category-third',
          text: 'category-third'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'mission-description',
          text: 'mission-description'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'input-organisationNumber-description',
          text: 'input-organisationNumber-description'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'input-companyName-description',
          text: 'input-companyName-description'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'input-firstName-description',
          text: 'input-firstName-description'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'input-lastName-description',
          text: 'input-lastName-description'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'input-personalNumber-description',
          text: 'input-personalNumber-description'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'input-propertyName-description',
          text: 'input-propertyName-description'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'input-emailAddress-description',
          text: 'input-emailAddress-description'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'input-phoneNumber-description',
          text: 'input-phoneNumber-description'
        }, {
          controllerName: $scope.controllerName,
          language: $scope.currentLang,
          elementId: 'input-fullAddress-description',
          text: 'input-fullAddress-description'
        }
      ];
      $scope.uniteTexts = function(data) {
        var dataGroup, originalGroup;

        originalGroup = _.groupBy($scope.textsOriginal, function(text) {
          return text.elementId;
        });
        dataGroup = _.groupBy(data, function(text) {
          return text.elementId;
        });
        _.each(dataGroup, function(val, key) {
          return originalGroup[key] = val;
        });
        $scope.texts = originalGroup;
        return $scope.textsOriginal = _.map(originalGroup, function(val, key) {
          return val[0];
        });
      };
      $scope.isCompanyCustomer = function() {
        return $scope.customer.type === 'company';
      };
      $scope.saveMission = function() {
        $scope.getAddress();
        $scope.mission.date = $scope.selectedEvent.start;
        $scope.mission.extras = angular.toJson(_.map($scope.inputs, function(input) {
          return {
            'id': input.id,
            'value': input.value
          };
        }));
        return MissionService.post($scope.mission.success(function(data, status, headers, config) {
          return AlertService.addAlert('success', 'Uppdrag skapades.');
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Misslyckades skapa uppdraget, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
        }));
      };
      $scope.order = function() {
        if ($scope.isCompanyCustomer()) {
          return CompanyCustomerService.post($scope.customer).success(function(data, status, headers, config) {
            return AlertService.addAlert('success', 'Kund skapad.');
          }).error(function(data, status, headers, config) {
            return AlertService.addAlert('danger', 'Misslyckades skapa kund, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
          });
        } else {
          return PrivateCustomerService.post($scope.customer).success(function(data, status, headers, config) {
            return AlertService.addAlert('success', 'Kund skapad.');
          }).error(function(data, status, headers, config) {
            return AlertService.addAlert('danger', 'Misslyckades skapa kund, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
          });
        }
      };
      TextService.getAllByControllerAndLanguage($scope.controllerName, 'sv').success(function(data, status, headers, config) {
        return $scope.uniteTexts(data);
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('danger', 'Misslyckades att hämta texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
      });
      CategoryService.getTree().success(function(data, status, headers, config) {
        $scope.categories = data;
        if ($stateParams.serviceId) {
          $scope.category[1] = _.find($scope.categories.children, function(child) {
            return child.data.id = $stateParams.serviceId;
          });
          return $scope.getInputs();
        }
      }).error(function(data, status, headers, config) {
        return AlertService.addAlert('danger', 'Misslyckades med att hämta kategorier, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
      });
      $scope.getInputs = function() {
        return CategoryService.getInputs($scope.category[1].data.id).success(function(data, status, headers, config) {
          return $scope.inputs = data;
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Misslyckades med att hämta extra informationsfält, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
        });
      };
      $scope.loadEvents = function() {
        var result, startDate, startMonth, todayDate;

        todayDate = new Date();
        startDate = $scope.myCalendar.fullCalendar('getDate');
        startMonth = startDate.getMonth();
        result = [];
        while (startDate.getMonth() === startMonth) {
          if (startDate > todayDate) {
            result.push({
              title: '08:00',
              start: startDate.toLocaleDateString() + " 08:00:00"
            });
            result.push({
              title: '12:00',
              start: startDate.toLocaleDateString() + " 12:00:00"
            });
            result.push({
              title: '17:00',
              start: startDate.toLocaleDateString() + " 17:00:00"
            });
          }
          startDate.setDate(startDate.getDate() + 1);
        }
        return $scope.eventSources[0].events = result;
      };
      $scope.save = function() {
        return TextService.postAll($scope.textsOriginal).success(function(data, status, headers, config) {
          return AlertService.addAlert('success', 'Texter sparade.');
        }).error(function(data, status, headers, config) {
          return AlertService.addAlert('danger', 'Misslyckades att spara texterna, vänligen prova igen och kontakta en tekniker om problemet kvarstår.');
        });
      };
      $scope.getAddress = function() {
        var place;

        place = $scope.mission.fullAddress;
        $scope.mission.address.latitude = place.geometry.location.lat();
        $scope.mission.address.longitude = place.geometry.location.lng();
        $scope.mission.address.streetNumber = GoogleMapsService.getAddressType(place.address_components, 'street_number');
        $scope.mission.address.street = GoogleMapsService.getAddressType(place.address_components, 'route');
        $scope.mission.address.postalCode = GoogleMapsService.getAddressType(place.address_components, 'postal_code');
        $scope.mission.address.postalTown = GoogleMapsService.getAddressType(place.address_components, 'postal_town');
        $scope.mission.address.country = GoogleMapsService.getAddressType(place.address_components, 'country');
        $scope.mission.address.area = GoogleMapsService.getAddressType(place.address_components, 'administrative_area_level_1');
        return console.log($scope.mission.address);
      };
      $scope.mission = {
        description: ''
      };
      $scope.customer = {
        type: 'private'
      };
      $scope.uiConfig = {
        calendar: {
          height: 250,
          editable: true,
          header: {
            left: '',
            center: 'title',
            right: 'today prev,next'
          },
          viewRender: function() {
            return $scope.loadEvents();
          },
          eventClick: function(event) {
            $scope.selectedEvent = event;
            return $scope.$apply();
          }
        }
      };
      $scope.eventSources = [
        {
          events: [],
          color: '#0CB45D',
          textColor: 'white'
        }
      ];
      return $scope.dibs = function() {
        $scope.dibsInput = {};
        $scope.dibsInput.test = "1";
        $scope.dibsInput.merchant = "90151568";
        $scope.dibsInput.currency = "SEK";
        $scope.dibsInput.orderId = "213455";
        $scope.dibsInput.amount = "375";
        $scope.dibsInput.language = "sv_SE";
        $scope.dibsInput.billingFirstName = "John";
        $scope.dibsInput.billingLastName = "Doe";
        $scope.dibsInput.billingAddress = "Danderydsgatan 28";
        $scope.dibsInput.billingPostalCode = "11426";
        $scope.dibsInput.billingPostalPlace = "Stockholm";
        $scope.dibsInput.billingEmail = "misael@jobsystems.se";
        $scope.dibsInput.billingMobile = "+46704333005";
        $scope.dibsInput.oiTypes = "QUANTITY;UNITCODE;DESCRIPTION;AMOUNT;ITEMID;VATAMOUNT";
        $scope.dibsInput.oiNames = "Items;UnitCode;Description;Amount;ItemId;VatAmount";
        $scope.dibsInput.oiRow1 = "1;pcs;ACME Rocket Roller skates\; ultra fast;100;98;25";
        $scope.dibsInput.oiRow2 = "1;pcs;ACME Band Aid;100;99;25";
        $scope.dibsInput.oiRow3 = "1;pcs;Some description;100;45;25";
        $scope.dibsInput.acceptReturnUrl = "https://yourdomain.com/acceptReturnUrl";
        $scope.dibsInput.cancelReturnUrl = "https://yourdomain.com/cancelReturnUrl";
        $scope.dibsInput.callbackUrl = "https://yourdomain.com/callbackUrl";
        console.log(angular.toJson($scope.dibsInput));
        delete $http.defaults.headers.common['X-Requested-With'];
        $http.defaults.headers.common = {
          "Access-Control-Request-Headers": "accept, origin, authorization"
        };
        $http({
          url: "https://sat1.dibspayment.com/dibspaymentwindow/entrypoint",
          method: "POST",
          data: $scope.dibsInput
        }).success(function(data, status, headers, config) {
          return console.log("yay", data, status, headers, config);
        }).error(function(data, status, headers, config) {
          return console.log("nay", data, status, headers, config);
        });
        return $http({
          url: "https://sat1.dibspayment.com/dibspaymentwindow/entrypoint",
          method: "JSONP",
          data: $scope.dibsInput
        }).success(function(data, status, headers, config) {
          return console.log("yay", data, status, headers, config);
        }).error(function(data, status, headers, config) {
          return console.log("nay", data, status, headers, config);
        });
      };
    }
  ]);

}).call(this);
