window.CalendarController = ($scope, $http, CalendarService) ->

    # -- METHODS -- #

    # INIT: Initiate all start data
    $scope.init = ->

        $scope.names = {}
        $scope.names.months = {}
        $scope.names.days = {}
        $scope.names.shortMonths = {}
        $scope.names.shortDays = {}
        $scope.current = {}
        $scope.selected = {}

        $scope.names.months['sv'] = [
            { id: 0, name:'Januari' } 
            { id: 1, name: 'Februari'}
            { id: 2, name: 'Mars'}
            { id: 3, name: 'April' } 
            { id: 4, name: 'Maj' }
            { id: 5, name: 'Juni' }
            { id: 6, name: 'Juli' }
            { id: 7, name: 'Augusti' }
            { id: 8, name: 'September' }
            { id: 9, name: 'Oktober' }
            { id: 10, name: 'November' }
            { id: 11, name: 'December' }
        ]
    
        $scope.names.days['sv'] = ['Måndag', 'Tisdag', 'Onsdag', 'Torsdag', 'Fredag', 'Lördag', 'Söndag']
        $scope.names.shortMonths['sv'] = ['Jan', 'Feb', 'Mar', 'Apr', 'Maj', 'Jun', 'Jul', 'Aug', 'Sep', 'Okt', 'Nov', 'Dec']
        $scope.names.shortDays['sv'] = ['Mån', 'Tis', 'Ons', 'Tor', 'Fre', 'Lör', 'Sön']
    
        $scope.selected.date = CalendarService.getDate()
        $scope.selected.year = $scope.selected.date.getFullYear()
        $scope.selected.month = $scope.selected.date.getMonth()
        $scope.selected.day = $scope.selected.date.getDate()

        $scope.current.year = $scope.selected.year
        $scope.current.month = $scope.selected.month

    # CALCULATE WEEKDAY: Calculate what day of the week is the first day of month
    $scope.calculateWeekday = (month) ->
        temp = {}
        temp.month = month + 1
        temp.date = new Date(temp.month + ' 1 ,' + $scope.selected.date.getYear())
        temp.weekday = temp.date.getDay()  

        return temp

    # GET MONTH DAYS: Get the number of days of the months this year
    $scope.getMonthDays = (year) ->
        if (year % 100 != 0 && year % 4 == 0) || year % 400 == 0
            return [31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31]
        else 
            return [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31]

    # IS SELECTED: Check if the day has been selected by the user
    $scope.isSelected = (day) ->
        yearMatch = $scope.current.year == $scope.selected.year
        monthMatch = $scope.current.month == $scope.selected.month
        dayMatch = day == $scope.selected.day
        return dayMatch && monthMatch && yearMatch

    # GET DAYS: Get the days of this month with all data
    $scope.getDays = (monthDays) ->

        days = []
        
        i = 1
        while i <= monthDays[$scope.current.month] 
            days.push { 
                nr: i
                disabled: false
                weekend: false
                freeTimes: false
                times: {
                    id: null
                    performerId: null
                    day: null
                    morning: false
                    afternoon: false
                    evening: false
                }
            }
            i++

        return days

    # GET WEEKS: Get the weeks of this month with empty spaces
    $scope.getWeeks = (weekday, days) ->

        monthDays = []
        tempDays = []

        i = 0
        if weekday < 6
            while i <= $scope.temp.weekday
                tempDays.push { 
                    nr: ''
                    disabled: true
                    weekend: false
                    freeTimes: false
                    times: {}
                }
                i++

        angular.forEach days, (day) ->
            if tempDays.length == 7
                monthDays.push tempDays
                tempDays = []
            
            tempDays.push day

        if tempDays.length != 0
            while tempDays.length < 7
                tempDays.push ''
            monthDays.push tempDays

        console.log monthDays

        return monthDays

    # GET MONTH NAME: Get the name of the given month number 
    $scope.getMonthName = (monthNumber) ->
        return $scope.names.months['sv'][monthNumber]

    # CHANGE DATE: Change the selected day
    $scope.changeDate = (day) ->
        $scope.selected.year = $scope.current.year
        $scope.selected.month = $scope.current.month
        $scope.selected.day = day

        temp = new Date()
        temp.setFullYear $scope.selected.year, $scope.selected.month, $scope.selected.day
        CalendarService.setDate temp

    # CHANGE MONTH: Change the current month
    $scope.changeMonth = ->
        $scope.current.weeks = $scope.getWeeks()

    # GET FREE TIMES: Get the free times of a given performer
    $scope.$on 'CalendarService.getFreeTimes', ( event, performerId ) ->

        $scope.freeTimes = []
        
        $http
            url: "/api/PerformerTimeFree/PerformerMonth" + 
                "?performerId=" + 5 + 
                "&month=" + ($scope.input.date.getMonth() + 1) + 
                "&year=" + $scope.input.date.getFullYear()
            method: "GET"
        .success (status, data, headers, config) -> 
            angular.forEach status, (freeTime) ->

                date = new Date freeTime.day

                $scope.freeTimes.push { 
                    performerId: freeTime.performerId
                    date: date
                    morning: freeTime.morning
                    afternoon: freeTime.afternoon
                    evening: freeTime.evening 
                }

                angular.forEach $scope.current.weeks, (week) ->
                    day = _.findWhere week, { nr: date.getDate() }
                    if day
                        day.freeTimes = true


        .error (status, data, headers, config) -> 
            $scope.$broadcast 'infoMessage', data + ": Misslyckades med att hämta fria tider för denna månad"
            


    
    $scope.init()

    $scope.current.monthDays = $scope.getMonthDays($scope.selected.year)
    $scope.current.weekday = $scope.calculateWeekday($scope.current.month)
    $scope.current.days = $scope.getDays($scope.current.monthDays)
    $scope.current.weeks = $scope.getWeeks($scope.current.weekday, $scope.current.days)

    CalendarService.ready()