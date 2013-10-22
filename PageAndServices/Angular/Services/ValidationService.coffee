window.app.service('ValidationService', ->

    this.stockholmPostalCode = (postalCode) ->
        
        if postalCode
            postalCode = parseInt postalCode.replace(/[^0-9]*/g, '')
            return postalCode >= 12000 && postalCode < 20000
        else
            return false

    this.swedishPersonalNumber = (personalNumber) ->
        
        if personalNumber
            personalNumber = personalNumber.replace(/[^0-9]*/g, '')

            if personalNumber.length == 12
                personalNumber = personalNumber.substr 2, 10
            else if personalNumber.length == 10
                personalNumber = personalNumber.substr 0, 10
            else
                return false

            result = 0
            for i in [0..9] by 1
                num = (2 - i % 2) * parseInt personalNumber[i]
                _.each num + '', (c) ->
                    result += parseInt c

            return result % 10 == 0
        else 
            return false

)