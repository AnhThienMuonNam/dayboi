var MainModel = function (data) {
    //properties
    var self = this;
    self.EditPoolCategoryUrl = ko.observable(data.API_URLs.EditPoolCategoryUrl);
    self.PoolCategories = ko.observableArray(data.PoolCategories || []);
}

