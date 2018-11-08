var MainModel = function (data) {
    //properties
    var self = this;
    self.EditOrderUrl = ko.observable(data.API_URLs.EditOrderUrl);
    self.Orders = ko.observableArray(data.Orders || []);
}

