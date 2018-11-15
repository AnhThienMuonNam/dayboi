var MainModel = function (data) {
    var self = this;

    self.TempPriceOfOrder = ko.observable(0);

    self.Carts = ko.observableArray(convertCarts(data.Carts) || []);

    self.orderModel = ko.observable(new OrderModel(data, parent));

    function convertCarts(carts) {
        var result = [];
        if (carts) {
            for (i = 0; i < carts.length; i++) {
                var item = carts[i];
                self.TempPriceOfOrder(self.TempPriceOfOrder() + item.SumPrice);
                var cartModel = new CartModel(item);
                result.push(cartModel);
            }
        }
        return result;
    };

    self.formatMoney = function (number) {
        var val = parseInt(number);
        return val.toFixed(0).replace(/./g, function (c, i, a) {
            return i > 0 && c !== "." && (a.length - i) % 3 === 0 ? "." + c : c;
        });
    };

    self.plusItem = function (item) {
        if (item) {
            $.ajax({
                url: data.API_URLs.PlusorMinusItem,
                type: "POST",
                data: { productId: item.ProductId(), isPlus: true },
                success: function (response) {
                    if (response.IsSuccess == true) {
                        item.Quantity(item.Quantity() + 1);
                        item.SumPrice(item.Quantity() * item.Price());
                        self.TempPriceOfOrder(self.TempPriceOfOrder() + item.Price());
                    }

                },
                error: function (xhr, error) {
                },
            });
        }
    }

    self.minusItem = function (item) {
        if (item) {
            $.ajax({
                url: data.API_URLs.PlusorMinusItem,
                type: "POST",
                data: { productId: item.ProductId(), isPlus: false },
                success: function (response) {
                    if (response.IsSuccess == true) {
                        item.Quantity(item.Quantity() - 1);
                        item.SumPrice(item.Quantity() * item.Price());
                        self.TempPriceOfOrder(self.TempPriceOfOrder() - item.Price());
                    }

                },
                error: function (xhr, error) {
                },
            });
        }
    }

    self.removeProduct = function (item) {
        if (item) {
            $.ajax({
                url: data.API_URLs.RemoveProduct,
                type: "POST",
                data: { productId: item.ProductId() },
                success: function (response) {
                    if (response.IsSuccess == true) {
                        self.Carts.remove(item);
                        self.TempPriceOfOrder(self.TempPriceOfOrder() - item.SumPrice());
                    }

                },
                error: function (xhr, error) {
                },
            });
        }
    }

    self.Provinces = ko.observableArray(data.Options.Provinces || []);
    self.Districts = ko.observableArray([]);
    self.Wards = ko.observableArray([]);
    self.PaymentMethods = ko.observableArray(data.Options.PaymentMethods || []);
}

var CartModel = function (parent) {
    //properties
    var self = this;

    self.ProductId = ko.observable(parent.ProductId || '');
    self.ProductName = ko.observable(parent.ProductName || '');
    self.Alias = ko.observable(parent.Alias || '');
    self.Image = ko.observable(parent.Image || '');
    self.Price = ko.observable(parent.Price || '');
    self.SumPrice = ko.observable(parent.SumPrice || '');
    self.Quantity = ko.observable(parent.Quantity || '');
}


var OrderModel = function (options, parent) {
    //properties
    var self = this;
    self.ExecuteValidation = ko.observable(false);
    self.Note = ko.observable('');
    self.Name = ko.observable('').extend({
        required: {
            message: "Bạn chưa nhập họ tên",
            onlyIf: function () {
                return self.ExecuteValidation() === true;
            }
        }
    });
    self.Email = ko.observable('').extend({
        required: {
            message: "Bạn chưa nhập email",
            onlyIf: function () {
                return self.ExecuteValidation() === true;
            }
        }
    });
    self.Phone = ko.observable('').extend({
        required: {
            message: "Bạn chưa nhập số điện thoại",
            onlyIf: function () {
                return self.ExecuteValidation() === true;
            }
        }
    });
    self.Address = ko.observable('').extend({
        required: {
            message: "Bạn chưa nhập địa chỉ nhận hàng",
            onlyIf: function () {
                return self.ExecuteValidation() === true;
            }
        }
    });

    self.ProvinceId = ko.observable('').extend({
        required: {
            message: "Bạn chưa chọn tỉnh/thành phố",
            onlyIf: function () {
                return self.ExecuteValidation() === true;
            }
        }
    });
    self.DistrictId = ko.observable('').extend({
        required: {
            message: "Bạn chưa chọn quận/huyện",
            onlyIf: function () {
                return self.ExecuteValidation() === true;
            }
        }
    });
    self.WardId = ko.observable('').extend({
        required: {
            message: "Bạn chưa chọn phường xã",
            onlyIf: function () {
                return self.ExecuteValidation() === true;
            }
        }
    });
    self.PaymentMethodId = ko.observable('').extend({
        required: {
            message: "Bạn chưa chọn hình thức thanh toán",
            onlyIf: function () {
                return self.ExecuteValidation() === true;
            }
        }
    });

    self.ProvinceId.subscribe(function (value) {
        if (value) {
            getDistrictsByProvinceId(value);
        } else {
            parent.Districts([]);
        }
    });

    self.DistrictId.subscribe(function (value) {
        if (value) {
            getWardsByDistrictId(value);
        } else {
            parent.Wards([]);
        }
    });


    function getDistrictsByProvinceId(provinceId) {
        $.ajax({
            url: options.API_URLs.GetDistrictsByProvinceId,
            type: "POST",
            data: { provinceId: provinceId },
            success: function (response) {
                if (response.IsSuccess == true) {
                    parent.Districts(response.Districts);
                }

            },
            error: function (xhr, error) {
            },
        });
    };

    function getWardsByDistrictId(districtId) {
        $.ajax({
            url: options.API_URLs.GetWardsByDistrictId,
            type: "POST",
            data: { districtId: districtId },
            success: function (response) {
                if (response.IsSuccess == true) {
                    parent.Wards(response.Wards);
                }

            },
            error: function (xhr, error) {
            },
        });
    };

    function getProvinceName() {
        var province = parent.Provinces().filter(function (item) { return item.Id == self.ProvinceId(); })[0];
        return province ? province.Name : '';
    };

    function getDistrictName() {
        var district = parent.Districts().filter(function (item) { return item.Id == self.DistrictId(); })[0];
        return district ? district.Name : '';

    };

    function getWardName() {
        var ward = parent.Wards().filter(function (item) { return item.Id == self.WardId(); })[0];
        return ward ? ward.Name : '';
    };

    function getPaymentMethodName() {
        var paymentMethod = parent.PaymentMethods().filter(function (item) { return item.Id == self.PaymentMethodId(); })[0];
        return paymentMethod ? paymentMethod.Name : '';
    };

    self.createOrder = function () {
        self.ExecuteValidation(true);
        self.showErrorValidations();
        if (self.HasError() === true)
            return;
        var order = self.toJSON();
        $.ajax({
            url: options.API_URLs.AddCartOrderToSession,
            type: "POST",
            data: { orderModel: order },
            success: function (response) {
                if (response.IsSuccess == true) {
                    window.location.replace(options.API_URLs.Checkout);
                }
            },
            error: function (xhr, error) {
            },
        });
    };
    self.HasError = ko.observable(false);
    self.showErrorValidations = function () {
        var errors = ko.validation.group(self);
        if (errors().length > 0) {
            errors.showAllMessages(true);
            self.HasError(true);
        } else {
            errors.showAllMessages(false);
            self.HasError(false);
        }
    };

    OrderModel.prototype.toJSON = function () {
        var model = {
            Name: ko.utils.unwrapObservable(this.Name),
            Email: ko.utils.unwrapObservable(this.Email),
            Phone: ko.utils.unwrapObservable(this.Phone),
            Address: ko.utils.unwrapObservable(this.Address),
            ProvinceName: ko.utils.unwrapObservable(getProvinceName()),
            DistrictName: ko.utils.unwrapObservable(getDistrictName()),
            WardName: ko.utils.unwrapObservable(getWardName()),
            ProvinceId: ko.utils.unwrapObservable(this.ProvinceId),
            DistrictId: ko.utils.unwrapObservable(this.DistrictId),
            WardId: ko.utils.unwrapObservable(this.WardId),
            PaymentMethodId: ko.utils.unwrapObservable(this.PaymentMethodId),
            PaymentMethodName: ko.utils.unwrapObservable(getPaymentMethodName()),
            ShippingFee: ko.utils.unwrapObservable(0),
            Note: ko.utils.unwrapObservable(this.Note),
            TotalPrice: ko.utils.unwrapObservable(parent.TempPriceOfOrder),
        };

        return model;
    };
}


