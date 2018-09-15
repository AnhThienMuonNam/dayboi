var MainModel = function (data) {
    var self = this;

    self.Products = ko.observableArray(data.Category.Products || []);
    self.Categories = ko.observableArray(data.Options.Categories || []);
    self.NewestProducts = ko.observableArray(data.Options.NewestProducts || []);

    self.formatMoney = function (number) {
        var val = parseInt(number);
        return val.toFixed(0).replace(/./g, function (c, i, a) {
            return i > 0 && c !== "." && (a.length - i) % 3 === 0 ? "." + c : c;
        });
    };
   
}

