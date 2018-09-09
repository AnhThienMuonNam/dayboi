var MainModel = function (data) {
    //properties
    var self = this;
    self.EditProductUrl = ko.observable(data.API_URLs.EditProductUrl);
    self.Products = ko.observableArray(data.Products || []);
}

