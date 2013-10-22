(function() {
  window.app.service('ValidationService', function() {
    this.stockholmPostalCode = function(postalCode) {
      if (postalCode) {
        postalCode = parseInt(postalCode.replace(/[^0-9]*/g, ''));
        return postalCode >= 12000 && postalCode < 20000;
      } else {
        return false;
      }
    };
    return this.swedishPersonalNumber = function(personalNumber) {
      var i, num, result, _i;

      if (personalNumber) {
        personalNumber = personalNumber.replace(/[^0-9]*/g, '');
        if (personalNumber.length === 12) {
          personalNumber = personalNumber.substr(2, 10);
        } else if (personalNumber.length === 10) {
          personalNumber = personalNumber.substr(0, 10);
        } else {
          return false;
        }
        result = 0;
        for (i = _i = 0; _i <= 9; i = _i += 1) {
          num = (2 - i % 2) * parseInt(personalNumber[i]);
          _.each(num + '', function(c) {
            return result += parseInt(c);
          });
        }
        return result % 10 === 0;
      } else {
        return false;
      }
    };
  });

}).call(this);
