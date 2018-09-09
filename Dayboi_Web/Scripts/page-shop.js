var MainModel = function (data) {
    //properties
    var self = this;
    //self.EditCategoryUrl = ko.observable(data.API_URLs.EditCategoryUrl);
    //self.categoryModel = new CategoryModel(data);
    self.Products = ko.observableArray(data.Category.Products || []);
    self.formatMoney = function (number) {
        var val = parseInt(number);
        return val.toFixed(0).replace(/./g, function (c, i, a) {
            return i > 0 && c !== "." && (a.length - i) % 3 === 0 ? "." + c : c;
        });
    };
   
}

