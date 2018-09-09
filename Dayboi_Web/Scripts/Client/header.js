var Header_MainModel = function (data) {
    //properties
    var self = this;
    self.headerModel = ko.observable(new HeaderModel(data));
}

var HeaderModel = function (parent) {
    var self = this;
    self.NumberCart = ko.observable();
    function getCartLength() {
        $.ajax({
            url: parent.API_URLs.GetCartLength,
            type: "GET",
            success: function (response) {
                if (response.IsSuccess == true) {
                    self.NumberCart(response.CartLength ? response.CartLength : 0);
                }
            },
            error: function (xhr, error) {
                var e = 0;
            },
        });
    }
    getCartLength();
}