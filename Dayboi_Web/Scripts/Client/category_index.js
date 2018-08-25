var MainModel = function (data) {
    //properties
    var self = this;
    self.EditCategoryUrl = ko.observable(data.API_URLs.EditCategoryUrl);
    //self.categoryModel = new CategoryModel(data);
    self.Categories = ko.observableArray(data.Categories || []);
}

