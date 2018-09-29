var MainModel = function (data) {
    //properties
    var self = this;
    self.productModel = new ProductModel(data);
}

var ProductModel = function (data, parent) {
    //properties
    var self = this;
    self.Id = ko.observable(null);
    self.Name = ko.observable('');
    self.Alias = ko.observable('');
    self.Description = ko.observable('');
    self.MetaKeyword = ko.observable('');
    self.IsActive = ko.observable(true);
    self.Price = ko.observable(0);
    self.OtherPrice = ko.observable(0);

    self.CategoryId = ko.observable(null);
    self.CategoryName = ko.observable('');
    self.Images = ko.observable([]);

    if (data && data.Product) {
        ko.mapping.fromJS(data.Product, {}, self);
    }
    self.Tags = ko.observableArray(data.Product && data.Product.Tags ? data.Product.Tags.split(",") : []);

    self.addToCart = function () {

        var product = self.toJSON();
        $.ajax({
            url: data.API_URLs.AddToCart,
            type: "POST",
            data: { product: product },
            success: function (response) {
                if (response.IsSuccess == true) {
                    alertify.success('Đã thêm ' + self.Name() + ' vào giỏ hàng!');

                    var koNode = document.getElementById('default-navbar');
                    var hi = ko.dataFor(koNode);
                    hi.headerModel().NumberCart(response.CartLength ? response.CartLength : 0);
                }

            },
            error: function (xhr, error) {
            },
        });



    };
    self.formatMoney = function (number) {
        var val = parseInt(number);
        return val.toFixed(0).replace(/./g, function (c, i, a) {
            return i > 0 && c !== "." && (a.length - i) % 3 === 0 ? "." + c : c;
        });
    };

    ProductModel.prototype.toJSON = function () {
        var model = {
            Id: ko.utils.unwrapObservable(this.Id),
            Name: ko.utils.unwrapObservable(this.Name),
            Alias: ko.utils.unwrapObservable(this.Alias),
            CategoryId: ko.utils.unwrapObservable(this.CategoryId),
            Price: ko.utils.unwrapObservable(this.Price),
            Images: ko.utils.unwrapObservable(this.Images),
            Description: ko.utils.unwrapObservable(this.Description),
            MetaKeyword: ko.utils.unwrapObservable(this.MetaKeyword),
            IsActive: ko.utils.unwrapObservable(this.IsActive)
        };

        return model;
    };


}
