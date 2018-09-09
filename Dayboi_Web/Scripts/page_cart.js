var MainModel = function (data) {
    //properties
    var self = this;
    self.Carts = ko.observableArray(data.Carts || []);
    self.orderModel = ko.observable(new OrderModel(data));
    self.formatMoney = function (number) {
        var val = parseInt(number);
        return val.toFixed(0).replace(/./g, function (c, i, a) {
            return i > 0 && c !== "." && (a.length - i) % 3 === 0 ? "." + c : c;
        }) ;
    };
}

var OrderModel = function (parent) {
    //properties
    var self = this;
   
    self.Name = ko.observable('');
    self.Email = ko.observable('');
    self.Phone = ko.observable('');
    self.Address = ko.observable('');

    self.createOrder = function () {
        var order = self.toJSON();
        $.ajax({
            url: parent.API_URLs.CreateOrder,
            type: "POST",
            data: { orderModel: order },
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

    OrderModel.prototype.toJSON = function () {
        var model = {
            Name: ko.utils.unwrapObservable(this.Name),
            Email: ko.utils.unwrapObservable(this.Email),
            Phone: ko.utils.unwrapObservable(this.Phone),
            Address: ko.utils.unwrapObservable(this.Address),
        };

        return model;
    };
}


