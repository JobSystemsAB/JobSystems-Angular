(function() {
  window.CalendarController = function($scope, $http, CalendarService) {
    $scope.init = function() {
      $scope.names = {};
      $scope.names.months = {};
      $scope.names.days = {};
      $scope.names.shortMonths = {};
      $scope.names.shortDays = {};
      $scope.current = {};
      $scope.selected = {};
      $scope.names.months['sv'] = [
        {
          id: 0,
          name: 'Januari'
        }, {
          id: 1,
          name: 'Februari'
        }, {
          id: 2,
          name: 'Mars'
        }, {
          id: 3,
          name: 'April'
        }, {
          id: 4,
          name: 'Maj'
        }, {
          id: 5,
          name: 'Juni'
        }, {
          id: 6,
          name: 'Juli'
        }, {
          id: 7,
          name: 'Augusti'
        }, {
          id: 8,
          name: 'September'
        }, {
          id: 9,
          name: 'Oktober'
        }, {
          id: 10,
          name: 'November'
        }, {
          id: 11,
          name: 'December'
        }
      ];
      $scope.names.days['sv'] = ['Måndag', 'Tisdag', 'Onsdag', 'Torsdag', 'Fredag', 'Lördag', 'Söndag'];
      $scope.names.shortMonths['sv'] = ['Jan', 'Feb', 'Mar', 'Apr', 'Maj', 'Jun', 'Jul', 'Aug', 'Sep', 'Okt', 'Nov', 'Dec'];
      $scope.names.shortDays['sv'] = ['Mån', 'Tis', 'Ons', 'Tor', 'Fre', 'Lör', 'Sön'];
      $scope.selected.date = CalendarService.getDate();
      $scope.selected.year = $scope.selected.date.getFullYear();
      $scope.selected.month = $scope.selected.date.getMonth();
      $scope.selected.day = $scope.selected.date.getDate();
      $scope.current.year = $scope.selected.year;
      return $scope.current.month = $scope.selected.month;
    };
    $scope.calculateWeekday = function(month) {
      var temp;

      temp = {};
      temp.month = month + 1;
      temp.date = new Date(temp.month + ' 1 ,' + $scope.selected.date.getYear());
      temp.weekday = temp.date.getDay();
      return temp;
    };
    $scope.getMonthDays = function(year) {
      if ((year % 100 !== 0 && year % 4 === 0) || year % 400 === 0) {
        return [31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
      } else {
        return [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
      }
    };
    $scope.isSelected = function(day) {
      var dayMatch, monthMatch, yearMatch;

      yearMatch = $scope.current.year === $scope.selected.year;
      monthMatch = $scope.current.month === $scope.selected.month;
      dayMatch = day === $scope.selected.day;
      return dayMatch && monthMatch && yearMatch;
    };
    $scope.getDays = function(monthDays) {
      var days, i;

      days = [];
      i = 1;
      while (i <= monthDays[$scope.current.month]) {
        days.push({
          nr: i,
          disabled: false,
          weekend: false,
          freeTimes: false,
          times: {
            id: null,
            performerId: null,
            day: null,
            morning: false,
            afternoon: false,
            evening: false
          }
        });
        i++;
      }
      return days;
    };
    $scope.getWeeks = function(weekday, days) {
      var i, monthDays, tempDays;

      monthDays = [];
      tempDays = [];
      i = 0;
      if (weekday < 6) {
        while (i <= $scope.temp.weekday) {
          tempDays.push({
            nr: '',
            disabled: true,
            weekend: false,
            freeTimes: false,
            times: {}
          });
          i++;
        }
      }
      angular.forEach(days, function(day) {
        if (tempDays.length === 7) {
          monthDays.push(tempDays);
          tempDays = [];
        }
        return tempDays.push(day);
      });
      if (tempDays.length !== 0) {
        while (tempDays.length < 7) {
          tempDays.push('');
        }
        monthDays.push(tempDays);
      }
      console.log(monthDays);
      return monthDays;
    };
    $scope.getMonthName = function(monthNumber) {
      return $scope.names.months['sv'][monthNumber];
    };
    $scope.changeDate = function(day) {
      var temp;

      $scope.selected.year = $scope.current.year;
      $scope.selected.month = $scope.current.month;
      $scope.selected.day = day;
      temp = new Date();
      temp.setFullYear($scope.selected.year, $scope.selected.month, $scope.selected.day);
      return CalendarService.setDate(temp);
    };
    $scope.changeMonth = function() {
      return $scope.current.weeks = $scope.getWeeks();
    };
    $scope.$on('CalendarService.getFreeTimes', function(event, performerId) {
      $scope.freeTimes = [];
      return $http({
        url: "/api/PerformerTimeFree/PerformerMonth" + "?performerId=" + 5 + "&month=" + ($scope.input.date.getMonth() + 1) + "&year=" + $scope.input.date.getFullYear(),
        method: "GET"
      }).success(function(status, data, headers, config) {
        return angular.forEach(status, function(freeTime) {
          var date;

          date = new Date(freeTime.day);
          $scope.freeTimes.push({
            performerId: freeTime.performerId,
            date: date,
            morning: freeTime.morning,
            afternoon: freeTime.afternoon,
            evening: freeTime.evening
          });
          return angular.forEach($scope.current.weeks, function(week) {
            var day;

            day = _.findWhere(week, {
              nr: date.getDate()
            });
            if (day) {
              return day.freeTimes = true;
            }
          });
        });
      }).error(function(status, data, headers, config) {
        return $scope.$broadcast('infoMessage', data + ": Misslyckades med att hämta fria tider för denna månad");
      });
    });
    $scope.init();
    $scope.current.monthDays = $scope.getMonthDays($scope.selected.year);
    $scope.current.weekday = $scope.calculateWeekday($scope.current.month);
    $scope.current.days = $scope.getDays($scope.current.monthDays);
    $scope.current.weeks = $scope.getWeeks($scope.current.weekday, $scope.current.days);
    return CalendarService.ready();
  };

}).call(this);
