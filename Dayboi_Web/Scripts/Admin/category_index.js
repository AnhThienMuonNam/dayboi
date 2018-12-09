var MainModel = function (data) {
    //properties
    var self = this;
    self.EditCategoryUrl = ko.observable(data.API_URLs.EditCategoryUrl);
    //self.categoryModel = new CategoryModel(data);
    self.Categories = ko.observableArray(data.Categories || []);

    self.Keyword = ko.observable(null);
    self.search = function () {
        self.Categories(data.Categories || []);
        if (self.Keyword()) {
            self.Categories(self.Categories().filter(function (item) {
                return item.Name.toUpperCase().indexOf(self.Keyword().toUpperCase()) !== -1 ||
                    item.Alias.toUpperCase().indexOf(self.Keyword().toUpperCase()) !== -1;
            })
            );
        }
    };
}

