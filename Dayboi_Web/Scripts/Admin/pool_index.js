var MainModel = function (data) {
    //properties
    var self = this;
    self.EditPoolUrl = ko.observable(data.API_URLs.EditPoolUrl);
    self.Pools = ko.observableArray(data.Pools || []);
}

