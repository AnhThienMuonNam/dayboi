var MainModel = function (data) {
    //properties
    var self = this;
    self.EditAccountUrl = ko.observable(data.API_URLs.EditAccountUrl);
    self.Accounts = ko.observableArray(data.Accounts || []);
}

