var MainModel = function (data) {
    //properties
    var self = this;
    self.Order = ko.observable(data.Order || null);
    self.OrderDetails = ko.observableArray(data.Order.OrderDetails && data.Order && data ? data.Order.OrderDetails : []);
    self.EditProductUrl = ko.observable(data.API_URLs.EditProductUrl);
    self.OrderStatus = ko.observableArray(data.OrderStatus || []);
    self.PaymentMethods = ko.observableArray(data.PaymentMethods || []);

    self.OrderId = ko.observable(data.Order ? data.Order.Id : null);
    self.OrderStatusId = ko.observable(data.Order ? data.Order.OrderStatusId : null);
    self.PaymentMethodId = ko.observable(data.Order ? data.Order.PaymentMethodId : null);

    self.update = function () {
        $.ajax({
            url: data.API_URLs.Update,
            type: "POST",
            data: { orderId: self.OrderId(), orderStatusId: self.OrderStatusId() },
            success: function (response) {
                if (response.IsSuccess == true) {
                    alertify.success('Cập nhật đơn hàng thành công');
                }
            },
            error: function (xhr, error) {
            },
        });
    }
}

