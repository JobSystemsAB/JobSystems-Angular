window.app.service('GoogleMapsService', [ '$http', ($http) ->
    
    this.getAddressType = (address_components, type) ->
        temp = _.find address_components, (component) ->
            return _.contains component.types, type
        if temp
            return temp.long_name
        else
            return null

])