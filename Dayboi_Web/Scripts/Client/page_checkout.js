var MainModel = function (data) {
    var self = this;
    self.Order = ko.observable(data.Checkout.Order || '');
    self.Carts = ko.observableArray(data.Checkout.Carts || []);

    self.formatMoney = function (number) {
        var val = parseInt(number);
        return val.toFixed(0).replace(/./g, function (c, i, a) {
            return i > 0 && c !== "." && (a.length - i) % 3 === 0 ? "." + c : c;
        });
    };
    self.createOrder = function () {
        $.ajax({
            url: data.API_URLs.CreateOrder,
            type: "POST",
            success: function (response) {
                if (response.IsSuccess == true) {
                    alertify.success('Đã tạo đơn hàng thành công!');
                    var koNode = document.getElementById('default-navbar');
                    var hi = ko.dataFor(koNode);
                    hi.headerModel().NumberCart(0);
                }

            },
            error: function (xhr, error) {
            },
        });
    };
    self.back = function () {
        history.go(-1)
    };
}



var OrderModel = function (options, parent) {
    //properties
    var self = this;
    self.ExecuteValidation = ko.observable(false);

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

    self.createOrder = function () {
        self.ExecuteValidation(true);
        self.showErrorValidations();
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


        //$.ajax({
        //    url: options.API_URLs.CreateOrder,
        //    type: "POST",
        //    data: { orderModel: order },
        //    success: function (response) {
        //        if (response.IsSuccess == true) {
        //            alertify.success('Đã tạo đơn hàng thành công!');
        //            var koNode = document.getElementById('default-navbar');
        //            var hi = ko.dataFor(koNode);
        //            hi.headerModel().NumberCart(0);
        //        }

        //    },
        //    error: function (xhr, error) {
        //    },
        //});
    };

    self.showErrorValidations = function () {
        var errors = ko.validation.group(self);
        if (errors().length > 0) {
            errors.showAllMessages();
            //self.hasErrors(true);
        } else {
            //self.hasErrors(false);
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
            ShippingFee: ko.utils.unwrapObservable(0),
        };

        return model;
    };
}


